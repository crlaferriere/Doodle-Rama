using UnityEngine;
using System.Collections;

public class TriggerFollow : MonoBehaviour {

	public Transform target;
	public int moveSpeed;
	public int rotationSpeed;
	public float delay;
	public GameObject follow1;
	public GameObject follow2;
	public GameObject follow3;


	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	public void OnTriggerEnter2D (Collider2D coll){
		if (coll.gameObject.tag == "Player") {
			follow1.SetActive (true);
//			follow2.SetActive (true);
			//follow3.SetActive (true);
		}
	}
}
