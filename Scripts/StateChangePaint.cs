using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StateChangePaint : MonoBehaviour {

    public GameObject Paint, Camera, Player, goButton, Eisel, scoreText;
    private CameraScript cameraScript;
    private PaintSpawn paintSpawn;
    private BasicMovement playerMovement;
    public bool canPaint, canMove; 
	public Camera paintcamera, movecamera;
    public GameObject[] sawBlades;
    public GameObject greengoal; 

    enum States
    {
        Paint, Move

    };

    States currentState = States.Paint;

    void Start()
    {

        cameraScript = Camera.GetComponent<CameraScript>();
        paintSpawn = Paint.GetComponent<PaintSpawn>();
        playerMovement = Player.GetComponent<BasicMovement>();
        ChangeStates(States.Paint);
        paintcamera.enabled = true;
        movecamera.enabled = false;
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "Level1 Tutorial4")
        {
            sawBlades[0].GetComponent<SawBlades>().enabled = false;
            sawBlades[1].GetComponent<SawBlades>().enabled = false;
            sawBlades[0].GetComponent<PolygonCollider2D>().enabled = false;
            sawBlades[1].GetComponent<PolygonCollider2D>().enabled = false;

        } else {

            sawBlades = null; 
        }

        if (sceneName == "Level1 Tutorial5")
        {
            greengoal.GetComponent<Rigidbody2D>().gravityScale = 0;  

        } else {
            greengoal = null; 
        }
        

    }
	
	
	void Update () {

        if (canPaint == true)
        {
            ChangeStates(States.Paint);

        } else if (canPaint == false)
        {
            ChangeStates(States.Move); 
        }


    }

    void ChangeStates(States newState)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (currentState == newState)
        {
            return;

        }

        switch (newState)
        {
            case States.Paint:
                {
                    paintSpawn.enabled = true;
                    cameraScript.enabled = true;
                    playerMovement.enabled = false;

                    break;
                }
            case States.Move:
                {
                    paintSpawn.enabled = false;
                    cameraScript.enabled = false;
                    playerMovement.enabled = true;  
					goButton.SetActive (false); 
					Eisel.SetActive (false);
                    if (sceneName == "Level1 Tutorial4")
                    {
                        sawBlades[0].GetComponent<SawBlades>().enabled = true;
                        sawBlades[1].GetComponent<SawBlades>().enabled = true;
                        sawBlades[0].GetComponent<PolygonCollider2D>().enabled = true;
                        sawBlades[1].GetComponent<PolygonCollider2D>().enabled = true;
                    }
                    if (sceneName == "Level1 Tutorial5")
                    {
                        greengoal.GetComponent<Rigidbody2D>().gravityScale = 0.3f; 
                    }
                    break;
                }

            default:
                {
                    Debug.Log("asdf"); 
                    return;
                }
               }

        currentState = newState;


        }

   public void ButtonPress ()
    {
        canPaint = false; 
		movecamera.enabled = true; 
		paintcamera.enabled = false; 
	}

}


