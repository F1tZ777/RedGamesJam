using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ChangeVolume : MonoBehaviour
{

    public AudioMixer audioMixer;

    public void setVolume (float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

}
