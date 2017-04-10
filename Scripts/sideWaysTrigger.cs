using UnityEngine;
using System.Collections;

public class sideWaysTrigger : MonoBehaviour {

	public GameObject SidewaysHazard; 
	private TriggerSideways moveSideways; 


	void Start () {
			
		moveSideways = SidewaysHazard.GetComponent<TriggerSideways>();
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
