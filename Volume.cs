using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : MonoBehaviour
{
    private AudioSource music;

    private float volume = 1f;
    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        music.volume = volume;
    }

    public void setVolume(float vol)
    {
        volume = vol;
    }
}
