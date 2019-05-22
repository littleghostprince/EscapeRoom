using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI uiText = null;

    public TimeSpan timePast { get { return timer; } }
    private static TimeSpan timer = new TimeSpan();
    bool count = true;
    private float ticks = 0.0f;

    private void Start()
    {
        timer = TimeSpan.Zero;
    }

    private void Update()
    {
        if (count)
        {
            ticks += Time.deltaTime;
            timer = TimeSpan.FromSeconds(ticks);
            uiText.text = timer.ToString(@"h\.mm\:ss");
        }
    }

    public TimeSpan stop()
    {
        count = false;
        return timePast;
    }
}
