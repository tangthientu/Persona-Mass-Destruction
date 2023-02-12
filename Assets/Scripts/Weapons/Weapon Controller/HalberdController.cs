using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalberdController : WeaponController
{ 
    // Start is called before the first frame update
   protected override void Start()
    {
        base.Start();
    }

   protected override void Attack()
    {
        base.Attack();
        GameObject spawnedHalberd = Instantiate(weaponData.Prefab);// ban ra projectile
        spawnedHalberd.transform.position = transform.position;// vi tri cua projectile nam o nguoi choi
        spawnedHalberd.GetComponent<HalberdBehaviour>().directionChecker(pm.lastMovedVector);// chinh vi tri theo huong nguoi choi
    }
    
}
