using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeWalker : MonoBehaviour
{
    public List<KeyCode> forwardKeys;
    public List<KeyCode> leftKeys;
    public List<KeyCode> downKeys;
    public List<KeyCode> rightKeys;

    public Node current = null;

    void Start()
    {

    }

    void Update()
    {
        foreach (KeyCode key in forwardKeys)
        {
            if (Input.GetKeyDown(key))
            {
                if (current.m_nodes[0] != null && current.m_nodes[0].isActiveAndEnabled)
                {
                    current = current.m_nodes[0];
                }
            }
        }
        foreach (KeyCode key in leftKeys)
        {
            if (Input.GetKeyDown(key))
            {
                if (current.m_nodes[1] != null && current.m_nodes[1].isActiveAndEnabled)
                {
                    current = current.m_nodes[1];
                }
            }
        }
        foreach (KeyCode key in downKeys)
        {
            if (Input.GetKeyDown(key))
            {
                if (current.m_nodes[2] != null && current.m_nodes[2].isActiveAndEnabled)
                {
                    current = current.m_nodes[2];
                }
            }
        }
        foreach (KeyCode key in rightKeys)
        {
            if (Input.GetKeyDown(key))
            {
                if (current.m_nodes[3] != null && current.m_nodes[3].isActiveAndEnabled)
                {
                    current = current.m_nodes[3];
                }
            }
        }
        transform.position = current.transform.position;
        transform.rotation = current.transform.rotation;
    }
}
