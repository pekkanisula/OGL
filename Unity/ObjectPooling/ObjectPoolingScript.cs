//Created by Pekka Nisula
//Based on the Unity Tutorial: https://unity3d.com/learn/tutorials/topics/scripting/object-pooling
//Add this script to ObjectPooler GameObject

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ObjectPoolingScript : MonoBehaviour {
    
    public static ObjectPoolingScript current;
    public GameObject pooledObject;
    public int pooledAmount = 20;

    //Allows list of the pooled objects to grow when the pooled amount isn't enough.
    public bool willGrow = true;

    //List of the pooled objects
    public List<GameObject> pooledObjects;	

    void Awake()
    {
        current = this;
    }
    //Instantiates the list full of GameObjects
	void Start () {
        pooledObjects = new List<GameObject>();
        for (int i=0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
	}
    //Gets any available pooledObject, if will grow is enabled creates new object.
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        if (willGrow)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            pooledObjects.Add(obj);
        }
        return null;
    }
}
