using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOffArea : MonoBehaviour
{
    public PickUpManager pickUpManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pickUpManager.SetCompleted();
        }
    }
}
