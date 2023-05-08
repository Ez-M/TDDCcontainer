using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestItem : Entity
{
    private int itemID;
    public int ItemID { get => itemID; }

    private ItemData itemData;
    public ItemData ItemData { get => itemData; }

    // when spawned, get sprite

    public ItemData OnGrab()
    {
        return ItemData;
    }

}

[Serializable]
public abstract class ItemData
{

    private int itemID;
    public int ItemID { get => itemID; }

    private int itemCode;
    public int ItemCode{get => itemCode;}

    public Dictionary<string, int> Effects;

    public void InitAsNew()
    {
        Effects = new Dictionary<string, int>();
        // Effects = ItemTypeDatabase.ItemsByCode[itemCode];
    }


}


