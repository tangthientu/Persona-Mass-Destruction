using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public EnemyScriptableObject enemyData;
    Animator am;
    float currentHealth;
    float currentMoveSpeed;
    float currentDamage;
    bool currentDeathStatus;
    public void Start()
    {
        am = GetComponent<Animator>();
    }
    void Awake()
    {
        currentHealth = enemyData.MaxHealth;
        currentMoveSpeed = enemyData.MovementSpeed;
        currentDamage = enemyData.Damage;
        currentDeathStatus = enemyData.DeathStatus;
        
    }
    
    public void takeDamage(float dmg)
    {
        currentHealth -= dmg;
        if(currentHealth <=0)
        {
            kill();//chet
            
        }
    }
    public void kill()
    {
        
        am.SetBool("Death",true);
        currentMoveSpeed = 0f;
    }
    public void die()
    {
        Destroy(gameObject);
    }
  
}
