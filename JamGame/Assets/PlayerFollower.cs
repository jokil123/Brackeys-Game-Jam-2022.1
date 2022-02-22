using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerFollower : MonoBehaviour
{


    public NavMeshAgent ghostAgent;
    public NavMeshAgent playerAgent;
   
    


    // Update is called once per frame
    void Update()
    {
      if (Vector3.Distance(ghostAgent.transform.position, playerAgent.transform.position) < 15.0)
        {
            ghostAgent.SetDestination(playerAgent.destination);
            ghostAgent.gameObject.GetComponent<Renderer>().material.SetColor(name, Color.green);
        }
        ghostAgent.gameObject.GetComponent<Renderer>().material.SetColor(name, Color.red);

    }


}
