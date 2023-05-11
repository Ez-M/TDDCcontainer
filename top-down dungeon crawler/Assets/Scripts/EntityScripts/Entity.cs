using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[Serializable]
public abstract class Entity : MonoBehaviour
{
    public static int nextId = 1;
    protected int id;

    public int ID { get => id;}

    protected GridManager gridManager;

    [SerializeField]
    protected bool blocksMovement;

    public bool BlocksMovement{get => blocksMovement;}
    public bool isPickable;

    public bool IsPickable{get => isPickable;}

    protected Health health;
    public Health Health {get => health;}
    
    [SerializeField]
    protected InventoryObject inventoryObject;
    public InventoryObject InventoryObject{get => inventoryObject;}

    [SerializeField]
    protected SpriteRenderer spriteRenderer;
    [SerializeField]
    protected Sprite sprite;

    

    public virtual void Awake()
    {
        gameObject.TryGetComponent<Health>(out health);
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();


        gridManager = GridManager.Instance;

        AssignID();
        gridManager.RegisterLocation(gameObject.transform.position, this);
        

        InitStats();
        UpdateSprite(sprite);

    }

    private void AssignID()
    {
        if(gameObject.GetComponent<Player>())
        {
            id = 0;
            gridManager.allEntities.Add(ID, this);
        } else
        {
            id = 1;
            while(gridManager.allEntities.ContainsKey(id))
            {
                id = nextId;
                 nextId++;
            }
            gridManager.allEntities.Add(ID, this);
        }
    }

    public virtual void IsBumped(Entity bumper)
    {//what to do when bumped by another entity, usually the player

    }

    public virtual void Bump(Entity bumpTarget)
    {

    }

    public virtual void InitStats()
    {
        
    }

    public void UpdateSprite(Sprite _sprite)
    {
        sprite = _sprite;
        spriteRenderer.sprite = sprite;
    }
    public virtual void SetInventoryObject(InventoryObject _Inventory)
    {
        inventoryObject = _Inventory;
    }

}
