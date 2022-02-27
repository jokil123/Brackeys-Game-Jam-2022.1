using System.Collections;
using UnityEngine;

public class AmbientSound : MonoBehaviour
{
    [SerializeField]
    private string soundgroup;

    [SerializeField]
    private float minDelay;

    [SerializeField]
    private float maxDelay;

    [SerializeField]
    private float volume;

    IEnumerator PeriodicSounds()
    {
        while (true)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<SoundController>().PlaySound(soundgroup, gameObject.transform, volume);
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
        }
    }

    void Start()
    {
        StartCoroutine(PeriodicSounds());
    }
}
