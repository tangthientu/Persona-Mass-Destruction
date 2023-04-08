using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public List<WeaponController> weaponSlots = new List<WeaponController>(6);
    public int[] weaponLevels = new int[6];
    public List<Image> weaponUISlots = new List<Image>(6);
    public List<PassiveItem> passiveItemSlots = new List<PassiveItem>(6);
    public int[] passiveItemLevels = new int[6];
    public List<Image> passiveItemUISlots = new List<Image>(6);
    PlayerStats player;
    public void Start()
    {
        player = FindFirstObjectByType<PlayerStats>();
    }

     public void AddWeapon(int slotIndex, WeaponController weapon)
     {
         weaponSlots[slotIndex] = weapon;
         weaponLevels[slotIndex] = weapon.weaponData.Level;
         weaponUISlots[slotIndex].enabled = true;
         weaponUISlots[slotIndex].sprite = weapon.weaponData.Icon;
     }
     public void AddPassiveItem(int slotIndex, PassiveItem passiveItem)
     {
         passiveItemSlots[slotIndex] = passiveItem;
         passiveItemLevels[slotIndex] = passiveItem.passiveItemData.Level;
         passiveItemUISlots[slotIndex].enabled = true;
         passiveItemUISlots[slotIndex].sprite = passiveItem.passiveItemData.Icon;
     }
   
     public void LevelUpWeapon(int slotIndex)
     {
         if(weaponSlots.Count > slotIndex)
         {
             WeaponController weapon = weaponSlots[slotIndex];
             if(!weapon.weaponData.NextLevelPrefab)
             {
                 Debug.LogError("NO NEXT LEVEL FOR " + weapon.name);
                 return;
             }
             GameObject upgradeWeapon = Instantiate(weapon.weaponData.NextLevelPrefab,transform.position, Quaternion.identity);
             upgradeWeapon.transform.SetParent(transform);
             AddWeapon(slotIndex, upgradeWeapon.GetComponentInChildren<WeaponController>());
             Destroy(weapon.gameObject);
             weaponLevels[slotIndex] = upgradeWeapon.GetComponent<WeaponController>().weaponData.Level;

         }
     }
     public void LevelUpPassiveItem(int slotIndex)
     {
          if(passiveItemSlots.Count > slotIndex)
         {
             PassiveItem passiveItem = passiveItemSlots[slotIndex];
             if(!passiveItem.passiveItemData.NextLevelPrefab)
             {
                 Debug.LogError("NO NEXT LEVEL FOR " + passiveItem.name);
                 return;
             }
             GameObject upgradePassiveItem = Instantiate(passiveItem.passiveItemData.NextLevelPrefab,transform.position, Quaternion.identity);
             upgradePassiveItem.transform.SetParent(transform);
             AddPassiveItem(slotIndex, upgradePassiveItem.GetComponentInChildren<PassiveItem>());
             Destroy(passiveItem.gameObject);
             passiveItemLevels[slotIndex] = upgradePassiveItem.GetComponent<PassiveItem>().passiveItemData.Level;

         }
     }
    public void playerSpeedUpgrade()
    {
        player.currentMoveSpeed += 0.2f;
    }
    public void playerMightUpgrade()
    {
        player.currentMight += 1f;
    }

    public void playerHealthUpgrade()
    {
        
        player.currentHealth += 0.5f;

    }
    public void playerPickUpRangeUpgrade()
    {
        player.currentPickupRange += 0.5f;
    }
    public void playerProjectileSpeedUpgrade()
    {
        player.currentProjectileSpeed += 0.5f;
    }
}
