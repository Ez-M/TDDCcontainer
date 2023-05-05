using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public static int nextId = 0;
    private int id;

    public int ID { get => id;}

    public void Awake()
    {
       while(GridManager.instance.allEntities.ContainsKey(id))
       {
        id = nextId;
        nextId++;
       }

    }


}
