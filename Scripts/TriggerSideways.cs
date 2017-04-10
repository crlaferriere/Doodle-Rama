using UnityEngine;
using System.Collections;

public class TriggerSideways : MonoBehaviour {

	public float moveSpeed; 


	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position +=  new Vector3 (-moveSpeed, 0f, 0f); 
			
	}

}
