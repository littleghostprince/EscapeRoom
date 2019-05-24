using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] GameObject m_scorePanel = null;

    public void ShowPanel()
    {
        if (m_scorePanel.activeSelf == false)
        {
            m_scorePanel.SetActive(true);
        }
        else m_scorePanel.SetActive(false);
    }
    public void LoadMain()
    {
        SceneManager.LoadScene("Main");
    }
    public void LoadTitle()
    {
        SceneManager.LoadScene("Game");
    }
}
