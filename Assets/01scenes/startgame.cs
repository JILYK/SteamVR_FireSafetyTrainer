using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class startgame : MonoBehaviour
{
    public Text LastResText;
    public GameObject PLayer;

    private void Awake()
    {
        Debug.Log($"11111111111111111111 Detector: {Config.detector}, Map: {Config.map}, Door: {Config.door}, Extinguisher: {Config.extinguisher}, CallFirefighters: {Config.callFirefighters}, PressFireAlarm: {Config.pressFireAlarm}, CheckForPeople: {Config.checkForPeople}, ExtinguishFire: {Config.extinguishFire}, LeaveBuilding: {Config.leaveBuilding}");

        Config.detector = false;
        Config.map = false;
        Config.door = false;
        Config.extinguisher = false;
        Config.callFirefighters = false;
        Config.pressFireAlarm = false;
        Config.checkForPeople = false;
        Config.extinguishFire = false;
        Config.leaveBuilding = false;
        Debug.Log($"22222222222222222222 Detector: {Config.detector}, Map: {Config.map}, Door: {Config.door}, Extinguisher: {Config.extinguisher}, CallFirefighters: {Config.callFirefighters}, PressFireAlarm: {Config.pressFireAlarm}, CheckForPeople: {Config.checkForPeople}, ExtinguishFire: {Config.extinguishFire}, LeaveBuilding: {Config.leaveBuilding}");
     
    }

    void Start()
    {
        LastResText.text = PlayerPrefs.GetString("lastResults");
        // Get all root GameObjects in the scene
        GameObject finger_ring_2_r = GameObject.Find("finger_ring_2_r");
        finger_ring_2_r.tag = "Task";
       
        var children =  PLayer.GetComponentsInChildren<Transform>();;
        foreach (var child in children)
        {
            if (child.tag != "Task")
            {
                child.tag = "Task";
            }
        }
    }

    bool IsDontDestroyOnLoad(GameObject obj)
    {
        // Check if the GameObject has DontDestroyOnLoad flag
        return obj.scene.name == null;
    }

    public void startGameMethod()
    {
        PLayer.transform.position = new Vector3(7.007f, -0.098f, 4.614f);

        GameObject finger_ring_2_r = GameObject.Find("finger_ring_2_r");
        finger_ring_2_r.tag = "Task";
    }
}