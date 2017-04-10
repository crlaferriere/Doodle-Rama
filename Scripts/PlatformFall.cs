using UnityEngine;
using System.Collections;

public class PlatformFall : MonoBehaviour {

	bool isFalling = false;
	float downSpeed = 0;

	void OnTriggerEnter(Collider collider){

		if (collider.gameObject.name == "Player") {
			isFalling = true;
			Destroy (gameObject, 10);
		}
	}
	// Update is called once per frame
	void Update () {
		if (isFalling) {
			downSpeed += Time.deltaTime/10;
			transform.position = new Vector2 (transform.position.x, transform.position.y-downSpeed);
	}
			

 }
}