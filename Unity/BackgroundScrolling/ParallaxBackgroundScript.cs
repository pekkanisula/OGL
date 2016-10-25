//Created by Pekka Nisula
//Based on the Unity Tutorial: https://unity3d.com/learn/tutorials/topics/2d-game-creation/2d-scrolling-backgrounds
//You have to have two background sprites. Other one is child of the other background. Parent should have this script.

using UnityEngine;
using System.Collections;

public class ParallaxBackgroundScript: MonoBehaviour {
    public float scrollSpeed;
    public float tileSizeZ;

    private Vector3 startPosition;
	
	void Start () {
        startPosition = transform.position;
	}
	
	//Repeats the background
	void Update () {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.left * newPosition;
	}
}
