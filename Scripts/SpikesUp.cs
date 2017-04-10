using UnityEngine;
using System.Collections;

public class SpikesUp : MonoBehaviour {

	public float moveSpeed; 

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.position +=  new Vector3 (0f, moveSpeed, 0f); 
	
	}
}
