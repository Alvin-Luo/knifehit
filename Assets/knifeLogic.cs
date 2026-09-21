using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * code for knife prefab object
 */

public class knifeLogic : MonoBehaviour
{
    private bool hit = false;
    
    public int scoreToAdd;

    public Rigidbody2D rb;
    private logic logic;

    // Start is called before the first frame update
    void Start()
    {
        // set rb to the Rigidbody of the current gameObject
        rb = GetComponent<Rigidbody2D>();

        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<logic>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (hit) return;

        // if target hit, attach object
        if (other.gameObject.CompareTag("Target")) {

            AttachObject(other.transform);
            logic.addScore(scoreToAdd);
        }

        // if thrown knife hits attached knife, game over
        else if (other.gameObject.CompareTag("Attached")) {
            logic.gameOver();

            // stop physics movement of knife once game ends
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.isKinematic = true;
        }

            
    }

    void AttachObject(Transform target)
    {
        // stop physics movement once knife hits the target
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.isKinematic = true;

        // connect knife and target
        transform.SetParent(target);

        hit = true;

        gameObject.tag = "Attached";
    }

}
