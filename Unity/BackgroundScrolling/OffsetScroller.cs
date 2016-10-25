//Created by Pekka Nisula
//Based on the Unity Tutorial: https://unity3d.com/learn/tutorials/topics/2d-game-creation/2d-scrolling-backgrounds
//Add this script to Background Quad GameObject (Does not work with sprite, has to be quad)
//Background image has to be texture (unlit/Texture).

using UnityEngine;
using System.Collections;

public class OffsetScroller : MonoBehaviour {

    public float scrollSpeed;
    private Vector2 savedOffset;
    
    //Saves the offset at Start
    void Start () {
        savedOffset = this.GetComponent<Renderer>().sharedMaterial.GetTextureOffset("_MainTex");
	}
	
	//Defines the scrolling speed and axis, and updates the background
	void Update () {
        float x = Mathf.Repeat(Time.time * scrollSpeed, 1);
        Vector2 offset = new Vector2(x, savedOffset.y);        
        this.GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
	}
    //At the end we will set the saved offset back to the main texture. Otherwise it would leave to it's current place.
    void OnDisable()
    {
        this.GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", savedOffset);
    }
}
