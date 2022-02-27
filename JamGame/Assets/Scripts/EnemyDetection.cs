using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<PlayerFollower>().Reveal();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //DirectHit(other);
            other.gameObject.GetComponent<PlayerFollower>().LookAt();
        }
    }

    /*bool DirectHit(Collider other)
    {
        RaycastHit hit = new RaycastHit();

        Physics.Raycast(new Ray(transform.position, other.transform.position - transform.position), out hit, Mathf.Infinity, QueryTriggerInteraction.Ignore);

        Debug.DrawRay(transform.position, other.transform.position - transform.position);

        if (hit.collider)
        {
            Debug.Log(hit.collider);
            Debug.Log(hit.collider.gameObject.name);

            return hit.collider == other;
        } else
        {
            return false;
        }
    }*/
}
