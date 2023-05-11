using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GroundItem : Entity
{
    public ItemData itemData;
    public ItemObject itemObject;

    public override void Awake()
    {
        base.Awake();



    }

    public override void InitStats()
    {
        itemData = new ItemData(itemObject);
        sprite = itemObject.Sprite;
        isPickable = true;
    }




}
