using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
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
}
