using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Otvet : MonoBehaviour
{
    public static Otvet sing;
    public Text textVopros;
    public List<Button> butList = new List<Button>();
    public List<vopros> varriant;
    public int nombervopros = 0;
    private void Awake()
    {
        if (sing == null)
        {
            sing = this;
        }
    }
    private void Start()
    {
        UIcontent();
    }
    public  void UIcontent()
    {
        if (nombervopros >= varriant.Count) {
            this.gameObject.SetActive(false);
            Config.callFirefighters = true;
            return;
        }
        textVopros.text = varriant[nombervopros].vopr;
            ;
        for (int k = 0; k < butList.Count; k++)
        {
            butList[k].gameObject.GetComponent<butProperty>().isTry = varriant[nombervopros].varriant[k].isGoodOtv;
            butList[k].gameObject.GetComponentInChildren<Text>().text = varriant[nombervopros].varriant[k].Otv;
        }
        nombervopros++;
    }
}

[System.Serializable]
public struct otvetici
{
    public string Otv;
    public bool isGoodOtv;
}
[System.Serializable]
public struct vopros
{
    public string vopr;
    public List<otvetici> varriant;
}
