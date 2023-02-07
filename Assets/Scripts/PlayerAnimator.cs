using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    // Start is called before the first frame update

    Animator am;
    PlayerMovement pm;
    SpriteRenderer sr;

    void Start()
    {
        am = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Doi bool trong animator khi x hoac y khac 0
        if(pm.moveDir.x !=0 || pm.moveDir.y !=0)
        {
            am.SetBool("Move",true);
        }
        else
            am.SetBool("Move",false);

        SpriteDirectionChecker();
    }
      //Ham kiem tra huong facing cua sprite
    void SpriteDirectionChecker()
    {
        if (pm.lastHorizontalVector<0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
            
    }
}
