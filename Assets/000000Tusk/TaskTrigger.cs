using System;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class TaskTrigger : MonoBehaviour
{
    public GameObject canvasTask; // Подключи CanvasTask через инспектор
    public GameObject Collider; // Подключи CanvasTask через инспектор
    public GameObject Steclo; // Подключи CanvasTask через инспектор
    public GameObject VosclicatelniyZnak; // Подключи CanvasTask через инспектор
    public Config.ConfigVariables configVariable; // Перечисление переменных из Config

    private void Start()
    {
        Collider.SetActive(true);
        Steclo.SetActive(true);
        VosclicatelniyZnak.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "finger_ring_2_r") other.tag = "Task";
        print(other.name + "     s     "  + other.tag);
        // Проверяем, что объект имеет тег "Task" и соответствующая переменная установлена в false
        if (other.CompareTag("Task") && !Config.GetVariable(configVariable))
        {
            canvasTask.SetActive(true);
        }
    }


    public GameObject BoxF;
    public void OnYesButton()
    {
        Config.SetVariable(configVariable, true);
        print("BOXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
         if(configVariable == Config.ConfigVariables.Extinguisher) BoxF.SetActive(true);
        
        CheckAllVariables();
        canvasTask.SetActive(false);
     //  Destroy(canvasTask);
       GameObject CanvasEn = GameObject.Find("CanvasTaskList");
 CanvasEn.SetActive(false);
 CanvasEn.SetActive(true);

    }

    public void OnNoButton()
    {
        canvasTask.SetActive(false);
    }

    void CheckAllVariables()
    {
        if (Config.AllVariablesTrue())
        {
            Collider.SetActive(false);
            Steclo.SetActive(false);
            VosclicatelniyZnak.SetActive(true);
        }
    }
}