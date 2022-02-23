using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public string ItemName = "item name";
    private GameObject pickUpUI;
    private bool pickUpable = false;
    private PickUpManager pickUpManager;

    // Start is called before the first frame update
    void Awake()
    {
        pickUpUI = GameObject.FindGameObjectWithTag("PickUpUI");
        pickUpManager = GameObject.FindGameObjectWithTag("PickUpManager").GetComponent<PickUpManager>();
    }

    private void Start()
    {
        pickUpUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && pickUpable)
        {
            Debug.Log($"Picked up {ItemName}!");
            //TODO: pick up item
            pickUpManager.heldItem = gameObject;
            pickUpUI.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pickUpUI.SetActive(true);
            pickUpUI.GetComponentInChildren<TextMeshProUGUI>().text = $"PICK UP {ItemName.ToUpper()}!";
            pickUpable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pickUpable = false;
            pickUpUI.SetActive(false);
        }
    }
}
