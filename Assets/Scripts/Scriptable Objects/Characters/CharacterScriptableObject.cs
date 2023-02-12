using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="CharacterScriptableObject",menuName ="ScriptableObjects/Character")]
public class CharacterScriptableObject : ScriptableObject
{
    [SerializeField]
    GameObject startingWeapon;//vu khi khoi dau

    public GameObject StartingWeapon { get => startingWeapon; set => startingWeapon = value; }

    [SerializeField]
    float maxHealth;//mau toi da

    public float MaxHealth { get => maxHealth; set => maxHealth = value; }

    [SerializeField]
    float recovery;// toc do hoi mau 

    public float Recovery { get => recovery; set => recovery = value; }

    [SerializeField]
    float moveSpeed;// toc do di chuyen

    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    [SerializeField]
    float might;//mana

    public float Might { get => might; set => might = value; }

    [SerializeField]
    float projectileSpeed;//toc do vat the 

    public float ProjectileSpeed{ get => projectileSpeed; set => projectileSpeed = value; }
}
