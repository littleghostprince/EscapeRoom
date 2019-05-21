using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI uiText = null;

    public float timePast { get { return timer; } }
    private float timer = 0.0f;

    private void Update()
    {
        timer += Time.deltaTime;
        uiText.text = timer.ToString("F");
    }
}
