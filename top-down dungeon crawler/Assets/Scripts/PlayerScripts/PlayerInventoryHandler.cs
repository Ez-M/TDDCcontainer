using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerInventoryHandler : MonoBehaviour
{
    public InventoryObject inventory;

    public MouseItem mouseItem = new MouseItem();


    private void OnApplicationQuit()
    {
        inventory.inventory.Slots = new InventorySlot[15];
    }
    // private void Update()
    // {
    //     // if(Input.GetKeyDown(KeyCode.Z))
    //     // {
    //     //     // inventory.Save();
    //     // }
    //     // if(Input.GetKeyDown(KeyCode.X))
    //     // {
    //     //     // inventory.Load();
    //     // }
    // }
}

[Serializable]
public class MouseItem
{
    // public UserInterface UI;
    public GameObject draggedUISlot;
    public InventorySlot draggedDataSlot;
    public InventorySlot hoverDataSlot;
    public GameObject hoverUISlot;
}