using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Valve.VR;
using Valve.VR.InteractionSystem;


public class EndGame : MonoBehaviour
{
    public Text Result;
    public Text pLAYERResult;
    public GameObject DelPlayer;

    private void OnEnable()
    {
        Result.text = pLAYERResult.text;
        Config.lastResults = pLAYERResult.text.ToString();
    }
    
    public void OnClickExit()
    {
        Destroy(DelPlayer);
        // Get all root GameObjects in the scene
        Throwable[] objectsWithScript = FindObjectsOfType<Throwable>();
        
        // Удаляем каждый найденный объект
        foreach (Throwable obj in objectsWithScript)
        {
            Destroy(obj.gameObject);
        }
   
        
        // Загружаем следующую сцену по индексу
        SceneManager.LoadScene(0);
        Config.saveGame();
       Config.DelBool();
        //   Config.Result = Result.text.ToString();
    }
    void Start()
    {
      
    }

    bool IsDontDestroyOnLoad(GameObject obj)
    {
        // Check if the GameObject has DontDestroyOnLoad flag
        return obj.scene.name == null;
    }

}
