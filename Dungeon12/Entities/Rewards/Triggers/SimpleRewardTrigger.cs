﻿using Dungeon;
using Dungeon12.Map;
using Dungeon.View.Interfaces;
using Dungeon12.Entities.Quests;
using Dungeon12.Classes;
using Dungeon12.Loot;

namespace Dungeon12.Entities.Rewards.Triggers
{
    public class SimpleRewardTrigger : IRewardTrigger
    {
        public IDrawText Trigger(Reward arg1, Character arg2, GameMap arg3)
        {
            arg2.Exp(arg1.Exp);
            arg2.Gold += arg1.Gold;

            if (arg1.ItemGenerators != default)
            {
                foreach (var generator in arg1.ItemGenerators)
                {
                    var loot = new Dungeon12.Map.Objects.Loot();
                    loot.Location = Global.GameState.Player.Avatar.Location.Copy();
                    loot.Item = generator.Generate();

                    Global.GameState.Map.MapObject.Add(loot);
                    Global.GameState.Map.PublishObject(loot);                    
                }
            }

            if (arg1.LootDrops != default && arg1.LootTables!=default)
            {
                foreach (var lootDrop in arg1.LootDrops)
                {
                    foreach (var lootTable in arg1.LootTables)
                    {
                        var lt = LootTable.GetLootTable(lootTable);
                        lt.LootDrops.Add(lootDrop);
                    }
                }
            }

            if (arg1.Varible != default)
            {
                Global.GameState.Character[arg1.Varible] = true;
            }

            return " ".AsDrawText();
        }
    }
}
