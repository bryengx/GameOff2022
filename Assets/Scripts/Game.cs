using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    public AudioClip[] sheepVoice;
    public AudioClip[] jumpSounds;
    public AudioClip[] successSounds;
    public static Game instance;
    public GameObject LooseScreen;
    public GameObject FinishScreen;
    void Start()
    {
        instance = this;
        DisableAllScreens();
    }
    void Update()
    {

    }
    public void PlaySheepSound(Vector3 pos)
    {
        EffectsManager.PlayClip(pos, sheepVoice[Random.Range(0, sheepVoice.Length)]);
    }
    public void PlayJumpSound(Vector3 pos)
    {
        EffectsManager.PlayClip(pos, jumpSounds[Random.Range(0, jumpSounds.Length)]);
    }
    public void PlaySuccessSound(Vector3 pos, int level)
    {
        EffectsManager.PlayClip(pos, successSounds[level]);
    }
    public void DisableAllScreens()
    {
        LooseScreen.SetActive(false);
        FinishScreen.SetActive(false);
    }
    public void ShowGameOverScreen()
    {
        DisableAllScreens();
        LooseScreen.SetActive(true);
    }
    public void ShowFinishScreen()
    {
        DisableAllScreens();
        FinishScreen.SetActive(true);
    }
    public static void CreateTextMessage(string msg, Vector3 pos, Color col, float speed = 1, float size = 6)
    {
        GameObject go = Instantiate(Resources.Load<GameObject>("FloatText"), pos, Quaternion.Euler(0, 0, 0));
        go.GetComponent<Rigidbody2D>().velocity = Vector3.up * speed;
        go.GetComponent<TextMeshPro>().text = msg;
        go.GetComponent<TextMeshPro>().fontSize = size;
        go.GetComponent<TextMeshPro>().color = col;
        Destroy(go, 1.5f);
    }
    public static void CreateStars(Vector3 pos)
    {
        GameObject go = Instantiate(Resources.Load<GameObject>("StarsEmiter"), pos, Quaternion.Euler(0, 0, 0));
        Destroy(go, 1.5f);
    }
}
