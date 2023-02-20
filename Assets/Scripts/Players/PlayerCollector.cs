using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    PlayerStats player;
    CircleCollider2D playerCollector;
    public float pullspeed;
    private void Start()
    {
        player = FindObjectOfType<PlayerStats>();
        playerCollector = GetComponent<CircleCollider2D>();
    }
    void Update()
    {
        playerCollector.radius = player.currentPickupRange;    // hitbox cua tam nhat do se bang voi pickup range cua player
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out ICollectibles collectibles)) // check xem neu vat the cham vao co interface icollectibles
        {
            //pulling animation
            // lay rigidbody
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            // chi huong ve phia nguoi choi
            Vector2 forceDirection = (transform.position - collision.transform.position).normalized;
            //day item ve phia nguoi choi
            rb.AddForce(forceDirection * pullspeed);
            collectibles.Collect();// goi method
        }
    }
}
