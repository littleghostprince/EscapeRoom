using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] public GameObject m_item = null;
    [SerializeField] public Sprite itemIcon = null;
    public string m_name;

    public bool isCombinedItem = false; //is this an item that can only be made by combining items?
   
    //if so fill out this information! 
    public string needed_Item1;
    public string needed_Item2;
}
