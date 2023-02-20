using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceGem : PickUp,ICollectibles    
{
    public int experienceGranted;
    public void Collect()
    {
       PlayerStats player =FindObjectOfType<PlayerStats>();//lien he player stats
        player.IncreaseExperience(experienceGranted);// tang exp bang so exp trog exp granted
       
    }
   

}
