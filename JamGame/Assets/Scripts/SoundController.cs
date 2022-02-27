using System.Collections;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField]
    AudioGroup[] audioGroups;

    public void PlaySound(string groupName, Transform location)
    {
        StartCoroutine(PlaySoundCoroutine(groupName, location));
    }

    private IEnumerator PlaySoundCoroutine(string groupName, Transform location)
    {
        GameObject soundObject = new GameObject();
        soundObject.name = "Audio Source";
        soundObject.transform.SetParent(location);
        AudioSource audioSource = soundObject.AddComponent<AudioSource>();
        audioSource.clip = RandomClip(groupName);
        audioSource.Play();

        yield return new WaitForSeconds(audioSource.clip.length);

        Destroy(soundObject);
    }

    private AudioClip RandomClip(string groupName)
    {
        foreach (AudioGroup group in audioGroups)
        {
            if (group.name.ToLower() == groupName.ToLower())
            {
                return group.clips[Random.Range(0, group.clips.Length - 1)];
            }
        }

        return null;
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.F2))
    //    {
    //        PlaySound("monster", gameObject.transform);
    //    }
    //}
}

[System.Serializable]
public class AudioGroup
{
    public string name;
    public AudioClip[] clips;
}
