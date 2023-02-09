using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBehaviour : MeleeWeaponBehaviour
{
    // Start is called before the first frame update
    SwordController sc;
    protected override void Start()
    {
        base.Start();
        sc = FindObjectOfType<SwordController>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        transform.position += direction * sc.speed * Time.deltaTime;// chinh huong cua vu khi bay ra
    }
}
