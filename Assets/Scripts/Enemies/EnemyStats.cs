using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public EnemyScriptableObject enemyData;
    Animator am;
    [HideInInspector]
    public float currentHealth;

    [HideInInspector]
    public float currentMoveSpeed;
    [HideInInspector]
    public float currentDamage;
    [HideInInspector]
    public bool currentDeathStatus;


    public float despawnDistance = 20f;
    Transform player;



    public void Start()
    {
        player = FindObjectOfType<PlayerStats>().transform;
        am = GetComponent<Animator>();
    }
	void Update()
	{
        if (Vector2.Distance(transform.position, player.position) >= despawnDistance) {
            ReturnEnemy();
        }
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
        
        am.SetBool("Death",true);//chinh animator sang animation chet
        currentMoveSpeed = 0f;//khong chinh toc do di chuyen ve bang khong (ko hoat dong??)
        AudioSource deathsound = GameObject.FindGameObjectWithTag("enemydeathsfx").GetComponent<AudioSource>();
        deathsound.Play();
    }
    public void die()
    {
        Destroy(gameObject);//pha huy obj
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            PlayerStats player = collision.gameObject.GetComponent<PlayerStats>();// lien he script player stats = player
            player.TakeDamage(currentDamage);// tru mau nguoi choi bang sat thuong hien tai  thong qua take damage()
        }
    }
	private void OnDestroy()
	{
        EnemySpawner es = FindObjectOfType<EnemySpawner>();
        es.OnEnemyKilled();
	}
    void ReturnEnemy()
	{

        EnemySpawner es = FindObjectOfType<EnemySpawner>();
        transform.position = player.position + es.relativesSpawnPoints[Random.Range(0, es.relativesSpawnPoints.Count)].position;
	}
}
