using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public enum DamageType
    {
        Ballistic, 
        Thermal,
        Cryo,
        Shock,
        Radiation,

    }

public class WeaponData: ItemData
{

    #region RangedAttackStats
    protected int baseDamage;
    protected int basePenetration;

    protected DamageType baseRangeDamageType;
    #endregion

    #region MeleeAttackStats

    #endregion

    #region Ammo&Durability
    // ammotype - baseMagCapacity - currentMagCapacity - currentAmmo - baseAmmoPerShot - currentAmmoPerShot
    #endregion


}