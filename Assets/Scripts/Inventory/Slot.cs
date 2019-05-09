using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public bool empty = true;

    public GameObject m_item = null;
    public Sprite Icon;

    public void UpdateSlot()
    {
        this.GetComponent<Image>().sprite = Icon;
    }
}
