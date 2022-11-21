using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStore : MonoBehaviour
{
    public static int GetHighScore()
    {
        int number;
        if (int.TryParse(PlayerPrefs.GetString("high_score"), out number))
            return number;
        return 0;
    }
    public static void SaveHighScore(int newPoints)
    {
        int currPoints = GetHighScore();

        if (newPoints > currPoints)
            PlayerPrefs.SetString("high_score", (newPoints).ToString());
    }
    public static float GetBestDist()
    {
        float val;
        if (float.TryParse(PlayerPrefs.GetString("best_dist"), out val))
            return val;
        return 0;
    }
    public static void SaveLongestDist(float newDist)
    {
        float longestDist = GetBestDist();

        if(newDist > longestDist)
            PlayerPrefs.SetString("best_dist", newDist.ToString());
    }
}
