using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class exists to load the upgrades purchased from the shop into the battle scenes
/// Dan Hassett, 10/8/22
/// </summary>
public class PlayerUpgrades : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LoadUpgrades();
    }

    // This method loads any upgrades which have been purchased from the shop by reading data from a static dictionary
    void LoadUpgrades()
    {
        foreach (KeyValuePair<BaseWeaponUpgradeSO, bool> entry in ShipUpgradeManager.weaponUpgradeDictionary)
        {
            if (entry.Value == true)
            {
                entry.Key.ActivateUpgrade();
                EventBus.Publish(new UpgradeAddedEvent(entry.Key.GetType(), entry.Key, false));
            }
        }
    }
}
