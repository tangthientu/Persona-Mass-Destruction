using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBehaviour : MeleeWeaponBehaviour
{
    // Start is called before the first frame update
    List<GameObject> markedEnemies;//danh sach dich da bi danh trung 1 lan truoc khi hoi skill;

    protected override void Start()
    {
        base.Start();
        markedEnemies = new List<GameObject>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        transform.position += direction * currentSpeed * Time.deltaTime;// chinh huong cua vu khi bay ra
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !markedEnemies.Contains(collision.gameObject))
        {
            EnemyStats enemy = collision.GetComponent<EnemyStats>();
            enemy.takeDamage(currentDamage);//nhan sat thuong khi va cham
            markedEnemies.Add(collision.gameObject);//them vao danh sach khong the bi danh trung cho den khi hoi chieu

        }
    }
}
