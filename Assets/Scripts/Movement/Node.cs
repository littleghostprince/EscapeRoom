using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public string m_ID = "";
    //public List<Node> m_nodes = new List<Node>();
    //[NamedArrayAttribute(new string[] { "Forward", "Left", "Back", "Right" })]
    public Node[] m_nodes = new Node[4];
}