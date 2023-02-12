using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "WeaponScriptableObject",menuName = "ScriptableObjects/Weapon")]
public class WeaponScriptableObject : ScriptableObject
{
    [SerializeField]
    GameObject prefab;
    public GameObject Prefab { get => prefab; private set => prefab = value; }
    //Chi so vu khi
    [SerializeField]

    // sat thuong 
    float damage;
    public float Damage { get => damage; private set => damage = value; }
    [SerializeField]

    // toc do bay
    float speed;
    public float Speed { get => speed; private set => speed = value; }
    [SerializeField]

    // thoi gian hoi
    float cooldownDuration;
    public float CooldownDuration { get => cooldownDuration; private set => cooldownDuration = value; }
    [SerializeField]

    // xuyen dich
    int pierce;
    public int Pierce { get => pierce; private set => pierce = value; }
}
