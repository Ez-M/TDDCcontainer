using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    protected GameObject UIpanel;

    [SerializeField]
    protected GameObject SlotPrefab;
    [SerializeField]
    protected GameObject[] UIslots;
    [SerializeField]
    public InventoryObject inventoryObject;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InitInventoryUI()
    {
        UIslots = new GameObject[inventoryObject.inventory.Slots.Length];
        for (int i = 0; i < inventoryObject.inventory.Slots.Length; i++)
        {
            var inventoryItem = inventoryObject.inventory.Slots[i];
            var newUIslot = Instantiate(SlotPrefab,UIpanel.transform);
            newUIslot.GetComponent<InventoryUISlot>().initComponents(inventoryItem);
            UIslots[i] = newUIslot;
            
            
        }
    }

    public void OpenUI()
    {
        if (UIpanel != null)
        {
            UIpanel.SetActive(true);
        }
    }

    public void CloseUI()
    {
        if (UIpanel != null)
        {
            UIpanel.SetActive(false);
        }
    }

    public void UpdateUI()
    {
        for (int i = 0; i < inventoryObject.inventory.Slots.Length; i++)
        {
            if(inventoryObject.inventory.Slots[i] != null)
            {
            UIslots[i].GetComponent<InventoryUISlot>().UpdateImage(inventoryObject.inventory.Slots[i]);
            UIslots[i].GetComponent<InventoryUISlot>().UpdateAmount(inventoryObject.inventory.Slots[i]);
            }
        }
    }

    public void toggleUI()
    {
        UIpanel.SetActive(!UIpanel.activeInHierarchy);
    }



}
