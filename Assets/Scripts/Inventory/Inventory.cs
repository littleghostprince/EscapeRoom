using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    List<Item> m_items = new List<Item>();

    List<Item> m_combineItem = new List<Item>(); //list of valid combine items

   public void addItem(Item item)
    {
        if (item == null) return;

        m_items.Add(item);
        Debug.Log(item.name + " been added to inventory");
    }

    public void removeItem(Item item)
    {
       if(m_items.Remove(item))
        {
            Debug.Log("item removed");
            return;
        }
        Debug.Log("item not in inventory/ unable to remove");
    }

    public void addToCombineItem(Item newItem)
    {
        if(newItem.isCombinedItem) //if this item is a valid item add
        {
            m_combineItem.Add(newItem);
            Debug.Log("Combine item added to list");
        }
    }

    public void combineItem(Item item1, Item item2)
    {
        foreach(Item item in m_combineItem) //go through and see if there is a valid combine item
        {
            if( (item.needed_Item1 == item1.name && item.needed_Item2 == item2.name) || (item.needed_Item1 == item2.name && item.needed_Item2 == item1.name )) //if found valid combine item
            {
                //remove the two items used
                m_items.Remove(item1);
                m_items.Remove(item2);

                m_items.Add(item); //add the combine item

                Debug.Log("Item was combined. New item in inventory");
            }
        }
    }


    
}
