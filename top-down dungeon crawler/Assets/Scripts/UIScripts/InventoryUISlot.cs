using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class InventoryUISlot : MonoBehaviour
{
    [SerializeField]
    protected Image image;
    [SerializeField]
    protected TextMeshProUGUI AmountTextComponent;

    public void initComponents(InventorySlot _inventorySlot)
    {
        // image = gameObject.GetComponentInChildren<Image>();
        // AmountTextComponent = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        UpdateImage(_inventorySlot);
        UpdateAmount(_inventorySlot);
    }

    public void UpdateImage(InventorySlot _inventorySlot)
    {

        if (_inventorySlot.item.ItemObject != null)
        { image.sprite = _inventorySlot.item.ItemObject.Sprite; }
    }
    public void UpdateAmount(InventorySlot _inventorySlot)
    {
        if (_inventorySlot.amount >= 0)
        {
            AmountTextComponent.text = _inventorySlot.amount.ToString();
        }
    }

}