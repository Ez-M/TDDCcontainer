using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]

public class InventoryObject : ScriptableObject
{
    public string savePath;
    public Inventory inventory;


    #region Save&Load

    [ContextMenu("Save")]
    public void Save()
    {
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, inventory);
        stream.Close();
        Debug.Log(string.Concat(Application.persistentDataPath, savePath));
    }

    [ContextMenu("Load")]
    public void Load()
    {
        if(File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Open, FileAccess.Read);
            Inventory newContainer = (Inventory)formatter.Deserialize(stream);
            for (int i = 0; i < newContainer.Slots.Length; i++)
            {
                inventory.Slots[i].UpdateSlot(newContainer.Slots[i].ID, newContainer.Slots[i].item, newContainer.Slots[i].amount);
            }
            stream.Close();

        }

    }

    #endregion


}

[System.Serializable]
public class Inventory
{
    // public Entity owner;

    public InventorySlot[] Slots = new InventorySlot[15];
    public void Clear()
    {
        for (int i = 0; i < Slots.Length; i++)
        {
            Slots[i].UpdateSlot(-1, new ItemData(), 0);
        }
    }
    public bool CheckSpaceTemp()
    {
        for (int x = 0; x < Slots.Length; x++)
        {
            if (Slots[x].item.ItemCode < 0)
            { return true; }
        }
        return false;
    }

    //REVIEW THIS//
    public bool CheckSpace(int _sizeToCheck)
    {
        for (var x = 0; x < Slots.Length; x++)
        {
            var consecutiveXSlots = 0;
            if (Slots[x].item == null)
            {
                consecutiveXSlots++;
                for (int x2 = x; x2 < Slots.Length; x2++)
                {
                    if (Slots[x2].item == null)
                    {
                        consecutiveXSlots++;
                        if (consecutiveXSlots == _sizeToCheck)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        consecutiveXSlots = 0;
                    }
                }


            }
        }
        return false;
    }





}

[System.Serializable]
public class InventorySlot
{

    public ItemType[] AllowedItems = new ItemType[0];
    // public UserInterface parent;
    public int ID;
    public ItemData item;
    public int amount;
    public InventorySlot()
    {
        ID = -1;
        item = null;
        amount = 0;
    }
    public InventorySlot(int _id, ItemData _item, int _amount)
    {
        ID = _id;
        item = _item;
        amount = _amount;
    }
    public void UpdateSlot(int _id, ItemData _item, int _amount)
    {
        ID = _id;
        item = _item;
        amount = _amount;
    }
    public void AddAmount(int value)
    {
        amount += value;
    }
    public bool CanPlaceInSlot(ItemData _item)
    {
        if (AllowedItems.Length <= 0)
        { return true; }
        for (int i = 0; i < AllowedItems.Length; i++)
        {
            if (_item.Type == AllowedItems[i])
            { return true; }
        }
        return false;

    }
}