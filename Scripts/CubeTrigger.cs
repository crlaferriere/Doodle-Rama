using UnityEngine;
using System.Collections;

public class CubeTrigger : MonoBehaviour {

	public GameObject greenCube; 
	private MoveCube moveSideways; 



	void Start () {
		moveSideways = greenCube.GetComponent<MoveCube>();
		moveSideways.enabled = false; 
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D col) {

		if (col.gameObject.tag == "Player") {

			moveSideways.enabled = true; 

		}

	}
}
