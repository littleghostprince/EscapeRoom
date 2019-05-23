using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.UI;

public class Writing : MonoBehaviour
{
    public float m_pauseTime = 0.2f;
    [SerializeField] AudioSource m_sound1;
    [SerializeField] AudioSource m_sound2;

    [SerializeField] GameObject m_start;
    [SerializeField] GameObject m_score;

    public TextMeshProUGUI m_string = null;
    public string message;
    bool playFirst = false;
    void Start()
    {
        m_start.SetActive(false);
        m_score.SetActive(false);
        message = m_string.text;
        m_string.text = "";
        StartCoroutine(WriteText());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator WriteText()
    {
        foreach(char letter in message.ToCharArray())
        {
            m_string.text += letter;
            if (playFirst)
            {
                m_sound1.Play();
                playFirst = false;
            }
            else
            {
                m_sound2.Play();
                playFirst = true;
            }
            yield return new WaitForSeconds(m_pauseTime);
        }
        m_start.SetActive(true);
        m_score.SetActive(true);
    }
}
