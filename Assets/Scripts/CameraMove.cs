using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private GameObject player;
    private bool drumRoll;
    private AudioSource bgm;
    public AudioClip clipBGM;
    public AudioClip clipDrums;
    void Awake()
    {
        player = FindObjectOfType<Player>().gameObject;
        bgm = GetComponent<AudioSource>();
        bgm.clip = clipBGM;
        bgm.Play();
    }
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + 10, transform.position.y, transform.position.z);
    }
    public void SetDrumRoll(bool val)
    {
        if (val)
        {
            bgm.clip = clipDrums;
            bgm.Play();
        }
        else
        {
            if (drumRoll)
            {
                bgm.clip = clipBGM;
                bgm.Play();
            }
        }
        drumRoll = val;
    }
    public void StopBGM()
    {
        bgm.Stop();
    }
}
