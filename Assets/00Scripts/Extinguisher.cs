using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extinguisher : MonoBehaviour
{
    // Index should correspond to fire types
    public enum Type
    {
        Water,
        CarbonDioxide,
        Powder
    }
    public Type type;
    public Transform shootPoint;
    public GameObject fumes;

    void Start()
    {
        fumes.GetComponent<ExtinguisherParticles>().type = type;
    }

    public Type GetExtType()
    {
        return type;
    }

    public bool StartShitFire = false; // запущен огнетушитель
    public bool isChickUp = false;


    public void upChick()
    {
        isChickUp = true;
    }

    public void Shoot()
    {
        fumes.transform.position = shootPoint.position;
        fumes.transform.rotation = shootPoint.rotation;

        this.gameObject.GetComponent<CapsuleCollider>().enabled = true;

        if (isChickUp)
        {
            fumes.GetComponent<ParticleSystem>().Play();
            StartShitFire = true;            
        }
    }

    public void DontShoot()
    {
        StartShitFire = false;
        fumes.GetComponent<ParticleSystem>().Stop();
        boolStopFire = false;
        this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
    }

    public bool boolStopFire = false; // колайдер тушит огонь
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FireTrigger") && StartShitFire)
        {
            boolStopFire = true;
            StartCoroutine(FireTimer(other));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("FireTrigger"))
        {
            boolStopFire = false;
        }
    }

    IEnumerator FireTimer(Collider other)
    {
        float countdownTime = 3f;
        while (countdownTime > 0 && boolStopFire && StartShitFire)
        {
                yield return new WaitForSeconds(1f); // Ждем 1 секунду
                countdownTime--;
        }

        if (countdownTime == 0)
        {
            Stop(other);
        }
        yield break;
    }


    public void Stop(Collider other)
    {
        StartShitFire = false;
        Config.extinguishFire = true;
        other.gameObject.transform.GetChild(1).GetComponent<ParticleSystem>().Stop();
    }
}
