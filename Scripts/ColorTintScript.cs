using UnityEngine;
using System.Collections;

public class ColorTintScript : MonoBehaviour {

	public Color color1 = Color.red;
	public Color color2 = Color.blue;
	public Color color3 = Color.yellow;
	public float duration = 1.0F;
	public float step = 0;

	//Camera camera;
	//void Start() {
	//	camera = GetComponent<Camera> ();
	//	camera.clearFlags = CameraClearFlags.SolidColor;
	//}
	//void Update() {
		//Debug.Log ("I'm in the update");
		//if (step < 5) {
		//	Debug.Log ("In step less than 5");
		//	float t = Mathf.PingPong (Time.time, duration) / duration;
		//	camera.backgroundColor = Color.Lerp (color1, color2, t);
		//	step += Time.deltaTime / duration;
		//	Debug.Log ("Reached First Loop");
	//	}
		//if (step >= 5 && step < 10) {
		//	Debug.Log ("In step less than 10");
		//	float t = Mathf.PingPong (Time.time, duration) / duration;
		//	camera.backgroundColor = Color.Lerp (color2, color3, t);
		//	step += Time.deltaTime / duration;
			//Debug.Log ("Reached Second Loop");
	//	}

	//	if (step >= 10 && step < 15) {
			//Debug.Log ("In step less than 15");
		//	float t = Mathf.PingPong (Time.time, duration) / duration;
		//	camera.backgroundColor = Color.Lerp (color3, color1, t);
		//	step += Time.deltaTime / duration;
		//	//Debug.Log ("Reached Third Loop");
		//}
		//if (step >= 15) {
			//Debug.Log ("Im greater than 15");
			//step = 0;
			//Debug.Log ("Reached Reset");
		//}
	//}
}
