using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorExit : MonoBehaviour
{
    public GameObject Canvas;
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "finger_ring_2_r")
            
        
            print(other.name + "  c " + other.tag );
        if (other.tag == "Player")
        {
            Canvas.SetActive(true);
            Config.leaveBuilding = true;
        }
        else if (other.tag == "NPC")
        {
            other.gameObject.SetActive(false);
        }
    }
}