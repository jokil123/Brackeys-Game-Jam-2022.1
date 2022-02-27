using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActivator : MonoBehaviour
{
    public bool isFakeObject;
    public GameObject panelUI;
    public GameObject pickedUpUI;

    private PickUpManager pickUpManager;
    private PlayerFollower playerFollower;
    private bool isToggleable = false;

    // Start is called before the first frame update
    void Start()
    {
        playerFollower = gameObject.GetComponentInParent<PlayerFollower>();
        pickUpManager = GameObject.FindGameObjectWithTag("PickUpManager").GetComponent<PickUpManager>();
    }

    private void Update()
    {
        if (isToggleable && Input.GetKeyDown(KeyCode.E))
        {
            pickUpManager.pickedUpUIText.text = $"SOMETHING DOESNT SEEM RIGHT ABOUT THIS OBJECT...";
            pickedUpUI.SetActive(true);
            StartCoroutine(HideUI());
            playerFollower.isActive = true;
            playerFollower.enemyProp.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (playerFollower.isActive) { return; }
        if (isFakeObject)
        {
            isToggleable = true;
            pickUpManager.panelUIText.text = $"PICK UP {playerFollower.itemName}";
            panelUI.SetActive(true);
        } else
        {
            playerFollower.isActive = true;
            playerFollower.enemyProp.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (playerFollower.isActive) { return; }
        if (isFakeObject)
        {
            panelUI.SetActive(false);
        }
    }

    private IEnumerator HideUI()
    {
        yield return new WaitForSeconds(5);
        pickedUpUI.SetActive(false);
    }
}
