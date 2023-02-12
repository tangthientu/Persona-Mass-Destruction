using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObjects/Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    //chi so ke dich
    [SerializeField]
    //mau ke dich
    float maxHealth;
    public float MaxHealth { get => maxHealth; private set => maxHealth = value; }
    [SerializeField]
    //toc do di chuyen
    float movementSpeed;
    public float MovementSpeed { get => movementSpeed; private set => movementSpeed = value; }
    [SerializeField]
    float damage;
    public float Damage { get => damage; private set => damage=value; }
    [SerializeField]
    bool deathStatus;
    public bool DeathStatus { get => deathStatus; private set => deathStatus = value; }

}
