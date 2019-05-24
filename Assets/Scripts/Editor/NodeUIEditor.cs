using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Node))]
public class NodeUIEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Node node = (Node)target;
        node.m_ID = EditorGUILayout.TextField("Node ID", node.m_ID);
        node.m_nodes[0] = (Node)EditorGUILayout.ObjectField("Forward", node.m_nodes[0], typeof(Node), true);
        node.m_nodes[1] = (Node)EditorGUILayout.ObjectField("Left", node.m_nodes[1], typeof(Node), true);
        node.m_nodes[2] = (Node)EditorGUILayout.ObjectField("Back", node.m_nodes[2], typeof(Node), true);
        node.m_nodes[3] = (Node)EditorGUILayout.ObjectField("Right", node.m_nodes[3], typeof(Node), true);
    }
}
