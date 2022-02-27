using System.Collections;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField]
    AudioGroup[] audioGroups;

    public void PlaySoundLooping(string groupName, Transform location, float volume)
    {
        AudioSource audioSource = CreateAudioSource(RandomClip(groupName), transform, volume);

        audioSource.loop = true;
    }

    public void PlaySound(string groupName, Transform location, float volume)
    {
        StartCoroutine(PlaySoundCoroutine(groupName, location, volume));
    }

    private IEnumerator PlaySoundCoroutine(string groupName, Transform location, float volume)
    {
        AudioSource audioSource = CreateAudioSource(RandomClip(groupName), location, volume);

        yield return new WaitForSeconds(audioSource.clip.length);

        Destroy(audioSource.gameObject);
    }

    private AudioSource CreateAudioSource(AudioClip audioClip, Transform location, float volume)
    {
        GameObject soundObject = new GameObject();
        soundObject.name = "Audio Source";
        soundObject.transform.SetParent(location);
        soundObject.transform.position = location.position;
        AudioSource audioSource = soundObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();

        return audioSource;
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
