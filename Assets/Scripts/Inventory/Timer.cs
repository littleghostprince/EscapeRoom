using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI uiText = null;

    public TimeSpan timePast { get { return timer; } }
    private TimeSpan timer = new TimeSpan();
    private float ticks = 0.0f;

    private void Update()
    {
        ticks += Time.deltaTime;
        timer = TimeSpan.FromSeconds(ticks);
        uiText.text = timer.ToString(@"hh\.mm\:ss");
    }
}
