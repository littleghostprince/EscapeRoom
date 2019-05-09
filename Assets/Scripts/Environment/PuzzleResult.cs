using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class PuzzleResult : MonoBehaviour
{
    [SerializeField] GameObject[] m_gameObjects;
    [SerializeField] int m_currentIndex = 0;

    [SerializeField] PuzzlePiece[] m_puzzlePieces;
    bool puzzleCompleate = false;

    void Start()
    {

        if (m_currentIndex < 0 || m_currentIndex >= m_gameObjects.Length) m_currentIndex = 0;
        for (int f = 0; f < m_gameObjects.Length; f++)
        {
            m_gameObjects[f].SetActive(false);
        }
        m_gameObjects[m_currentIndex].SetActive(true);
    }
    
    void Update()
    {
        if (m_puzzlePieces[0].m_currentIndex == 1 && m_puzzlePieces[1].m_currentIndex == 0 && m_puzzlePieces[2].m_currentIndex == 1)
        {
            m_gameObjects[m_currentIndex].SetActive(false);
            m_currentIndex = 1;
            m_gameObjects[m_currentIndex].SetActive(true);
        }
        else if (m_puzzlePieces[0].m_currentIndex == 1 && m_puzzlePieces[1].m_currentIndex == 2 && m_puzzlePieces[2].m_currentIndex == 1)
        {
            m_gameObjects[m_currentIndex].SetActive(false);
            m_currentIndex = 2;
            m_gameObjects[m_currentIndex].SetActive(true);
        }
        else
        {
            m_gameObjects[m_currentIndex].SetActive(false);
            m_currentIndex = 0;
            m_gameObjects[m_currentIndex].SetActive(true);
        }

    }
}
