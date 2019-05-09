using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class PuzzlePiece : MonoBehaviour
{
    [SerializeField] GameObject[] m_gameObjects;
    public int m_currentIndex { get; set; } = 0;

    void Start()
    {
        if (m_currentIndex < 0 || m_currentIndex >= m_gameObjects.Length) m_currentIndex = 0;
        for(int f = 0; f < m_gameObjects.Length; f++)
        {
            m_gameObjects[f].SetActive(false);
        }
        m_gameObjects[m_currentIndex].SetActive(true);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Transform objectHit = hit.transform;

                if (objectHit.position == this.transform.position)
                {
                    Debug.Log("PuzzlePiece Clicked");
                    m_gameObjects[m_currentIndex].SetActive(false);

                    m_currentIndex++;
                    if (m_currentIndex >= m_gameObjects.Length) m_currentIndex = 0;

                    m_gameObjects[m_currentIndex].SetActive(true);
                }
            }
        }
    }
}
