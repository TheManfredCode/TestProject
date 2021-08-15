using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSaving : MonoBehaviour
{
    private const string c_topScoreKey = "topScore";

    public void Save(SaveData data)
    {
        PlayerPrefs.SetInt(c_topScoreKey, data.TopScore);
        PlayerPrefs.Save();
    }

    public SaveData Load()
    {
        var result = new SaveData();

        if (PlayerPrefs.HasKey(c_topScoreKey))
        {
            result.TopScore = PlayerPrefs.GetInt(c_topScoreKey);
        }

        return result;
    }
}
