using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "ScoreEntry", menuName = "Score")]
public class ScoreEntry : ScriptableObject , IComparable
{
    public TimeSpan m_time = TimeSpan.Zero;
    public string m_name = "";
    public string m_ending = "";

    public int CompareTo(object obj)
    {
        return m_time.CompareTo(obj);
    }
}
