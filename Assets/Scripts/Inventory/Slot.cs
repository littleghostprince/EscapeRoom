using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] public Button m_button = null; 
    public bool empty = true;

    public GameObject m_item = null;
    public Sprite Icon;

    public void UpdateSlot()
    {
        this.GetComponent<Image>().sprite = Icon;
        m_button.GetComponent<Image>().color = new Color(255f, 255f, 255f, 0.5f);
    }

    public void SelectItem()
    {
        Debug.Log("Selected");
        m_button.GetComponent<Image>().color = new Color(0f, 255f, 0f, 0.5f);
        Inventory.addSelectedItem(m_item);

    }
}
