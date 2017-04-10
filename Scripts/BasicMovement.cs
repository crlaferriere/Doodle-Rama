using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BasicMovement : MonoBehaviour {

	public float moveSpeed;
	public float jumpforce;
	public LayerMask Ground; 
	public Camera playercamera;
	public GameObject player;
	public bool grounded;
	private Rigidbody2D myRigidbody;
	private Collider2D myCollider;
	private SpriteRenderer mySpriteRenderer; 
	public Vector2 prevPos;
	Animator anim;
	public bool canMove; 
	public float delay; 
	
    
	void Start () {
        #region Initialized Movement Variables
        mySpriteRenderer = GetComponent<SpriteRenderer>();
		mySpriteRenderer.color = new Color (37f/255f, 172f/255f, 249f/255f, 1f);
		myRigidbody = GetComponent<Rigidbody2D>();
		myCollider = GetComponent<Collider2D> ();
		anim = GetComponent<Animator> ();
		playercamera.transform.parent = player.transform;
		grounded = false; 
		canMove = true;
        #endregion
    }

    
    void Update () {
        //movement logic and speed variables
        prevPos = transform.position;
		grounded = Physics2D.IsTouchingLayers (myCollider, Ground);

        if (Input.GetKeyDown (KeyCode.W) && canMove == true) {
			if (grounded == true) {
                myRigidbody.velocity = new Vector2(0, jumpforce * 2);
                anim.SetTrigger ("jump");
			}
		}

        if (Input.GetKey (KeyCode.A) && canMove == true) {
			this.transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            mySpriteRenderer.flipX = true;			
		}

		if (Input.GetKey (KeyCode.D) && canMove == true) {
			this.transform.position += Vector3.right * moveSpeed * Time.deltaTime;
			mySpriteRenderer.flipX = false;
		}
    
		float xSpeed = transform.position.x - prevPos.x;

		if (grounded == true) {
			anim.SetFloat ("moveSpeed", Mathf.Abs (xSpeed));
		}

		if (Input.GetKey (KeyCode.R)) {
			Application.LoadLevel (Application.loadedLevel);
		}
	}

    void OnCollisionEnter2D(Collision2D col) {

        //if the player touches yellow paint increase their jump force
        if (col.gameObject.tag == "Yellow") {
            jumpforce = 10;
            moveSpeed = 3f;
            mySpriteRenderer.color = new Color(249f / 255f, 212f / 255f, 35f / 255f, 1f);
        }

        //if the player touches red paint increase their speed
        if (col.gameObject.tag == "Red") {
            moveSpeed = 4.5f;
            mySpriteRenderer.color = Color.red;
        }

        //if the player touches blue paint, change their color as this paint is for hazards
        if (col.gameObject.tag == "Blue") {
            mySpriteRenderer.color = new Color(37f / 255f, 172f / 255f, 249f / 255f, 1f);
        }

        // if you are touching any of these move normal
        if (!col.gameObject.CompareTag("Red")) {
			moveSpeed = 3f;
		}

        //if you are touching these jump normal
		if (!col.gameObject.CompareTag("Yellow")) {
			jumpforce = 6; 
		}

			
		//When player hits object tagged "Goal" scene will progress based on the index number
		if (col.gameObject.tag == "Goal") {
			canMove = false; 
			moveSpeed = 0; 
			jumpforce = 0; 
			anim.SetTrigger ("Win");
			anim.SetTrigger ("Win2");
			StartCoroutine("NextLevel");
		}

        //if the player hits an object tagged as restart, restart the level
		if (col.gameObject.tag == "Restart" || col.gameObject.tag == "Grav") {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex); 
		}
	
	}

    //co-routine for starting the next level
	public IEnumerator NextLevel() {
		yield return new WaitForSeconds (delay - 2); 
	    SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}
}