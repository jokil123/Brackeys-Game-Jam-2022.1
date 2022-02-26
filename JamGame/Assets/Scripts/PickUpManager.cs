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

    private Dictionary<string,bool> objectiveList = new Dictionary<string, bool>();
    private TextMeshProUGUI objectiveUIText;

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
    }

    public void SetCompleted()
    {
        if (heldItem != null)
        {
            objectiveList[heldItem.GetComponent<PickUpItem>().ItemName] = true;
            particleSystem.Play();
            pickedUpUIText.gameObject.SetActive(false);
            heldItem = null;
            UpdateUI();
        }
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
