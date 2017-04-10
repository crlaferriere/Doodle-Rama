using UnityEngine;
using System.Collections;

public class EnemyFollow : MonoBehaviour {

	public Transform target;
	public int moveSpeed;
	public int rotationSpeed;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		//trigger this when player enters the last large circle. Enemies should not follow until they enter the circle
		if (target != null){
			Vector3 dir = target.position - transform.position;

			dir.z = 0.0f;
			if (dir != Vector3.zero)
			{
				transform.rotation = Quaternion.Slerp (transform.rotation,
					Quaternion.FromToRotation (Vector2.right, dir),
					rotationSpeed * Time.deltaTime);

				transform.position += (target.position - transform.position).normalized
					* moveSpeed * Time.deltaTime;
			}
		}
	}

	/*public void OnTriggerEnter2D (Collider2D coll){
		if (coll.gameObject.tag == "Player") {
			if (target != null){
				Vector3 dir = target.position - transform.position;

				dir.z = 0.0f;
				if (dir != Vector3.zero)
				{
					transform.rotation = Quaternion.Slerp (transform.rotation,
						Quaternion.FromToRotation (Vector2.right, dir),
						rotationSpeed * Time.deltaTime);

					transform.position += (target.position - transform.position).normalized
						* moveSpeed * Time.deltaTime;
				}
			}
		}

	}*/
}
