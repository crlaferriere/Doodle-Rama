using UnityEngine;
using System.Collections;

	public class ScoreScript : MonoBehaviour {

		static public void RegisterScore(float newScore)
		{

			// set score for last play
			PlayerPrefs.SetFloat("Last Score", newScore);

			// if new high
			if (newScore > PlayerPrefs.GetFloat("High Score"))
		{
				
				PlayerPrefs.SetFloat("High Score", newScore);
			}
		}
	}