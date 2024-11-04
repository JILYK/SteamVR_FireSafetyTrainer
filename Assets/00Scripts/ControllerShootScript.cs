using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class ControllerShootScript : MonoBehaviour
{

    private SteamVR_Action_Boolean mPinch;
    private SteamVR_Behaviour_Pose mPose;
    public bool isUp;
    public GameObject powder;
    
    [SerializeField] SteamVR_Input_Sources hand;
    [SerializeField] SteamVR_Action_Boolean action;


    void Awake()
    {
        mPinch = SteamVR_Actions._default.GrabPinch;
        mPose = GetComponent<SteamVR_Behaviour_Pose>();
    }

    private void Update()
    {
        // if (Input.GetMouseButtonDown(0))
        // {
        //     print("FIRE");
        //     if (isUp)
        //     {
        //         powder.GetComponent<Extinguisher>().Shoot();
        //     }
        //     else
        //     {
        //         powder.GetComponent<Extinguisher>().DontShoot();
        //     }
        // }

        if (action.GetState(hand))
        {
            print("!!!!!11111");
            if (isUp)
            {
                powder.GetComponent<Extinguisher>().Shoot();
                return;
            }   
        }
        
            print("---------------!!!!!222222");
            powder.GetComponent<Extinguisher>().DontShoot();
        
    }

    public void pickUp()
    {
        isUp = true;
    }

    public void putDown()
    {
        isUp = false;
    }
}
