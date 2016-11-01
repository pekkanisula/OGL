using UnityEngine;
using System.Collections;

public class FindGameObject : MonoBehaviour {

	public static int lastID = 0; //Static var that keeps track of which ID's have already been given out.
	public int ID; //Unique ID given to the object.


	void Start () {
		//Appoints a unique ID to this GameObject upon creation
		lastID++;
		ID = lastID;
	}

	/**
	 * A function that returns the gameobject with the requested ID if it is a child (or a child of a child etc.) of the given object. 
	 */
	public GameObject findCorrectPiece(int IDNumber, GameObject StartingObject){
		foreach (Transform child in StartingObject.transform) {
			if (child.gameObject.GetComponent<PieceID> () != null && child.gameObject.GetComponent<PieceID> ().ID == IDNumber)
				return child.gameObject;
			else {
				GameObject result;
				result = findCorrectPiece (IDNumber, child.gameObject);
				if (result != null)
					return result;
			}
		}

		return null;
	}
}
