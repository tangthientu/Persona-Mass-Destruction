using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : PickUp,ICollectibles
{
    public int healthToRestore;
    public void Collect()
    {
        PlayerStats player = PlayerStats.FindObjectOfType<PlayerStats>();//ref player  stats
        player.RestoreHealth(healthToRestore);//hoi mau
       
    }

   

}
