local streaking = RegisterMod("Streaking Through the Basement", 1)
local loot = require("loot")

-- Variables to give easier access to the elements in the loot.lua table
local heartLootTable = loot["Hearts"].items
local bombLootTable = loot["Bombs"].items
local coinLootTable = loot["Coins"].items
local keyLootTable = loot["Keys"].items
local chestLootTable = loot["Chests"].items
local pillLootTable = loot["Pills"].items
local cardLootTable = loot["Cards"].items
local batteryLootTable = loot["Batteries"].items
local grabBagLootTable = loot["GrabBag"].items

local currentStreak = 0
local maximumStreak = 25

function streaking:spawnItem(itemType, position)
    if itemType == nil then
        Isaac.Spawn(EntityType.ENTITY_PICKUP, PickupVariant.PICKUP_COLLECTIBLE, 0, position, Vector(0, 0), nil)
    else
        local item = streaking:rollWeightedDrop(itemType)
        local variantSubtype = item.variantSubtype
        local pickupVariant = item.pickupVariant
        Isaac.Spawn(EntityType.ENTITY_PICKUP, pickupVariant, variantSubtype, position, Vector(0, 0), nil)
    end
end

-- This table allows function calls to be weighted
local dropFunctions = {
    { name = "spawnHeart",   func = function(position) streaking:spawnItem(heartLootTable, position) end,   weight = 1.5, defaultWeight = 1.5 },
    { name = "spawnBomb",    func = function(position) streaking:spawnItem(bombLootTable, position) end,    weight = 1,   defaultWeight = 1 },
    { name = "spawnChest",   func = function(position) streaking:spawnItem(chestLootTable, position) end,   weight = .5,  defaultWeight = .5 },
    { name = "spawnKey",     func = function(position) streaking:spawnItem(keyLootTable, position) end,     weight = 1,   defaultWeight = 1 },
    { name = "spawnItem",    func = function(position) streaking:spawnItem(nil, position) end,              weight = .5,  defaultWeight = .5 },
    { name = "spawnPill",    func = function(position) streaking:spawnItem(pillLootTable, position) end,    weight = .5,  defaultWeight = .5 },
    { name = "spawnCard",    func = function(position) streaking:spawnItem(cardLootTable, position) end,    weight = .5,  defaultWeight = .5 },
    { name = "spawnBattery", func = function(position) streaking:spawnItem(batteryLootTable, position) end, weight = .5,  defaultWeight = .5 },
    { name = "spawnGrabBag", func = function(position) streaking:spawnItem(grabBagLootTable, position) end, weight = .5,  defaultWeight = .5 },
    { name = "spawnCoin",    func = function(position) streaking:spawnItem(coinLootTable, position) end,    weight = 1,   defaultWeight = 1 },
}

-- This function renders the current Streak text to the screen
local function onRender(t)
    local f = Font() -- init font object
    f:Load("font/upheaval.fnt")
    if currentStreak >= maximumStreak then
        f:DrawStringScaled("Streak : MAX", 5, 80, 0.36, 0.36, KColor(0, 0, 0, 1), 0, 0) -- Black drop shadow
        f:DrawStringScaled("Streak : MAX", 5, 80, 0.35, 0.35, KColor(1, 1, 1, 1), 0, 0) -- White normal text
    else
        -- load a font into the font object
        f:DrawStringScaled("Streak : " .. currentStreak, 5, 80, 0.36, 0.36, KColor(0, 0, 0, 1), 0, 0) -- Black drop shadow
        f:DrawStringScaled("Streak : " .. currentStreak, 5, 80, 0.35, 0.35, KColor(1, 1, 1, 1), 0, 0) -- White normal text
    end

    -- f:DrawStringScaled("Streaking Through", 130, 80, 1, 1, KColor(0, 0, 0, 1), 0, 0) -- Black drop shadow
    -- f:DrawStringScaled("Streaking Through", 130, 80, 0.99, 0.99, KColor(1, 1, 1, 1), 0, 0) -- White normal text
    -- f:DrawStringScaled("The Basement", 160, 100, 1, 1, KColor(0, 0, 0, 1), 0, 0) -- Black drop shadow
    -- f:DrawStringScaled("The Basement", 160, 100, 0.99, 0.99, KColor(1, 1, 1, 1), 0, 0) -- White normal text
end

-- This version of onPostEffectUpdate() increased the streak of the player for every kill
function streaking:onPostEffectUpdate()
    -- Get all entities in the current room
    for i, entity in pairs(Isaac.GetRoomEntities()) do
        -- Check if the entity is an NPC and if it is dead
        if entity:IsEnemy() and entity:IsDead() and not entity:IsBoss() then
            if currentStreak < maximumStreak then
                currentStreak = currentStreak + 1
            end

            if currentStreak >= 2 then
                local rand = math.random(1, 59) -- 59 is a 42.4% chance of a drop at a max streak of 25

                if rand <= currentStreak then
                    local totalWeight = 0
                    for _, drop in ipairs(dropFunctions) do
                        totalWeight = totalWeight + drop.weight
                    end

                    local roll = math.random() * totalWeight

                    for _, drop in ipairs(dropFunctions) do
                        if roll <= drop.weight then
                            drop.func(entity.Position)
                            break
                        else
                            roll = roll - drop.weight
                        end
                    end
                end
            end
        end
    end
end

function streaking:resetItemWeight(name)
    for _, drop in ipairs(dropFunctions) do
        if drop.name == name then
            drop.weight = drop.defaultWeight
            break
        end
    end
end

function streaking:increaseItemWeight(name, increase)
    for _, drop in ipairs(dropFunctions) do
        if drop.name == name then
            drop.weight = drop.weight + increase
            break
        end
    end
end

function streaking:resetStreak()
    currentStreak = 0
end

function streaking:rollWeightedDrop(items)
    local cumulativeWeight = 0
    local cumulativeWeights = {}

    -- Calculate cumulative weights
    for i, item in ipairs(items) do
        cumulativeWeight = cumulativeWeight + item.weight
        table.insert(cumulativeWeights, cumulativeWeight)
    end

    -- Roll a number between 0 and the total weight
    local roll = math.random() * cumulativeWeight

    -- Find the item that corresponds to this roll
    for i, weight in ipairs(cumulativeWeights) do
        if roll <= weight then
            return items[i]
        end
    end
    -- If no item was found, return the last item
    return items[#items]
end

streaking:AddCallback(ModCallbacks.MC_POST_RENDER, onRender)
streaking:AddCallback(ModCallbacks.MC_POST_PEFFECT_UPDATE, streaking.onPostEffectUpdate)
streaking:AddCallback(ModCallbacks.MC_ENTITY_TAKE_DMG, streaking.resetStreak, EntityType.ENTITY_PLAYER)
streaking:AddCallback(ModCallbacks.MC_POST_GAME_STARTED, streaking.resetStreak)
