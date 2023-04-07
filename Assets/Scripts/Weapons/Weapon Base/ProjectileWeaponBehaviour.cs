using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeaponBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public WeaponScriptableObject weaponData;

    protected Vector3 direction; //huong cua projectile
    public float destroyAfterSeconds;//xoa sau vai giay
    // chi so hien tai
    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;
    protected float currentPierce;
    private void Awake()
    {
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldownDuration = weaponData.CooldownDuration;
        currentPierce = weaponData.Pierce;
    }
    public float GetCurrentDamage()
    {
        return currentDamage *= FindObjectOfType<PlayerStats>().currentMight;
    }

    protected virtual void Start()
    {
        Destroy(gameObject,destroyAfterSeconds);//pha huy projectile sau vai giay
    }

   public void directionChecker(Vector3 dir)
    {
        direction = dir;
        float dirx = direction.x;
        float diry = direction.y;

        Vector3 scale = transform.localScale;
        Vector3 rotation = transform.rotation.eulerAngles;

        if(dirx<0 && diry==0) //neu huong x nho hon 0 va y =0 thi scale x va y = -1 de projectile co the lat nguoc lai (day la phia ben trai)
        {
            scale.x = scale.y * -1;
            scale.y = scale.y * -1;
        }
        else if (dirx==0 && diry<0)//down
        {
            scale.y = scale.y * -1;
        }
        else if (dirx == 0 && diry > 0)//up
        {
            scale.x = scale.x * -1;
        }
        else if (dirx > 0 && diry > 0)//right up
        {
            rotation.z = 0f;
        }
        else if (dirx > 0 && diry < 0)//right down
        {
            rotation.z = -90f;
        }
        else if (dirx < 0 && diry > 0)//left up
        {
            scale.x = scale.y * -1;
            scale.y = scale.y * -1;
            rotation.z = -90f;
        }
        else if (dirx < 0 && diry < 0)//left down
        {
            scale.x = scale.y * -1;
            scale.y = scale.y * -1;
            rotation.z = 0f;
        }
        transform.localScale = scale;
        transform.rotation = Quaternion.Euler(rotation); 

    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        //gay sat thuong khi va cham
        if(collision.CompareTag("Enemy"))
        {
            EnemyStats enemy = collision.GetComponent<EnemyStats>();
            enemy.takeDamage(GetCurrentDamage());
            ReducePierce();
        }
    }
    void ReducePierce()
    {
        --currentPierce;
        if(currentPierce < 0)
        {
            Destroy(gameObject);
        }
    }
}
