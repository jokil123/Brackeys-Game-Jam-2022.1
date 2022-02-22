using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private int IntroEnded = 0;
    [SerializeField]
    private int intensity = 0;
    [SerializeField]
    private float volume = 0.5f ;
    [SerializeField]
    private AudioSource Intro;

 
    [SerializeField]
    private List<AudioSource> sources = new List<AudioSource>();
    public void SetIntensity(int intensity)
    {
        sources[intensity].volume=0;
        this.intensity = intensity;
        sources[intensity].volume = volume;
    }
    public void SetVolume(float Volume)
    {
        this.volume = Volume;
        sources[intensity].volume = volume;
    }
    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (IntroEnded == 0)
        {
            if (Intro.isPlaying == false)
            {
                for (int i = 0; i < sources.Count; i++)
                {
                    sources[i].volume = 0;
                    sources[i].Play();
                }
                sources[intensity].volume = volume;
                IntroEnded = 1;
            }
        }
        
    }

}
