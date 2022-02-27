using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUpManager : MonoBehaviour
{
    public GameObject heldItem;
    public GameObject objectivePostIt;
    public List<string> objectiveNames = new List<string>();
    public ParticleSystem particleSystem;
    public TextMeshProUGUI pickedUpUIText;
    public TextMeshProUGUI objectiveUIText;
    public TextMeshProUGUI panelUIText;

    private Dictionary<string,bool> objectiveList = new Dictionary<string, bool>();

    private string done = "- [done]";
    private string inProgress = "- [in Progress]";

    private void Awake()
    {
        objectiveUIText = objectivePostIt.GetComponentInChildren<TextMeshProUGUI>();
        pickedUpUIText.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (string objective in objectiveNames)
        {
            objectiveList.Add(objective, false);
        }
        UpdateUI();
        objectivePostIt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            objectivePostIt.SetActive(!objectivePostIt.activeInHierarchy);
        }
        if (!pickedUpUIText.gameObject.activeInHierarchy && heldItem != null)
        {
            pickedUpUIText.gameObject.SetActive(true);
        }
    }

    public void SetCompleted()
    {
        if (heldItem != null)
        {
            objectiveList[heldItem.GetComponent<PickUpItem>().ItemName] = true;
            particleSystem.Play();
            pickedUpUIText.gameObject.SetActive(false);
            heldItem = null;

            if (IsFinished())
            {
                // finish the game
                // your mum was very proud
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().Complete();
            }

            UpdateUI();
        }
    }

    bool IsFinished()
    {
        foreach (string itemStatus in objectiveList.Keys)
        {
            if (objectiveList[itemStatus] == false) { return false; }
        }

        return true;
    }

    void UpdateUI()
    {
        objectiveUIText.text = "Please bring me:";
        foreach (string name in objectiveList.Keys)
        {
            objectiveUIText.text += "\n" + (objectiveList[name] ? done : inProgress) + $" {name}";
        }
    }
}
