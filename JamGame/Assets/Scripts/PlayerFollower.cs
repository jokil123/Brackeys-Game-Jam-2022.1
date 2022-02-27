using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerFollower : MonoBehaviour
{
    public static HashSet<GameObject> activeEnemies = new HashSet<GameObject>();

    public GameObject enemyProp;
    public bool isRevealed = false;
    public bool isActive = false;
    public string itemName;
    public float coolDownLength;

    private NavMeshAgent ghostAgent;
    private NavMeshAgent playerAgent;
    private float revealCDRemaining;
    private PlayerController controller;

    [SerializeField]
    private float volume;

    static void ActivateEnemy(GameObject enemy)
    {
        activeEnemies.Add(enemy);
        Debug.Log(activeEnemies.Count);
    }

    private void Start()
    {
        playerAgent = GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>();
        controller = playerAgent.gameObject.GetComponent<PlayerController>();
        ghostAgent = GetComponent<NavMeshAgent>();
        revealCDRemaining = coolDownLength;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            ActivateEnemy(gameObject);
        }

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
                GameObject.FindGameObjectWithTag("Player").GetComponent<SoundController>().PlaySound("monster", gameObject.transform, volume);
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
        revealCDRemaining = coolDownLength;
        enemyProp.SetActive(false);
        ghostAgent.isStopped = true;
        isRevealed = true;
    }
}
