using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public string ItemName = "item name";
    private GameObject pickUpUI;
    private bool pickUpable = false;

    // Start is called before the first frame update
    void Start()
    {
        pickUpUI = GameObject.FindGameObjectWithTag("PickUpUI");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log($"Picked up {ItemName}!");
            //TODO: pick up item
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
