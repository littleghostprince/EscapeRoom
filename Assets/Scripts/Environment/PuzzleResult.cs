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

    [SerializeField] Node m_node;

    bool m_done = false;

    int solution = 0;
    int width;

    void Start()
    {
        m_node.gameObject.SetActive(false);
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
        if (!m_done) {
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

                m_node.gameObject.SetActive(true);
                m_done = true;
            }
            else if (solution == 2)
            {
                m_gameObjects[m_currentIndex].SetActive(false);
                m_currentIndex = 2;
                m_gameObjects[m_currentIndex].SetActive(true);

                m_node.gameObject.SetActive(false);
                m_done = true;
            }
            else
            {
                m_gameObjects[m_currentIndex].SetActive(false);
                m_currentIndex = 0;
                m_gameObjects[m_currentIndex].SetActive(true);

                m_node.gameObject.SetActive(false);
            }
        } else
        {
            foreach (PuzzlePiece puzzlePiece in m_puzzlePieces)
            {
                puzzlePiece.m_done = true;
            }
        }
    }
}
