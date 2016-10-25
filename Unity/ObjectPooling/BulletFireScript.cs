//Created by Pekka Nisula
//Based on the Unity Tutorial: https://unity3d.com/learn/tutorials/topics/scripting/object-pooling
//Add this script to your bullet GameObject

using UnityEngine;
using System.Collections;

public class BulletFireScript : MonoBehaviour {

    public float fireTime = 0.5f;

	//Every 0.5 seconds Fire function is launched.
	void Start () {
        InvokeRepeating("Fire", fireTime, fireTime);
	}

    //Gets new available pooled object from ObjectPoolingScript and activates it.
    void Fire()
    {
        GameObject obj = ObjectPoolingScript.current.GetPooledObject();
        if (obj == null) 
            return;

        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
    }
}
