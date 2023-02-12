using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterScriptableObject characterData;

    float currentHealth;
    float currentMoveSpeed;
    float currentRecovery;
    float currentMight;
    float currentProjectileSpeed;

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
    private void Start()
    {
        experienceCap = levelRanges[0].experienceCapIncrease;// chinh cho gioi han level de len cap khong = 0
        
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

 

   
}
