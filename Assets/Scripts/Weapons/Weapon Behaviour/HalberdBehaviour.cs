using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalberdBehaviour : ProjectileWeaponBehaviour
{
    // Start is called before the first frame update


    protected override void Start()
    {
        base.Start();

    }
    // Update is called once per frame
    void Update()
    {
        transform.position += direction * currentSpeed * Time.deltaTime;// chinh huong cua vu khi bay ra 
    }
}
