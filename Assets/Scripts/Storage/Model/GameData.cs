using System;
using System.Collections.Generic;

namespace Storage.Model
{
    [Serializable]
    public class GameData
    {
        public PlayerData PlayerData = new PlayerData();
        public List<EnemyData> Enemies = new();
    }
}