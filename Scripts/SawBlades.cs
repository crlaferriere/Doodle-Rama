using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBlades : MonoBehaviour {

    Rigidbody2D rb;
    private bool goUp;
    public float range;
    public float moveSpeed;
    private int RandomizeMovement;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (gameObject.name == "SawBladeVertical")
        {
            RandomizeMovement = Random.Range(0, 2);
        } 
        if (RandomizeMovement == 0) {
            goUp = true;
        }
        else if (RandomizeMovement == 1) {
            goUp = false;
        }
    }

    void Update()
    {

        if (goUp)
        {
            rb.velocity = new Vector2(0, 1) * moveSpeed;
        }
        else if (!goUp)
        {
            rb.velocity = new Vector2(0, 1) * -moveSpeed;

        }
        

        if (gameObject.name == "SawBladeVertical")
        {

            if (transform.position.y <= -range)
            {

                goUp = true;
            }

            if (transform.position.y >= range)
            {

                goUp = false;
            }

            transform.Rotate(Vector3.forward * -40);

            transform.Rotate(Vector3.forward * -40);

        }
    }


    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.CompareTag("Blue"))
        {
            if (moveSpeed >= 1)
            {
                moveSpeed -= .5f;
            }
        }
    }
}
