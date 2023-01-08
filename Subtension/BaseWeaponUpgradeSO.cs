using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// All weapon upgrades use this class for their type, status, multiplier, and activation.
/// Each new weapon upgrade is meant to override the ActivateUpgrade() method with the desired behavior.
/// 
/// Weapon upgrades are loaded in the battle scene by the PlayerUpgrades script/manager.
/// 
/// The PlayerUpgrades script reads the upgradeStatus which is set to true by the ShipUpgradeManager script
/// when an upgrade is purchased from the shop.
/// 
/// Dan Hassett, 10/8/22
/// </summary>

public enum UpgradeTypes {Damage, WeaponCharge, CriticalHitRate, ShieldCharge, AntiHazard}

public class BaseWeaponUpgradeSO : ScriptableObject
{
    [Tooltip("A multiplier of the weapon's type of upgrade. For example, if you want to cut " +
        "the the value in HALF, set it to 0.5. If you want to DOUBLE it, set it to 2.")]
    public float upgradeMultiplier = 1.0f;
    public bool upgradeStatus = false;

    public virtual void SetUpgradeStatus (bool status)
    {
        upgradeStatus = status;
    }

    public virtual void ActivateUpgrade() { }

}
