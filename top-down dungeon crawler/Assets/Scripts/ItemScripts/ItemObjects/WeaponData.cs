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

    public enum WeaponType
    {
        Ranged,
        Melee
    }

    public enum Ammotype
    {
        bullets,
        cells,
        rockets
    }

public class WeaponData: ItemData
{
    protected WeaponType weaponType;
    public WeaponType WeaponType{get => weaponType;} 

    public RangedAttackStats rangedAttackStats;

    #region MeleeAttackStats

    #endregion

    #region Ammo&Durability
    protected Ammotype ammotype;
    public Ammotype Ammotype{get => ammotype;}
     protected int baseMagCapacity;
     public int BaseMagCapacity{get => baseMagCapacity;}
     protected int currentMagCapacity;
     public int CurrentMagCapacity{get => currentMagCapacity;}
     protected int currentAmmo;
     public int CurrentAmmo{get => currentAmmo;}
    #endregion


    public struct RangedAttackStats
    {
    private int baseDamage;
    public int BaseDamage {get => baseDamage;}
    private int baseBarrierPenetration;
    public int BaseBarrierPenetration{get => baseBarrierPenetration;}
    private int baseAttackRange;
    public int BaseAttackRange{get => baseAttackRange;}

    private int currentDamage;
    public int CurrentDamage {get => currentDamage;}
    private int currentBarrierPenetration;
    public int CurrentBarrierPenetration{get => currentBarrierPenetration;}
    private int currentAttackRange;
    public int CurrentAttackRange{get => currentAttackRange;}


    private DamageType baseRangeDamageType;
    }

}