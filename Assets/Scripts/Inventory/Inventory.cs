using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject slotHolder = null;
    public int num_Slots;

    GameObject[] m_items;
    List<GameObject> m_combineItem = new List<GameObject>(); //list of valid combine items

    bool inventoryEnabled = false; 

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

    public void removeItem(GameObject item)
    {
     //  if(m_items.Remove(item))
        {
            Debug.Log("item removed");
            return;
        }
        Debug.Log("item not in inventory/ unable to remove");
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
        foreach(GameObject item in m_combineItem) //go through and see if there is a valid combine item
        {
            if( (item.GetComponent<Item>().needed_Item1 == item1.GetComponent<Item>().name && item.GetComponent<Item>().needed_Item2 == item2.GetComponent<Item>().name) || (item.GetComponent<Item>().needed_Item1 == item2.GetComponent<Item>().name && item.GetComponent<Item>().needed_Item2 == item1.GetComponent<Item>().name )) //if found valid combine item
            {
                //remove the two items used
              //  m_items.Remove(item1);
              //  m_items.Remove(item2);

                Destroy(item1.gameObject);
                Destroy(item2.gameObject);


              //  m_items.Add(item); //add the combine item

                Debug.Log("Item was combined. New item in inventory");
            }
        }
    }
    



}
