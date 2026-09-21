using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * code for logicManager object 
 */

public class spawnKnife : MonoBehaviour
{
    public GameObject knife;
    public GameObject spawner;

    private GameObject currentKnife;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        // check for input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shootKnife();

            spawn();
        }
    }

    private void shootKnife()
    {
        if (currentKnife == null) return;

        Rigidbody2D rb = currentKnife.GetComponent<Rigidbody2D>();

        rb.velocity = Vector2.down * speed;
    }

    public void spawn()
    {
        currentKnife = Instantiate(knife, spawner.transform.position, spawner.transform.rotation);
    }
}
