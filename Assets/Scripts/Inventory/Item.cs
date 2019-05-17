using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour
{
    [SerializeField] public GameObject m_item = null;
    [SerializeField] public Sprite itemIcon = null;

    public string m_name;

    public bool isCombinedItem = false; //is this an item that can only be made by combining items?

    //if so fill out this information! 
    public string needed_Item1; //this can be used with interactive as well
    public string needed_Item2;

    //for interactive Items
    public bool isInteractive = false;

    public void onClickInteraction()
    {
        if(Inventory.m_SelectedItems[0].GetComponent<Item>().m_name == needed_Item1)
        {
            Debug.Log("Do a thing ");
        }
    }

}
