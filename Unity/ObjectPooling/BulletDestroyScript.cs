//Created by Pekka Nisula
//Based on the Unity Tutorial: https://unity3d.com/learn/tutorials/topics/scripting/object-pooling
//Add this script to your bullet GameObject
using UnityEngine;
using System.Collections;

public class BulletDestroyScript : MonoBehaviour {

    //Disables bullets after 2 seconds
    void OnEnable()
    {
        Invoke("Destroy", 2f);
    }
    //Doesn't destroy object, it disables it. 
    //When there is hundreds or thousands of objects create and destroy doesn't work so great.
    void Destroy()
    {
        gameObject.SetActive(false);
    }
    //When game is disabled, cancel invoke
    void OnDisable()
    {
        CancelInvoke();
    }
}
