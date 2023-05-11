using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ItemTypeDatabase", menuName = "ItemTypeDatabase")]
[ExecuteAlways]

public class ItemTypeDatabase : ScriptableObject, ISerializationCallbackReceiver
{
    public ItemObject[] Items;
    [SerializeField]
    private Dictionary<int, ItemObject> itemsByCode = new Dictionary<int, ItemObject>();
    public Dictionary<int, ItemObject> ItemsByCode{get => itemsByCode;}

    private static ItemTypeDatabase instance;
    public static ItemTypeDatabase Instance {get => instance;}


    private void OnEnable()
    {

        verifyInstanceSingleton();
        for (int i = 0; i < itemsByCode.Keys.Count; i++)
        {
            itemsByCode[i].BaseItem.SetItemCode(itemsByCode[i].ItemCode);
        }

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
            Items[i].SetItemCode(i);

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