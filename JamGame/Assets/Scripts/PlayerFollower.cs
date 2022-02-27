using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerFollower : MonoBehaviour
{
    public GameObject enemyProp;
    public bool isRevealed = false;
    public bool isActive = false;
    public string itemName;

    private NavMeshAgent ghostAgent;
    private NavMeshAgent playerAgent;
    private float revealCDRemaining = 10f;
    private PlayerController controller;

    private void Start()
    {
        playerAgent = GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>();
        controller = playerAgent.gameObject.GetComponent<PlayerController>();
        ghostAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive || controller.controllsPanel.activeInHierarchy) { return; }

        if (!isRevealed)
        {
            if (Vector3.Distance(ghostAgent.transform.position, playerAgent.transform.position) > 1.2f)
            {
                ghostAgent.SetDestination(playerAgent.destination);
            } else
            {
                PlayerController controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
                if (!controller.isFrozen)
                {
                    controller.GameOver(itemName);
                }
            }
        } else
        {
            if (revealCDRemaining > 0)
            {
                revealCDRemaining -= Time.deltaTime;
            }
            else if (isRevealed)
            {
                isRevealed = false;
                enemyProp.SetActive(true);
                ghostAgent.isStopped = false;
            }
        }
    }

    public void Reveal()
    {
        isRevealed = true;
        enemyProp.SetActive(false);
        ghostAgent.isStopped = true;
    }

    public void LookAt()
    {
        revealCDRemaining = 10f;
        enemyProp.SetActive(false);
        ghostAgent.isStopped = true;
        isRevealed = true;
    }
}
