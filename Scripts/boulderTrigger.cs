using UnityEngine;
using System.Collections;

public class boulderTrigger : MonoBehaviour {


	public GameObject Boulder, boulderSpawn; 


	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col) {


		if (col.gameObject.tag == "Player") {

			GameObject boulder = Instantiate (Boulder);
			GetComponent<AudioSource> ().Play ();
			Boulder.transform.position = boulderSpawn.transform.position;
			Debug.Log ("asdf"); 

		}

	}

}
