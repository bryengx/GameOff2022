using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IngameUI : MonoBehaviour
{
    private Player player;
    public TextMeshProUGUI score;
    public TextMeshProUGUI bestScore;
    public Image speedBar;
    void Start()
    {
        player = FindObjectOfType<Player>();
        bestScore.text = $"Best: {DataStore.GetBestDist().ToString("0.00")} \n\n\n" +
            $"Best: {DataStore.GetHighScore()}";
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            score.text = $"Distance: {player.GetDistance()} \n\n\n" +
                $"Score: {player.GetScore()}";
            speedBar.fillAmount = Mathf.Min(player.GetSpeed() / 10.0f, 1);
            //score.text = $"Distance: {player.GetDistance()} \n";
        }
    }
}
