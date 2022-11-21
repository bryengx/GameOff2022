using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    public static void PlaySound(Vector3 pos, string sound)
    {
        SoundEffect se = Instantiate(Resources.Load<SoundEffect>("SoundEffect"), pos, Quaternion.Euler(0, 0, 0));
        se.PlaySound(Resources.Load<AudioClip>($"Sounds/{sound}"));
    }
    public static void PlayClip(Vector3 pos, AudioClip clip)
    {
        SoundEffect se = Instantiate(Resources.Load<SoundEffect>("SoundEffect"), pos, Quaternion.Euler(0, 0, 0));
        se.PlaySound(clip);
    }
}
