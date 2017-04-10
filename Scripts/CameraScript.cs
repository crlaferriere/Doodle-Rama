using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public float speed = 2.0f;
	public float zoomSpeed = 2.0f;

	public float minX = -360.0f;
	public float maxX = 360.0f;

	public float minY = -45.0f;
	public float maxY = 45.0f;

	public float sensX = 100.0f;
	public float sensY = 100.0f;


   	float zoomSize = 5f;
    public float zoomMin, zoomMax, maxRight, maxLeft, maxUp, maxDown;
    public GameObject Player, paintSpawner; 


	void Update () {
    
        if (Input.GetAxis("Mouse ScrollWheel") > 0) {

            if (zoomSize > zoomMin)
            {
                zoomSize -= 1;
            }
       }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (zoomSize < zoomMax)
            {
                zoomSize += 1;
            }

        }

        if (paintSpawner.GetComponent<StateChangePaint>().canPaint == false)
        {
            transform.LookAt(Player.transform.position);
        }


        if (Input.GetKey(KeyCode.D) && transform.position.x < maxRight){
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.A) && transform.position.x > maxLeft){
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.W) && transform.position.y < maxUp){
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
		if (Input.GetKey(KeyCode.S) && transform.position.y > maxDown){
            transform.position += Vector3.down * speed * Time.deltaTime;
        }

        //if (Input.GetMouseButton (0)) {
        //	rotationX += Input.GetAxis ("Mouse X") * sensX * Time.deltaTime;
        //	rotationY += Input.GetAxis ("Mouse Y") * sensY * Time.deltaTime;
        //	rotationY = Mathf.Clamp (rotationY, minY, maxY);
        //	transform.localEulerAngles = new Vector3 (-rotationY, rotationX, 0);
        //}
        GetComponent<Camera>().orthographicSize = zoomSize; 
    }

    
}
