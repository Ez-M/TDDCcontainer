using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[Serializable]
public abstract class Entity : MonoBehaviour
{
    public static int nextId = 1;
    private int id;

    public int ID { get => id;}

    private GridManager gridManager;

    [SerializeField]
    private bool blocksMovement;

    public bool BlocksMovement{get => blocksMovement;}

    private Health health;
    public Health Health {get => health;}

    public void Awake()
    {
        gameObject.TryGetComponent<Health>(out health);

        gridManager = GridManager.Instance;

        AssignID();
        gridManager.RegisterLocation(gameObject.transform.position, this);

        InitStats();

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

}
