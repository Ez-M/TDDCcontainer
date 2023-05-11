using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMonster : Entity
{


    public override void IsBumped(Entity bumper)
    {
        Debug.Log(bumper + " kicks the spoopy monster!");

       var newHealth = this.Health.DamageHealth(1);

       Debug.Log("TestMonster health is now " + newHealth);

    }

    public override void InitStats()
    {
        this.blocksMovement = true;
        Health.SetBaseHealth(10);
        Health.ResetToBase();
    }
}
