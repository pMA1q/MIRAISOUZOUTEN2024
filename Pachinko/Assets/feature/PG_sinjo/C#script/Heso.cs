using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heso : MonoBehaviour
{
    readonly int MAX_STOCK = 4;
    public List<int[]> stock = new List<int[]>();
    [SerializeField]
    GameObject[] stockObjects = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    ///’Š‘I
    
    void Lottery()
    {
        if (stock.Count != MAX_STOCK)
        {
            var i = new int[] { Random.Range(1, 9), Random.Range(1, 9), Random.Range(1, 9), };
            stock.Add(i);
            foreach (var v in stockObjects)
            {
                if(!v.activeInHierarchy)
                {
                    v.SetActive(true);
                    break;
                }
            }
        }
    }

    public void DisableStock()
    {
        stock.RemoveAt(0);
        for(int i = stockObjects.Length; i > 0; i--)
        {
            if (stockObjects[i-1].activeInHierarchy)
            {
                stockObjects[i-1].SetActive(false);
                break;
            }
        }
    }
}
