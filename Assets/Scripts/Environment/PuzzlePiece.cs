using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class PuzzlePiece : MonoBehaviour
{
    [SerializeField] GameObject[] m_gameObjects;
    [SerializeField] int m_currentIndex = 0;
    [SerializeField] GameObject m_currentObject;

    [SerializeField] int m_nodeField;
    [SerializeField] int m_nodeID = 0;

    void Start()
    {
        if (m_currentIndex < 0 || m_currentIndex >= m_gameObjects.Length) m_currentIndex = 0;
        m_currentObject = m_gameObjects[m_currentIndex];
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
                    m_currentIndex++;
                    if (m_currentIndex >= m_gameObjects.Length) m_currentIndex = 0;

                    m_currentObject.GetComponent<MeshRenderer>() = m_gameObjects[m_currentIndex].GetComponent<MeshRenderer>();
                }
            }
        }
    }
}
