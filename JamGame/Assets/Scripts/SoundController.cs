using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private int Zufall = 0;
    [SerializeField]
    private float volume = 0.5f;
    [SerializeField]
    private AudioSource DoorLocked = new AudioSource();
    [SerializeField]
    private AudioSource Dropoff = new AudioSource();
    [SerializeField]
    private AudioSource Pickup= new AudioSource();
    [SerializeField]
    private List<AudioSource> Door = new List<AudioSource>();
    [SerializeField]
    private List<AudioSource> WaterDrops = new List<AudioSource>();
    [SerializeField]
    private List<AudioSource> Monster = new List<AudioSource>();
    
    public static int Randomn(List<AudioSource> audioSources)
    {
        return Random.Range(0,audioSources.Count);
    }
    public void PlayMonsterSound()
    {
        Monster[Randomn(Monster)].volume = volume;
        Monster[Randomn(Monster)].Play();
        
    }
    public void PlayWaterSound()
    {
        Monster[Randomn(WaterDrops)].volume = volume;
        Monster[Randomn(WaterDrops)].Play();
    }
    public void PlayDoorSound()
    {
        Monster[Randomn(Door)].volume = volume;
        Monster[Randomn(Door)].Play();
    }
    public void SetVolume(float Volume)
    {
        this.volume = Volume;
    }
    public void PickupSound()
    {
        Pickup.volume = volume;
        Pickup.Play();
    }
    public void DropoffSound()
    {
        Dropoff.volume = volume;
        Dropoff.Play();
    }
    public void DoorLockedSound()
    {
        DoorLocked.volume = volume;
        DoorLocked.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Zufall = return Random.Range(0, 500);
        if(Zufall = 2)
        {
            PlayMonsterSound();
        }
        Zufall = return Random.Range(0, 1500);
        if (Zufall = 1)
        {
            PlayWaterSound();
        }
    }
}
