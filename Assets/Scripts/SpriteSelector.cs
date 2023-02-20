using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSelector : MonoBehaviour
{
    public static SpriteSelector instance;
    public Animator animator;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogWarning("Extra" + this + "deleted");
            Destroy(gameObject);
        }
    }

    public static Animator GetData()
    {
        return instance.animator;
    }

    public void SelectCharacter(Animator characterAnimator)
    {
        animator = characterAnimator;

    }
 

    public void DestroySingleton()
    {
        instance = null;
        Destroy(gameObject);
    }
}
