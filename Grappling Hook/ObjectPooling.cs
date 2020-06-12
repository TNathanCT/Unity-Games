using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public GameObject PooledObject;
    public int pooledAmount;

    List<GameObject> pooledobjects;

    void Start()
    {
        pooledobjects = new List<GameObject>();

        for(int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(PooledObject);
            obj.SetActive(false);
            pooledobjects.Add(obj); 
        }
    }

    public GameObject GetPooledObject()
    {

        for (int i = 0; i < pooledobjects.Count; i++) {

            if (!pooledobjects[i].activeInHierarchy)
            {
                return pooledobjects[i];
            }
        }

        GameObject obj = (GameObject)Instantiate(PooledObject);
        obj.SetActive(false);
        pooledobjects.Add(obj);
        return obj;




    }
}
