using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IngameUI : MonoBehaviour
{
    private Player player;
    public TextMeshProUGUI score;
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            score.text = $"Distance: {player.GetDistance()} \n" +
                $"Balls jumped: {player.GetScore()}";
        }
    }
}
