using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject slotHolder = null;
    bool inventoryEnabled = false;

    public int CountSelect { get
        {
            int count = 0;
            for(int i = 0; i < m_SelectedItems.Length; i ++)
            {
                if (m_SelectedItems[i] != null) count++;
            }
            return count;
        } }

    public List<GameObject> m_combineItem = new List<GameObject>(); //list of valid combine items
    public int num_Slots;
    public GameObject[] m_items;

    //static 
    public static GameObject[] m_SelectedItems = new GameObject[2];


    void Start()
    {
        num_Slots = 7; //there are seven slots 
        m_items = new GameObject[num_Slots];

        for(int i = 0; i < num_Slots; i ++)
        {
            m_items[i] = slotHolder.transform.GetChild(i).gameObject;

            if (m_items[i].GetComponent<Slot>().m_item == null)
                m_items[i].GetComponent<Slot>().empty = true;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) inventoryEnabled = !inventoryEnabled;

        if (inventoryEnabled == true) slotHolder.SetActive(true);
        else slotHolder.SetActive(false);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Item")
                {
                    Debug.Log("This is an item");
                    onClick(hit.transform.gameObject);
                }

            }           
            
        }

        if (CountSelect == 2) //if we have 2 selected already do this.
        {
            combineItem(m_SelectedItems[0], m_SelectedItems[1]);
            Debug.Log("Done Combine");
        }
    }
   
    public void onClick(GameObject other)
    {
            Debug.Log("Entered onClick Method");
            addItem(other);
       
    }

    public void addItem(GameObject item) //add onto inventory
    {
        if (item == null) return;

        for(int i = 0; i < num_Slots; i++)
        {
            if(m_items[i].GetComponent<Slot>().empty)
            {
                m_items[i].GetComponent<Slot>().Icon = item.GetComponent<Item>().itemIcon;
                m_items[i].GetComponent<Slot>().m_item = item.GetComponent<Item>().m_item;

                item.transform.parent = m_items[i].transform;
                item.SetActive(false);

                m_items[i].GetComponent<Slot>().UpdateSlot();
                m_items[i].GetComponent<Slot>().empty = false;

                break;
            }
        }
        Debug.Log(item.name + " been added to inventory");
    }

    public bool removeItem(GameObject item)
    {
        for(int i = 0; i < num_Slots; i ++)
        {
            if(m_items[i].GetComponent<Slot>().m_item == item)
            {
                m_items[i].GetComponent<Slot>().empty = true;
                m_items[i].GetComponent<Slot>().m_item = null;
                m_items[i].GetComponent<Slot>().Icon = null;

                m_items[i].GetComponent<Slot>().UpdateSlot();
                Debug.Log("item removed");
                return true;
            }
        }
        Debug.Log("item not in inventory/ unable to remove");
        return false;
    }

    public void addToCombineItem(GameObject newItem)
    {
        if(newItem.GetComponent<Item>().isCombinedItem) //if this item is a valid item add
        {
            m_combineItem.Add(newItem);
            Debug.Log("Combine item added to list");
        }
    }

    public void combineItem(GameObject item1, GameObject item2)
    {
        foreach (GameObject item in m_combineItem) //go through and see if there is a valid combine item
        {
            if ((item.GetComponent<Item>().needed_Item1 == item1.GetComponent<Item>().m_name && item.GetComponent<Item>().needed_Item2 == item2.GetComponent<Item>().m_name) || (item.GetComponent<Item>().needed_Item1 == item2.GetComponent<Item>().m_name && item.GetComponent<Item>().needed_Item2 == item1.GetComponent<Item>().m_name)) //if found valid combine item
            {
                //remove the two items used
                removeItem(item1);
                removeItem(item2);

                Destroy(item1.gameObject);
                Destroy(item2.gameObject);

              //add the combine item
              addItem(item);

                Debug.Log("Item was combined. New item in inventory");
            }
        }
    }

    //static methods
    public static bool addSelectedItem(GameObject ob)
    {
        for (int i = 0; i < 2; i++)
        {
            if (m_SelectedItems[i] == null) //if empty
            {
                m_SelectedItems[i] = ob;
                return true; //if found a spot return true
            }
        }
        return false; //if there is no spot
    }

    public static bool deleteSelectedItem(GameObject ob)
    {
        for(int i = 0; i < 2; i++)
        {
            if(m_SelectedItems[i] == ob)
            {
                m_SelectedItems[i] = null;
                return true;
            }
        }

        //switches position
        if(m_SelectedItems[0] == null && m_SelectedItems[1] != null)
        {
            GameObject temp = m_SelectedItems[1];
            m_SelectedItems[0] = temp;
            m_SelectedItems[1] = null;
        }
        return false; //if item was not found
    }



}
