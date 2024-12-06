using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_main : MonoBehaviour
{
    public Vector3 playerLocation;


    private void Update()
    {
        playerLocation = transform.position;    
    }


}
