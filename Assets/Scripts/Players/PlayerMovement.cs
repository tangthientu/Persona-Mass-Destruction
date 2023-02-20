using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
                    
    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;
    [HideInInspector]
    public Vector2 moveDir;
    [HideInInspector]
    public Vector2 lastMovedVector;
    //ref
    //public CharacterScriptableObject characterData;
    PlayerStats player;
    

    void Start()
    {
        player=GetComponent<PlayerStats>();
        rb = GetComponent<Rigidbody2D>();
        lastMovedVector = new Vector2(1,0f);// khong de last move trong neu khong dung yen se khong tan cong
    }

    // Update is called once per frame
    void Update()
    {
        InputManagement();
    }
    void FixedUpdate()
    {
        Move();
    }

       // ham input nut di chuyen
    void InputManagement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;
        if (moveDir.x != 0)
        {
            lastHorizontalVector = moveDir.x;
            lastMovedVector = new Vector2(lastHorizontalVector, 0f); //luu lai lan gan nhat cua x
        }
        if (moveDir.y != 0)
        {
            lastVerticalVector = moveDir.y;
            lastMovedVector = new Vector2(0f, lastVerticalVector);// luu lai y
        }
        if(moveDir.x!=0 && moveDir.y!=0)
        {
            lastMovedVector = new Vector2(lastHorizontalVector, lastVerticalVector);//luu ca x va y lai vao lastmovedvector khi di chuyen
        }
    }
    //ham di chuyen
    void Move()
    {
        rb.velocity = new Vector2(moveDir.x * player.currentMoveSpeed, moveDir.y * player.currentMoveSpeed);
    }
}
