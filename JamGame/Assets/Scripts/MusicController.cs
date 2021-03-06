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
    public IEnumerator SetIntensity(int intensitya)
    {
        for (float Vol = 0f; Vol <= volume; Vol += 0.1f)
        {
            sources[intensitya].volume =sources[intensitya].volume+0.1f;
            sources[intensity].volume=sources[intensity].volume-0.1f;
            yield return new WaitForSeconds(.3f);
        }
        intensity = intensitya;
    }

    public void SetVolume(float Volume)
    {
        this.volume = Volume;
        sources[intensity].volume = volume;
    }
    

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < sources.Count; i++)
        {
            sources[i].volume = 0;
            sources[i].Play();
        }
        sources[intensity].volume = volume;
        IntroEnded = 1;
    }

    // Update is called once per frame
    void Update()
    {
      
    }

}
