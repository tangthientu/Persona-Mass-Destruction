using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Weapon Stats")]
    public WeaponScriptableObject weaponData;
  
    float currentCooldown;
    
    protected PlayerMovement pm;


    protected virtual void Start()
    {
        currentCooldown = weaponData.CooldownDuration;
        pm = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        currentCooldown -= Time.deltaTime;
        if(currentCooldown <= 0f)
        {
            Attack();
        }
    }
    protected virtual void Attack()
    {
        currentCooldown= weaponData.CooldownDuration;
    }
}
