using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public class InventoryUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
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
#region open&close
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
        public void toggleUI()
    {
        UIpanel.SetActive(!UIpanel.activeInHierarchy);
    }
    #endregion
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


#region clickStuff

    public void OnPointerClick(PointerEventData _pointerEventData)
    {
    }

    public void OnPointerEnter(PointerEventData _pointerEventData)
    {

        GameObject eventObject = _pointerEventData.pointerEnter;


        if(eventObject.GetComponent<InventoryUISlot>())
        {
            Debug.Log(eventObject);
            PlayerInventoryHandler playerInventoryHandler = PlayerManager.Instance.PlayerInventoryHandler; 
            playerInventoryHandler.mouseItem.hoverUISlot = eventObject;
            playerInventoryHandler.mouseItem.hoverDataSlot = playerInventoryHandler.inventory.inventory.Slots[System.Array.IndexOf(UIslots, eventObject)];

        }

        
    }
    public void OnPointerExit(PointerEventData _pointerEventData)
    {
            PlayerInventoryHandler playerInventoryHandler = PlayerManager.Instance.PlayerInventoryHandler; 
            playerInventoryHandler.mouseItem.hoverUISlot = null;
            playerInventoryHandler.mouseItem.hoverDataSlot = null;

    }

        public void OnDrag(PointerEventData _pointerEventData)
    {

    }

    public void OnBeginDrag(PointerEventData _pointerEventData)
    {

            PlayerInventoryHandler playerInventoryHandler = PlayerManager.Instance.PlayerInventoryHandler; 
            GameObject eventObject = playerInventoryHandler.mouseItem.hoverUISlot;
        if(eventObject.GetComponent<InventoryUISlot>())
        {
            playerInventoryHandler.mouseItem.draggedUISlot = eventObject;
            playerInventoryHandler.mouseItem.draggedDataSlot = playerInventoryHandler.inventory.inventory.Slots[System.Array.IndexOf(UIslots, eventObject)];
        }




    }


    public void OnEndDrag(PointerEventData _pointerEventData)
    {



        
            
        PlayerInventoryHandler playerInventoryHandler = PlayerManager.Instance.PlayerInventoryHandler; 
        if(playerInventoryHandler.mouseItem.draggedDataSlot != null && playerInventoryHandler.mouseItem.draggedUISlot != null)
        {
            var oldItem = playerInventoryHandler.mouseItem.draggedDataSlot;
            var newItem = playerInventoryHandler.mouseItem.hoverDataSlot;
            var dataSlotsArray = playerInventoryHandler.inventory.inventory.Slots;
            dataSlotsArray[System.Array.IndexOf(dataSlotsArray, oldItem)] = newItem;
            dataSlotsArray[System.Array.IndexOf(dataSlotsArray, newItem)] = oldItem;

            UpdateUI();
        }
        // old object is held, new is hovered
        
        //set old = hovered, set hovered = held

        playerInventoryHandler.mouseItem.draggedDataSlot = null;
        playerInventoryHandler.mouseItem.draggedUISlot = null;

        

    }

#endregion


}
