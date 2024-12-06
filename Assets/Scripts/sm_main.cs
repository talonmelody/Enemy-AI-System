using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class sm_main : MonoBehaviour
{
    [SerializeField] enum states
    {
        Idle, Chasing, Patrol
        // Create an enum containing 3 states, serialized so it is availible in the editor
    }

    [SerializeField] states state;
    public Material idle;
    public Material attacking;
    public Material jumping;
    public GameObject player;
    public player_main pc;
    public float moveSpeed = 1.0f;

    private void Wake()
    {
        // Set state to Idle by default
        state = states.Idle; 
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && state != states.Patrol)
        {
           // When left click, state the state to Jumping
            ChangeState(states.Patrol);
        }

        if (Input.GetMouseButtonDown(1) && state != states.Chasing) 
        {
           // When right click, set the state to Attacking
            ChangeState(states.Chasing);
        }

        if (Input.GetKeyDown(KeyCode.W) && state != states.Idle)
        {
            // When W, set the state to Idle (Demonstration purposes)
            ChangeState(states.Idle);
        }

        HandleState();


    }

    void ChangeState(states newState)
    {
        state = newState; 
        // Set the state to the new state inputted into the method
        Debug.Log("Current State is: " + newState);
        // DEBUG: Log "Current state is:" + the current state
    }

    private void HandleState()
    {
        // Handles the state changes
        switch (state)
        {
                case states.Idle:
                Debug.Log("Idle State");
                GetComponent<MeshRenderer>().material = idle;
                // When the state becomes idle, do this
                break;

                case states.Patrol:
                Debug.Log("Patrol State");
                GetComponent<MeshRenderer>().material = attacking;
                // When the state becomes attacking, do this
                break;

                case states.Chasing:
                Debug.Log("Chasing State");
                GetComponent<MeshRenderer>().material = jumping;
                var step = moveSpeed * Time.deltaTime; 
                transform.position = Vector3.MoveTowards(transform.position, pc.playerLocation, step);
                // When the state becomes jumping, do this
                break;
        }



    }
    
}
