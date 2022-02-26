using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerFollower : MonoBehaviour
{
    public GameObject enemyProp;

    private NavMeshAgent ghostAgent;
    private NavMeshAgent playerAgent;

    private void Start()
    {
        playerAgent = GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>();
        ghostAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(ghostAgent.transform.position, playerAgent.transform.position) < 20.0)
        {
            ghostAgent.SetDestination(playerAgent.destination);
            foreach (Renderer renderer in enemyProp.GetComponentsInChildren<Renderer>())
            {
                renderer.material.SetColor("_Color", Color.green);
                Debug.Log("green");
            }
        }
        foreach (Renderer renderer in enemyProp.GetComponentsInChildren<Renderer>())
        {
            renderer.material.SetColor("_Color", Color.red);
            Debug.Log("red");
        }

    }
}
