using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePaint : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            GetComponent<BoxCollider2D>().isTrigger = true;

        } else if (other.gameObject.CompareTag("Player"))

        {
            GetComponent<BoxCollider2D>().isTrigger = false;
        }

        if (other.gameObject.CompareTag("Restart"))
        {
            other.gameObject.GetComponent<Rigidbody2D>().gravityScale = .2f;
            other.gameObject.GetComponent<SpriteRenderer>().color = Color.blue; 
        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<BoxCollider2D>().isTrigger = false;

        }
    }

    void OnTriggerStay2D (Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            GetComponent<BoxCollider2D>().isTrigger = true;

        } else {
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
}
