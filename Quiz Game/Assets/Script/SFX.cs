using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SFX : MonoBehaviour
{
    public AudioSource SoundEffects;
    public AudioClip hoverFX;

    public void HoverSound()
    {
        SoundEffects.PlayOneShot(hoverFX);
    }
}
