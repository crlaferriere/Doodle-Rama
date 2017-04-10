using UnityEngine;
using System.Collections;

public class PurpleBarrier : MonoBehaviour {

	public GameObject Boulder; 


	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D col) {

		if (col.gameObject.name == "purple_boulder") {

			Destroy (this.gameObject); 
			Destroy (Boulder); 

		}


	}

}
