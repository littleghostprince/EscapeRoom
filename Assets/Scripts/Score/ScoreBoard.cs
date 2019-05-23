using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    public List<ScoreEntry> scores = new List<ScoreEntry>();

    void Start()
    {
        scores.Sort();
        foreach (ScoreEntry score in scores)
        {
            TextMeshProUGUI name = new TextMeshProUGUI();
            name.text = score.m_name;
            TextMeshProUGUI time = new TextMeshProUGUI();
            name.text = score.m_time.ToString(@"h\.mm\:ss");
            TextMeshProUGUI ending = new TextMeshProUGUI();
            name.text = score.m_ending;
        }
    }
}
