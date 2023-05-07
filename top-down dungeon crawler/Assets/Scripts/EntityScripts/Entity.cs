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

    public void Awake()
    {

        gridManager = GridManager.instance;

        AssignID();
        gridManager.RegisterLocation(gameObject.transform.position, this);

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

    public virtual void IsBumped()
    {//what to do when bumped by another entity, usually the player

    }

}
