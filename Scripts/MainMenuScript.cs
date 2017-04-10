using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

	public void startGame () {
		SceneManager.LoadScene ("Level1 Tutorial1");
	}

	public void toInstructions () {
		SceneManager.LoadScene ("Instructions");
	}

	public void toCredits () {
		SceneManager.LoadScene ("Credits");
	}

	public void toMainMenu () {
		SceneManager.LoadScene ("MainMenu");
	}

	public void toInstructions2 () {
		SceneManager.LoadScene ("Instructions2");
	}

	public void toInstructions3 () {
		SceneManager.LoadScene ("Instructions3");
	}
}
