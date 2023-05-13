using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : Entity
{


    public override void Bump(Entity bumpTarget)
    {
        bumpTarget.IsBumped(this);
        Health.HealMaxHealth(1);
    }

public override void InitStats()
    {
        Health.SetBaseHealth(10);
        Health.ResetToBase();

    }
    
}
