using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Bird has additional User Layer 3, so it will check if the object that passed is actually a Bird
        if (collision.gameObject.layer == 3 && logic.birdIsAlive == true)
        {
            logic.addScore(1);
        }
    }
}
