using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZvonokVDurku : MonoBehaviour
{
    // Start is called before the first frame update
    public void clickBut()
    {
        print(this.gameObject.GetComponentInChildren<Text>().text.ToString());
        //print(TextDurka.textovoePole.gameObject.name);
        TextDurka.textovoePole.text += this.gameObject.GetComponentInChildren<Text>().text.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
