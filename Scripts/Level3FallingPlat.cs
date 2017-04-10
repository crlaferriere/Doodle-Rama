using UnityEngine;
using System.Collections;

public class Level3FallingPlat : MonoBehaviour {

	public float delay = 0.1f;

	public Rigidbody2D dropSpike;

	void Start(){
	}

	public void OnTriggerEnter2D (Collider2D coll) 
	{
		//An invisible trigger that causes the large spike to fall
		if (coll.gameObject.tag =="Player") {
			//Debug.Log ("About to fall");
			StartCoroutine (Falling ());
		}
	}
	//Coroutine that tells the spike to fall
	public IEnumerator Falling(){
		//Debug.Log ("Entered Falling");
		yield return new WaitForSeconds (delay);
		GetComponent<AudioSource> ().Play ();
		dropSpike.isKinematic = false;
		GetComponent<Collider2D> ().isTrigger = true;
		yield return 0;
	}
	//This code is commented out for later use
	//Destroy (GameObject.FindWithTag("Cone"), 5f);
}