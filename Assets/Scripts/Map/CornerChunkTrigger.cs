using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerChunkTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    MapController mc;

    public GameObject targetMap;
    void Start()
    {
        mc = FindObjectOfType<MapController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mc.currentChunk = targetMap;

            Debug.Log("enter");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (mc.currentChunk == targetMap)
            {
                mc.currentChunk = null;
                Debug.Log("spawn");
                gameObject.SetActive(false);
            }
        }
    }

}
