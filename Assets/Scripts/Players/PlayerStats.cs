using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update
    CharacterScriptableObject characterData;

    
    public float currentHealth;
    [HideInInspector]
    public float currentMoveSpeed;
    [HideInInspector]
    public float currentRecovery;
    [HideInInspector]
    public float currentMight;
    [HideInInspector]
    public float currentProjectileSpeed;
    [HideInInspector]
    public float currentPickupRange;

  

    [Header("I-frames")]//khung hinh bat hoai
    public float inviciblityDuration;
    float invicibilityTimer;
    bool isInvicible;
    // thanh mau
    public HealthBar healthBar; 


    [Header("Experience/Level")]
    public int experience = 0;//kinh nghiem
    public int level = 1;//cap do
    public int experienceCap;// gioi han thanh kinh nghiem
    [System.Serializable]
    public class LevelRange
    {
        public int startLevel;//level bat dau
        public int endLevel;//level ket thuc
        public int experienceCapIncrease;
    }
    public List<LevelRange> levelRanges;
    InventoryManager inventory;
    public int weaponIndex;
    public int passiveItemIndex;
    // public GameObject secondWeaponTest;
    public GameObject firstPassiveItemTest, secondPassiveItemTest;


    private void Awake()
    {
        characterData = CharacterSelector.GetData();
        CharacterSelector.instance.DestroySingleton();
        inventory = GetComponent<InventoryManager>();


        //gan' bien
        currentHealth = characterData.MaxHealth;
        currentMoveSpeed = characterData.MoveSpeed;
        currentMight = characterData.Might;
        currentProjectileSpeed = characterData.ProjectileSpeed;
        currentRecovery = characterData.Recovery;
        currentPickupRange = characterData.PickupRange;
        //spawn vu khi
        SpawnWeapon(characterData.StartingWeapon);
        // SpawnWeapon(secondWeaponTest);
        SpawnPassiveItem(firstPassiveItemTest);
        SpawnPassiveItem(secondPassiveItemTest);
    }

    private void Start()
    {
        experienceCap = levelRanges[0].experienceCapIncrease;// chinh cho gioi han level de len cap khong = 0
        healthBar.SetMaxHealth(currentHealth);
    }
    private void Update()
    {
        if(invicibilityTimer>0)//neu thoi gian bat hoai la lon hon 0 thi tru no xuong tu tu cho den khi = 0
        {
            invicibilityTimer-=Time.deltaTime;

        }
        else if(isInvicible)
        {
            isInvicible = false;//reset trang thai bat hoai
        }

        Recover();
    }
    public void IncreaseExperience(int amount)
    {
        experience += amount;//kinh nghiem duoc + bang so luong nhan dc
        LevelUpChecker();// kiem tra level 
    }
    public void LevelUpChecker()// trong khoang tu startLevel den endLevel thi level cap se tang len
    {
        if(experience>=experienceCap)//neu kn hien tai lon hon gioi han kn
        {
            level++;// thi len cap
            experience-=experienceCap;// so kinh nghiem bay gio se bang so kinh nghiem bi du khi len cp
            int experienceCapIncrease = 0;
            foreach (LevelRange range in levelRanges)
            {
                if(level >= range.startLevel && level <= range.endLevel) // tu level bat dau den ket thuc
                {
                    experienceCapIncrease = range.experienceCapIncrease;//tang gioi han kinh nghiem
                    break;
                }
            }
            experienceCap+=experienceCapIncrease;

        }
    }
    public void TakeDamage(float dmg)
    {
        if(!isInvicible)//trong khung hinh bat hoai thi khong nhan sat thuong
        { 
            currentHealth -= dmg;//tru mau = damage khi goi method take dmg(nhan sat thuong)
            invicibilityTimer = inviciblityDuration;//timer = duration
            isInvicible = true;//bat hoai = true
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Kill();
            }
        }
        healthBar.SetHealth(currentHealth); // cap nhat thanh mau
    }
    public void Kill()
    {
        SceneManager.LoadScene("GameOver");
        Debug.Log("player died");
    }

    public void RestoreHealth(float amount)
    {
        if(currentHealth<characterData.MaxHealth)// chi hoi mau neu nguoi choi co mau hein tai nho hon mau toi da
        {
            currentHealth+=amount;//hoi mau bang so amount
            if(currentHealth>characterData.MaxHealth)//chac chan rang mau nguoi choi khong vuot mau toi da
            {
                currentHealth = characterData.MaxHealth;
            }
        }
    }
    public void Recover()
    {
        if(currentHealth<characterData.MaxHealth)
        {
            currentHealth+=currentRecovery*Time.deltaTime;
            if (currentHealth > characterData.MaxHealth)//chac chan rang mau nguoi choi khong vuot mau toi da
            {
                currentHealth = characterData.MaxHealth;
            }
        }
    }

    public void SpawnWeapon(GameObject weapon)//spawn ra vu khi khoi dau
    {
        if(weaponIndex >= inventory.weaponSlots.Count - 1)
        {
            Debug.LogError("Inventory sots already full");
            return;
        }

        GameObject spawnedWeapon = Instantiate(weapon, transform.position, Quaternion.identity);//spawn vu khi
        spawnedWeapon.transform.SetParent(transform);// chinh cho vu khi la con cua nguoi choi
        inventory.AddWeapon(weaponIndex, spawnedWeapon.GetComponent<WeaponController>());
        weaponIndex++;
    }
    public void SpawnPassiveItem(GameObject passiveItem)//spawn ra vu khi khoi dau
    {
        if(passiveItemIndex >= inventory.passiveItemSlots.Count - 1)
        {
            Debug.LogError("Inventory sots already full");
            return;
        }

        GameObject spawnedPassiveItem = Instantiate(passiveItem, transform.position, Quaternion.identity);//spawn vu khi
        spawnedPassiveItem.transform.SetParent(transform);// chinh cho vu khi la con cua nguoi choi
        inventory.AddPassiveItem(passiveItemIndex, spawnedPassiveItem.GetComponent<PassiveItem>());
        passiveItemIndex++;
    }
   
}
