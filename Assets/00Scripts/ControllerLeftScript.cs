using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class ControllerLeftScript : MonoBehaviour
{
    private SteamVR_Action_Boolean mPinch;
    private SteamVR_Behaviour_Pose mPose;
    public bool isUp;

    [SerializeField] SteamVR_Input_Sources hand;
    [SerializeField] SteamVR_Action_Boolean action;
    public GameObject ListTaskCanvas;


    void Awake()
    {
        mPinch = SteamVR_Actions._default.GrabPinch;
        mPose = GetComponent<SteamVR_Behaviour_Pose>();
    }

    private void Update()
    {
        if (action.GetStateUp(hand) && !isUp)
        {
            isUp = true;
        }
        else if( action.GetStateUp(hand) && isUp )
        {
            isUp = false;
        } 

        if (isUp)
        {
            ListTaskCanvas.SetActive(true);
        }
        else
        {
            ListTaskCanvas.SetActive(false);
        }
    }
    
}