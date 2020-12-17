using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    //whenever we move our slider this function will be called
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}
