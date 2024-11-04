using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDurka : MonoBehaviour
{
    //public static TextDurka sing;
    public  static Text textovoePole;

    public GameObject phone;

    public GameObject panelDialog;
    public GameObject panelVazov;
    private void Awake()
    {
        textovoePole = this.gameObject.GetComponent<Text>();
        print(this.gameObject.name);
    }
    public void vazov()
    {

        if (textovoePole.text == "#01")
        {
            print("�� � �����");
            panelDialog.SetActive(true);
            panelVazov.SetActive(false);
            phone.SetActive(false);
        }
        else
        {
            print("������ ������ �����");
            textovoePole.text = "";
        }
    }
    public void deleteClick()
    {
        textovoePole.text = textovoePole.text.Remove(textovoePole.text.Length - 1);
    }
}
