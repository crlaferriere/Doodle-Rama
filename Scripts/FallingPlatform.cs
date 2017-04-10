using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour {

	//Amount of time between the collision and the object's descent
	public float delay = 0f;

	public Rigidbody2D dropsWall;

	void Start(){
	}

	public void OnCollisionEnter2D (Collision2D col) 
	{
		//When the Player hits the switch, it switches the wall's rigidbody to Kinematic to false and falls off the map.
		if (col.collider.CompareTag("Player")) {
			//Debug.Log ("About to fall");
			GetComponent<AudioSource> ().Play ();
			StartCoroutine (Falling ());
			Destroy (GameObject.FindWithTag("DropWall"), 3f);

		}
	}
	//Coroutine that causes the object to fall
	public IEnumerator Falling(){
		//Debug.Log ("Entered Falling");
		yield return new WaitForSeconds (delay);
		dropsWall.isKinematic = false;
		GetComponent<Collider2D> ().isTrigger = true;
		yield return 0;
		Destroy (this.gameObject); 
	}

}