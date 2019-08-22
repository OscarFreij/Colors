using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Controler : MonoBehaviour
{
    private AudioSource Audio_Player;
    private AudioSource Audio_Blobb;

    public AudioClip[] audioClips;
    // Start is called before the first frame update
    void Start()
    {
        Audio_Player = gameObject.GetComponents <AudioSource>()[0];
        Audio_Blobb = gameObject.GetComponents<AudioSource>()[1];

    }

    public void PlayAudio(int i)
    {
        if (i == 0)
        {
            Audio_Player.Play();
        }
        else
        {
            Audio_Blobb.clip = audioClips[i];
            Audio_Blobb.Play();
        }
    }

}
