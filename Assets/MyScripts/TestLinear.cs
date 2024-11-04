using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.Extras;
public class TestLinear : MonoBehaviour
{
    public Valve.VR.InteractionSystem.LinearMapping linearMapping;

    [SerializeField] private bool isCreate;
    public GameObject gameObject;
    public Transform pos;
    // Start is called before the first frame update
    void Start()
    {
        isCreate = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(linearMapping.value >= 0.95f && isCreate)
        {
            isCreate = !isCreate;
            GameObject newObj = Instantiate(gameObject, pos.position, pos.rotation);
        }
        else if(linearMapping.value <= 0.05f && !isCreate)
        {
            isCreate = !isCreate;
        }
    }
}
