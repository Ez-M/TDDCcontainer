using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Consumable,
    Armor,
    Weapon
}

public enum Attributes
{
    Health,
    Armor,
    Speed,
    Regeneration,
    SightRange,
    AttackDamage
}

[CreateAssetMenu(fileName = "New ItemObject", menuName = "Inventory System/Items/ItemObject")]
[ExecuteAlways]
public class ItemObject : ScriptableObject
{

    //ItemObject = 
    //The generic definition for a specific item, rather than the instance of that item
    //GroundItem =
    //A generic GameObject with a SpriteRenderer and an <Entity>GroundItem component that isPickable and returns an ItemData when picked up
    //ItemData = 
    //contains the relevant information for the instance of an item, including Durabilty/Uses, item type, etc. 

    [SerializeField]
    protected String itemName;
    public String ItemName { get => itemName;}

    [SerializeField]
    protected Sprite sprite;
    public Sprite Sprite { get => sprite; }


    // [SerializeField]
    // private ItemData baseItem;
    // public ItemData BaseItem { get => baseItem;}
    public int inventorySize;

    [SerializeField]
    protected int itemCode;   //tracks the base object this is, the code you would use to spawn it
    public int ItemCode { get => itemCode; }

    [SerializeField]
    protected ItemType itemType;
    public ItemType ItemType { get => itemType; }


    public virtual ItemData OnGrab(ItemData _baseItem, Entity _grabber)
    {
        if (_grabber.InventoryObject.inventory.CheckSpaceTemp())
        { return _baseItem; }
        else
        {
            return null;
        }
    }

    public virtual ItemData OnUse(ItemData _baseItem, Entity _user)
    {
        return _baseItem;
    }

    public void SetItemCode(int _value)
    {
        itemCode = _value;
    }
}

[Serializable]
public class ItemData
{

    public string Name;
    public ItemType Type;

    [SerializeField]
    protected int itemID; //trakcs which individual item this is
    public int ItemID { get => itemID; }

    [SerializeField]
    protected int itemCode;   //tracks the base object this is, the code you would use to spawn it
    public int ItemCode { get => itemCode; }
    [SerializeField]
    protected ItemObject itemObject;
    public ItemObject ItemObject{get => itemObject;}

    public Dictionary<string, int> Effects;

    public ItemData()
    {
        Name = "";
        itemID = -1;
        itemCode = -1;
        itemObject = null;
    }

    public ItemData(ItemObject _itemObject)
    {
        Name = _itemObject.name;
        // itemID = _itemObject.ItemID;
        itemCode = _itemObject.ItemCode;
        itemObject = _itemObject;
    }


}


