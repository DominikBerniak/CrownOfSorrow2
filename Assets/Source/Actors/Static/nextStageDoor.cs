﻿using System.Collections.Generic;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using UnityEditor;

namespace DungeonCrawl.Actors.Static
{
    public class NextStageDoor : Actor
    {
        public override int DefaultSpriteId => 147;
        public override string DefaultName => "Door";

        public NextStageDoor()
        {
        }
        
        public Dictionary<string, int> SpriteVariants = new Dictionary<string, int>()
        {
            {"blueDoor", 431} , {"redDoor", 532}, {"stoneObstacle", 640}, {"openedBlueDoor", 433}
        };
        
        public override void SetSprite(Dictionary<string, int> variants, string key)
        {
            base.SetSprite(SpriteVariants, key);
        }

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
            {
                foreach (Item element in ((Player) anotherActor).Equipment.Items)
                {
                    if (element is FunctionalItem)
                    {
                        if (ItemId == ((FunctionalItem) element).ItemId)
                        {
                            SetSprite(SpriteVariants, "openedBlueDoor");
                            ((Player) anotherActor).Equipment.RemoveItem(element);
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        
        public override bool Detectable => true;
    }
}