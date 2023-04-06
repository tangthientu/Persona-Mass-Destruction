using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRateManager : MonoBehaviour
{
    // Start is called before the first frame update
    [System.Serializable]
    public class Drops
    {
        public string name;//ten vat pham
        public GameObject itemPrefabs;//prefab cua no
        public float dropRate;//ty le drop
    }
    public List<Drops> drops;

    void OnDestroy()
    {
        if(!gameObject.scene.isLoaded)
        {
            return;
        }
        float randomNumber = UnityEngine.Random.Range(0f, 100f);//tu 0 den 100% Ty le drop
        List<Drops> possibleDrops = new List<Drops>();
        foreach(Drops rate in drops)
        {
            if(randomNumber<=rate.dropRate)//random so tu 0 den 100, neu nho hon thi drop.VD:25% drop rate thi neu random ra so duoi 25 thi drop
            {
                possibleDrops.Add(rate);
            }
        }
        if (possibleDrops.Count>0)//neu co the drop hon 1 mon do 
        {
            Drops drops = possibleDrops[UnityEngine.Random.Range(0,possibleDrops.Count)];//random cac mon se drop
            Instantiate(drops.itemPrefabs, transform.position, Quaternion.identity);//drop do  
        }

        
    }
}
