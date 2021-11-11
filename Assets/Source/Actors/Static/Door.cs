﻿using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Static
{
    public class Door : Actor
    {
        public override int DefaultSpriteId { get; set; } = 147;
        public override string DefaultName => "Door";

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
            {
                anotherActor.Position = (1, -1);
                MapLoader.CurrentMapId++;
                MapLoader.LoadMap();
                ActorManager.Singleton.DestroyActor(this);
            }

            return false;
        }
        
        public override bool Detectable => true;
    }
}