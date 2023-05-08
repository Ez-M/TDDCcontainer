using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ItemTypeDatabase", menuName = "ItemTypeDatabase")]

public class ItemTypeDatabase : ScriptableObject
{
    [SerializeField]
    private Dictionary<int, ItemData> itemsByCode;
    public Dictionary<int, ItemData> ItemsByCode{get => itemsByCode;}

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
    
    private void OnDisable()
    {
        if(Instance == this)
        {
            instance = null;
        }
    }


}