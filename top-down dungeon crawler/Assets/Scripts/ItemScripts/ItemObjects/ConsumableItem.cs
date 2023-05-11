using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable Object", menuName = "Inventory System/Items/Consumables")]
public class ConsumableItem : ItemObject
{

    // public float attackBonus;
    // public float defenseBonus;

    public void OnEnable()
    {
        BaseItem.Type = ItemType.Consumable;

    }

    public override ItemData OnUse(ItemData _baseItem, Entity _user)
    {
        // Implement custom behavior for weapon use
        // ...
        return _baseItem;
    }
}