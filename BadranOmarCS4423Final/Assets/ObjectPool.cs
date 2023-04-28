using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
public static ObjectPool SharedInstance {get; private set;}
public List<GameObject> pooledObjects;
public GameObject objectToPool;
public int amountToPool;

void Awake()
{
    if (SharedInstance != null && SharedInstance != this) 
    { 
        Destroy(this); 
    } 
    else 
    { 
        SharedInstance = this; 
    } 
}

void Start()
{
    pooledObjects = new List<GameObject>();
    GameObject tmp;
    for(int i = 0; i < amountToPool; i++)
    {
        tmp = Instantiate(objectToPool);
        tmp.SetActive(false);
        pooledObjects.Add(tmp);
    }
}


public GameObject GetPooledObject()
{
    if (LevelOneScript.paused == true){
        return null;
    }
    for(int i = 0; i < pooledObjects.Count; i++)
    {
        if(!pooledObjects[i].activeInHierarchy)
        {
            return pooledObjects[i];
        }
    }
    return null;
}


}
