using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handles the various upgrade systems of the ship which are purchased in the shop.
/// The upgrades are loaded in the battle scene by the PlayerUpgrades script/manager
/// 
/// Dan Hassett, 10/1/22
/// </summary>

public class ShipUpgradeManager : MonoBehaviour
{
    [Header("Weapon Upgrade Scriptable Objects")]
    public BaseWeaponUpgradeSO[] upgrades;

    public WeaponRoomSO[] weaponRooms;
    public ShieldRoomSO[] shieldRooms;

    public static Dictionary<BaseWeaponUpgradeSO, bool> weaponUpgradeDictionary = new Dictionary<BaseWeaponUpgradeSO, bool>();
    public static Dictionary<string, WeaponRoomSO[]> weaponRoomSODictionary = new Dictionary<string, WeaponRoomSO[]>();
    public static ShieldRoomSO[] staticShieldRooms;

    // Awake() loads the necessary upgrade and room scriptable objects into the static Dictionaries.
    // The weaponRooms array must be filled with WeaponRoomSO scriptable objects in the inspector in Unity.
    private void Awake()
    {
        for(int a = 0; a < upgrades.Length; a++)
        {
            if (weaponUpgradeDictionary.ContainsKey(upgrades[a]) == false)
            {
                weaponUpgradeDictionary.Add(upgrades[a], false);
            }
        }

        if (weaponRoomSODictionary.ContainsKey("weaponRooms") == false)
        {
            weaponRoomSODictionary.Add("weaponRooms", weaponRooms);
        }     
    }

    // This method should be attached to the "Purchase" button in the Ship Upgrades section of the Shop Scene.
    // When an upgrade is purchased in the Shop scene, this method changes the value to "true"
    // so that the PlayerUpgrade script knows which upgrades to activate in the Battle scenes
    public void UpgradePurchased(UpgradeTypes upgrade)
    {
        switch (upgrade)
        {
            case UpgradeTypes.Damage:
                //Debug.Log("ShipUpgradeManager: DAMAGE UPGRADE UPGRADE purchased");
                upgrades[0].SetUpgradeStatus(true);
                break;

            case UpgradeTypes.WeaponCharge:
                //Debug.Log("ShipUpgradeManager: CHARGE SPEED UPGRADE purchased");
                upgrades[1].SetUpgradeStatus(true);
                break;

            case UpgradeTypes.CriticalHitRate:
                //Debug.Log("ShipUpgradeManager: CRITICAL HIT UPGRADE purchased");
                upgrades[2].SetUpgradeStatus(true);
                break;

            case UpgradeTypes.ShieldCharge:
                upgrades[3].SetUpgradeStatus(true);
                break;

            case UpgradeTypes.AntiHazard:
                upgrades[4].SetUpgradeStatus(true);
                break;

            default:
                Debug.LogError(upgrade + " is an invalid upgrade type");
                break;
        }
    }
}