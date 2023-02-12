using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public EnemyScriptableObject enemyData;

    Transform player;
    
    private SpriteRenderer sr;
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        sr = GetComponent<SpriteRenderer>();    
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyData.MovementSpeed * Time.deltaTime);
        sr.flipX = player.transform.position.x > gameObject.transform.position.x;
    }
}
