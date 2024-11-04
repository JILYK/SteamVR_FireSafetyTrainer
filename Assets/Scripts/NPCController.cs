using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    [Header("новый бул")]
    public bool NPC_go;
    [Header("старые переменные")]
    
    [SerializeField] float walkRadius;
    [SerializeField] float newDestinationTimer;

    NavMeshAgent agent;

    [SerializeField]
    Vector3 randomDirection;
    [SerializeField]
    Vector3 finalDestination;

    [SerializeField]
    private List<Vector3> newPositionList = new List<Vector3>();

    private void OnTriggerEnter(Collider other)
    {
        if (NPC_go && other.tag == "Task")
        {
            GetComponent<Animator>().SetBool("FIREbool", true);

        Config.checkForPeople = true;
        NPC_go = false;
        }
    }

    void Start()
    {
        if (!NPC_go)
        {
            GetComponent<Animator>().SetBool("FIREbool", true);

        }
        agent = GetComponent<NavMeshAgent>();
        //StartCoroutine(GoToExitDestination());
    }

    void Update()
    {
        //print(NIKConfig.isRunExit);
        if(NIKConfig.isRunExit && !NPC_go) 
            StartCoroutine(GoToExitDestination());

    }

    IEnumerator GoToExitDestination()
    {
        //randomDirection = Random.insideUnitSphere * walkRadius;
        //randomDirection += transform.position;

        //NavMeshHit hit;
        //NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 1);
        //finalDestination = hit.position;
        foreach (Vector3 v3 in newPositionList)
        {
            agent.SetDestination(v3);
            //NIKConfig.isRunExit= false;
            yield return new WaitForSeconds(newDestinationTimer);
            //NIKConfig.isRunExit = true;
        }
        yield return null;
        

        
    }
}
