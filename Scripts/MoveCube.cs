using UnityEngine;
using System.Collections;

public class MoveCube : MonoBehaviour {

	public float moveSpeed; 

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (gameObject.name != "green_goalgrav")
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }

	}


	void OnCollisionEnter2D(Collision2D col) {

		if (col.gameObject.tag == "Restart") {

            Destroy(this.gameObject); 
		}

        if (col.gameObject.tag == "CubeDestroyer")
        {
            Application.LoadLevel(Application.loadedLevel); 
        }

        if (col.gameObject.tag == "Grav")
        {
            GetComponent<Rigidbody2D>().gravityScale = -0.2f; 
        }
    }

}