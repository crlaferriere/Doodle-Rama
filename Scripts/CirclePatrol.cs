using UnityEngine;
using System.Collections;

public class CirclePatrol : MonoBehaviour {

	public Transform center;
	public float degreesPerSecond;

	private Vector3 v;

	// Use this for initialization
	void Start () {
		v = transform.position - center.position;
	}
	
	// Update is called once per frame
	void Update () {
		//Notes for personal use.
		//Quaternion is a rotation, does nothing by itself. Cannot assign one to a Vector3. 
		//Multiplying a Vector3 by a Quaternion results in a Vector3 rotated by the Quaternion.
		//Order in the algorithm matters.

		//Rotates circles on map
		v = Quaternion.AngleAxis (degreesPerSecond * Time.deltaTime, Vector3.forward) * v;
		transform.position = center.position + v;
	}


    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.CompareTag("Blue"))
        {
            if (degreesPerSecond < -30)
            {
                degreesPerSecond--; 
            }
        }
    }
}
