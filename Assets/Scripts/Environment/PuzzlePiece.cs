using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class PuzzlePiece : MonoBehaviour
{
    [SerializeField] GameObject[] m_gameObjects;
    public int m_currentIndex { get; set; } = 0;
    [SerializeField] string m_itemName = "null";

    public bool m_done;

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
        if (!m_done)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (m_itemName == "null" || m_itemName == Inventory.m_SelectedItems[0].GetComponent<Item>().m_name)
                    {
                        Transform objectHit = hit.transform;

                        if (objectHit.position == this.transform.position)
                        {
                            Debug.Log("PuzzlePiece Clicked");
                            m_gameObjects[m_currentIndex].SetActive(false);

                            m_currentIndex++;
                            if (m_currentIndex >= m_gameObjects.Length) m_currentIndex = 0;

                            //m_currentObject.GetComponent<MeshRenderer>() = m_gameObjects[m_currentIndex].GetComponent<MeshRenderer>();
                            m_gameObjects[m_currentIndex].SetActive(true);
                        }
                    }
                }
            }
        }
    }
}
