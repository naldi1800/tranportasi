using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HighScore
{
    string key = "HighScore";

    public void Save(int level, string name, string time)
    {
        for (int i = 1; i <= 5; i++)
        {
            string name2 = PlayerPrefs.GetString(key + "-name-" + level + "-" + i, "-");
            string score = PlayerPrefs.GetString(key + "-score-" + level + "-" + i, "00:00");
            int comparisonResult = 0;

            if (name2 == "-")
            {
                PlayerPrefs.SetString(key + "-name-" + level + "-" + i, name);
                PlayerPrefs.SetString(key + "-score-" + level + "-" + i, "0" + time);
                break;
            }
            else
            {
                TimeSpan timeSpan1 = TimeSpan.ParseExact("0" + time, "mm\\:ss", null);
                TimeSpan timeSpan2 = TimeSpan.ParseExact(score, "mm\\:ss", null);
                comparisonResult = TimeSpan.Compare(timeSpan1, timeSpan2);
            }
            if (comparisonResult > 0)
            {
                cek(level, i);
                PlayerPrefs.SetString(key + "-name-" + level + "-" + i, name);
                PlayerPrefs.SetString(key + "-score-" + level + "-" + i, "0" + time);
                break;
            }
        }
    }

    public void cek(int level, int index)
    {
        for (int i = 5; i >= index; i--)
        {
            string name = PlayerPrefs.GetString(key + "-name-" + level + "-" + (i - 1), "-");
            string score = PlayerPrefs.GetString(key + "-score-" + level + "-" + (i - 1), "00:00");
            PlayerPrefs.SetString(key + "-name-" + level + "-" + i, name);
            PlayerPrefs.SetString(key + "-score-" + level + "-" + i, score);
        }
    }

    public string getAll()
    {
        string res = "";
        for (int i = 1; i <= 5; i++)
        {
            res += "Level " + i + "\n";
            for (int j = 1; j <= 5; j++)
            {
                string name = PlayerPrefs.GetString(key + "-name-" + i + "-" + j, "-");
                string score = PlayerPrefs.GetString(key + "-score-" + i + "-" + j, "00:00");
                if (name == "-")
                {
                    res += "-";
                }
                else
                {
                    res += name + " - " + score;
                }
                res += "\n";
            }
            res += "\n";
        }
        return res;
    }
}
