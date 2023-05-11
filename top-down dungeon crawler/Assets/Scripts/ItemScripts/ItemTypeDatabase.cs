using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ItemTypeDatabase", menuName = "ItemTypeDatabase")]

public class ItemTypeDatabase : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeReference]
    public ItemObject[] Items;
    [SerializeField]
    private Dictionary<int, ItemObject> itemsByCode = new Dictionary<int, ItemObject>();
    public Dictionary<int, ItemObject> ItemsByCode{get => itemsByCode;}

    private static ItemTypeDatabase instance;
    public static ItemTypeDatabase Instance {get => instance;}

    private void Awake()
    {
        verifyInstanceSingleton();
    }

    private void OnEnable()
    {
        verifyInstanceSingleton();
    }

    
    private void OnDisable()
    {
        if(Instance == this)
        {
            instance = null;
        }
    }

    public void OnBeforeSerialize()
    {
        itemsByCode = new Dictionary<int, ItemObject>();
    }

    public void OnAfterDeserialize()
    {
        for (int i = 0; i < Items.Length; i++)
        {
            Items[i].BaseItem.SetItemCode(i);
            itemsByCode.Add(i, Items[i]);
        }
    }


    private void verifyInstanceSingleton()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
}