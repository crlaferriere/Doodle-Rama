using UnityEngine;
using System.Collections;

public class TriggerupSpikes : MonoBehaviour {

	public GameObject spike; 
	private SpikesUp SpikeUp; 


	void Start () {

		SpikeUp = spike.GetComponent<SpikesUp>();
		SpikeUp.enabled = false; 

	}

	// Update is called once per frame
	void Update () {



	}

	void OnTriggerEnter2D (Collider2D col) {

		if (col.gameObject.tag == "Player") {

			SpikeUp.enabled = true; 

		}

	}

}

