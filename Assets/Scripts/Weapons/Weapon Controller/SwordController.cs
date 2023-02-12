using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : WeaponController
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedSword = Instantiate(weaponData.Prefab);// ban ra projectile
        spawnedSword.transform.position = transform.position;// vi tri cua projectile nam o nguoi choi
        spawnedSword.GetComponent<SwordBehaviour>().directionChecker(pm.lastMovedVector);// chinh vi tri theo huong nguoi choi
    }

}
