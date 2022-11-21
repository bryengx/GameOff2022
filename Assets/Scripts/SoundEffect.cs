using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    private AudioSource soundEffect;
    void Awake()
    {
        soundEffect = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (!soundEffect.isPlaying)
            Destroy(gameObject);
    }
    public void PlaySound(AudioClip ac)
    {
        soundEffect.PlayOneShot(ac);
    }
}
