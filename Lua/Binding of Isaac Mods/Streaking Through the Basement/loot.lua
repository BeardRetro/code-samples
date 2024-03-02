-- variantSubtype is value of the item type in the SubType Enum from the documentation
local lootTable = {
    Hearts = {
        items = {
            { name = "FullRedHeart", weight = 0.41, variantSubtype = 1, pickupVariant = PickupVariant.PICKUP_HEART },
            { name = "HalfRedHeart", weight = 0.41, variantSubtype = 2, pickupVariant = PickupVariant.PICKUP_HEART },
            { name = "FullSoulHeart", weight = 0.069, variantSubtype = 3, pickupVariant = PickupVariant.PICKUP_HEART },
            { name = "EternalHeart", weight = 0.018, variantSubtype = 4, pickupVariant = PickupVariant.PICKUP_HEART },
            { name = "DoubleHeart", weight = 0.043, variantSubtype = 5, pickupVariant = PickupVariant.PICKUP_HEART },
            { name = "BlackHeart", weight = 0.005, variantSubtype = 6, pickupVariant = PickupVariant.PICKUP_HEART },
            { name = "GoldHeart", weight = 0.006, variantSubtype = 7, pickupVariant = PickupVariant.PICKUP_HEART },
            { name = "HalfSoulHeart", weight = 0.023, variantSubtype = 8, pickupVariant = PickupVariant.PICKUP_HEART },
            { name = "BlendedHeart", weight = 0.009, variantSubtype = 10, pickupVariant = PickupVariant.PICKUP_HEART },
            { name = "BoneHeart", weight = 0.005, variantSubtype = 11, pickupVariant = PickupVariant.PICKUP_HEART },
        }
    },
    
    Bombs = {
        items = {
            { name = "Bomb", weight = 0.849, variantSubtype = 1, pickupVariant = PickupVariant.PICKUP_BOMB },
            { name = "DoubleBomb", weight = 0.141, variantSubtype = 2, pickupVariant = PickupVariant.PICKUP_BOMB },
            { name = "GoldenBomb", weight = 0.01, variantSubtype = 4, pickupVariant = PickupVariant.PICKUP_BOMB },
        }
    },

    Coins = {
        items = {
            { name = "Penny", weight = 0.933, variantSubtype = 1, pickupVariant = PickupVariant.PICKUP_COIN },
            { name = "Nickel", weight = 0.047, variantSubtype = 2, pickupVariant = PickupVariant.PICKUP_COIN },
            { name = "Dime", weight = 0.01, variantSubtype = 3, pickupVariant = PickupVariant.PICKUP_COIN },
            { name = "LuckyPenny", weight = 0.009, variantSubtype = 5, pickupVariant = PickupVariant.PICKUP_COIN },
        }
    },

    Keys = {
        items = {
            { name = "Key", weight = 0.961, variantSubtype = 1, pickupVariant = PickupVariant.PICKUP_KEY },
            { name = "GoldenKey", weight = 0.02, variantSubtype = 2, pickupVariant = PickupVariant.PICKUP_KEY },
            { name = "ChargedKey", weight = 0.02, variantSubtype = 4, pickupVariant = PickupVariant.PICKUP_KEY },
        }
    },
    
    Chests = {
        items = {
            { name = "Chest", weight = 0.2, variantSubtype = 0, pickupVariant = PickupVariant.PICKUP_CHEST },
            { name = "LockedChest", weight = 0.2, variantSubtype = 1, pickupVariant = PickupVariant.PICKUP_LOCKEDCHEST },
            { name = "RedChest", weight = 0.2, variantSubtype = 0, pickupVariant = PickupVariant.PICKUP_REDCHEST },
            { name = "BombChest", weight = 0.2, variantSubtype = 0, pickupVariant = PickupVariant.PICKUP_BOMBCHEST },
            { name = "EternalChest", weight = 0.2, variantSubtype = 0, pickupVariant = PickupVariant.PICKUP_ETERNALCHEST },
        }
    },

    -- Pill Effect and Pill Color might need to be tweaked after testing
    Pills = {
        items = {
            { name = "RandomPill", weight = 1, variantSubtype = 0, pickupVariant = PickupVariant.PICKUP_PILL },
        }
    },

    Cards = {
        items = {
            { name = "RandomCard", weight = 1, variantSubtype = 0, pickupVariant = PickupVariant.PICKUP_TAROTCARD },
        }
    },

    Batteries = {
        items = {
            { name = "NormalBattery", weight = 1, variantSubtype = 1, pickupVariant = PickupVariant.PICKUP_LIL_BATTERY },
        }
    },

    GrabBag = {
        items = {
            { name = "GrabBag", weight = 1, variantSubtype = 0, pickupVariant = PickupVariant.PICKUP_GRAB_BAG },
        }
    },
    
}

return lootTable