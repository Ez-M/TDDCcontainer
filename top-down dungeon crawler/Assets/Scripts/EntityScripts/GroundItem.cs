using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundItem : Entity
{
    public Sprite sprite;
    public SpriteRenderer spriteRenderer;
    public ItemData itemData;
    public ItemObject itemObject;

    public override void Awake()
    {
        base.Awake();
        itemData = new ItemData(itemObject.BaseItem);
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        sprite = itemObject.Sprite;


    }




}
