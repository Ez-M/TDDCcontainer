using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMonster : Entity
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void IsBumped()
    {
        Debug.Log("A spoopy monster!");
    }
}
