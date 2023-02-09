using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalberdBehaviour : ProjectileWeaponBehaviour
{
    // Start is called before the first frame update
    HalberdController hc;
    protected override void Start()
    {
        base.Start();
        hc = FindObjectOfType<HalberdController>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        transform.position += direction * hc.speed * Time.deltaTime;// chinh huong cua vu khi bay ra
    }
}
