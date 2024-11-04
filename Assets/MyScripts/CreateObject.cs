using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour
{
    public GameObject gameObject;
    public Transform pos;

    public List<GameObject> newObjects = new List<GameObject>();

    public void newObject()
    {
        GameObject newObj = Instantiate(gameObject, pos.position, pos.rotation);
        newObjects.Add(newObj);
    }
    public void destroyObjects()
    {
        foreach (GameObject obj in newObjects)
        {
            Destroy(obj);
        }
        newObjects.Clear();
    }
}
