using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField]
    private float intensity = 0;

    [SerializeField]
    private AudioClip intro;

    [SerializeField]
    private List<AudioClip> intensities = new List<AudioClip>();

    public void SetIntensity(float intensity)
    {
        this.intensity = intensity;
    }

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
