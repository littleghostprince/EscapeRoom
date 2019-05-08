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

    // Update is called once per frame
    void Update()
    {
        foreach (KeyCode key in forwardKeys)
        {
            if (Input.GetKeyDown(key))
            {
                if (current.m_nodes[0] != null)
                {
                    transform.position = current.m_nodes[0].transform.position;
                    current = current.m_nodes[0];
                }
            }
        }
        foreach (KeyCode key in leftKeys)
        {
            if (Input.GetKeyDown(key))
            {
                if (current.m_nodes[1] != null)
                {
                    transform.position = current.m_nodes[1].transform.position;
                    current = current.m_nodes[1];
                }
            }
        }
        foreach (KeyCode key in downKeys)
        {
            if (Input.GetKeyDown(key))
            {
                if (current.m_nodes[2] != null)
                {
                    transform.position = current.m_nodes[2].transform.position;
                    current = current.m_nodes[2];
                }
            }
        }
        foreach (KeyCode key in rightKeys)
        {
            if (Input.GetKeyDown(key))
            {
                if (current.m_nodes[3] != null)
                {
                    transform.position = current.m_nodes[3].transform.position;
                    current = current.m_nodes[3];
                }
            }
        }
    }
}
