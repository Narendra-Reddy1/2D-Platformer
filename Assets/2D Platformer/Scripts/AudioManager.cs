using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource[] soundFX;
    public AudioSource bgm;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        bgm.Play();
    }

   
    public void playSFX(int audioIndex)
    {
        soundFX[audioIndex].Stop();

        soundFX[audioIndex].Play();

    }
}
