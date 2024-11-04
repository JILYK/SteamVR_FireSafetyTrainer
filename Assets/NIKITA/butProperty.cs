using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class butProperty : MonoBehaviour
{
    public bool isTry;
    public void clickBut()
    {
        if (isTry)
        {
            print("все ок идем дальше");
            StartCoroutine(enumerator_1());
            
        }
        else
        {
            print("не ну это ашибка");
            StartCoroutine(enumerator_1());
        }
    }
    IEnumerator enumerator_1()
    {
        foreach (Button but in Otvet.sing.butList)
        {
            but.interactable = false;
        }
        if (!isTry)
        {
            this.gameObject.GetComponent<Button>().image.color = new Color(255, 0, 0);
           
            yield return new WaitForSeconds(0.8f);
        }
        else
        {
            this.gameObject.GetComponent<Button>().image.color = new Color(0, 255, 0);
            yield return new WaitForSeconds(0.8f);
        }
        this.gameObject.GetComponent<Button>().image.color = new Color(255, 255, 255);
        Otvet.sing.UIcontent();
        foreach (Button but in Otvet.sing.butList)
        {
            but.interactable = true;
        }
        yield return null;
    }
}
