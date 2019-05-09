using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class PuzzleResult : MonoBehaviour
{
    [SerializeField] GameObject[] m_gameObjects;
    [SerializeField] int m_currentIndex = 0;

    [SerializeField] PuzzlePiece[] m_puzzlePieces;
    [SerializeField] int[] m_solutionIndexs;

    int solution = 0;
    int width;

    void Start()
    {
        width = m_puzzlePieces.Length;
        if (m_currentIndex < 0 || m_currentIndex >= m_gameObjects.Length) m_currentIndex = 0;
        for (int f = 0; f < m_gameObjects.Length; f++)
        {
            m_gameObjects[f].SetActive(false);
        }
        m_gameObjects[m_currentIndex].SetActive(true);
    }
    
    void Update()
    {
        for (int f = 0; f < m_solutionIndexs.Length / width; f++)
        {
            solution = (f + 1);
            for (int n = 0; n < width; n++)
            {
                if (m_solutionIndexs[n + (width * f)] != m_puzzlePieces[n].m_currentIndex)
                {
                    solution = 0;
                    break;
                }
            }
            if (solution != 0) break;
        }

        if (solution == 1)
        {
            m_gameObjects[m_currentIndex].SetActive(false);
            m_currentIndex = 1;
            m_gameObjects[m_currentIndex].SetActive(true);
        }
        else if (solution == 2)
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
