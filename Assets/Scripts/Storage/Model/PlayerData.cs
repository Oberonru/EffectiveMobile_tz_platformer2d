using System;
using System.Collections.Generic;

namespace Storage.Model
{
    [Serializable]
    public class PlayerData
    {
        public List<ItemData> Items = new();
        public string PlayerName = string.Empty;
        public int PlayerMoney = 0;
        public int Experience = 0;
        public int Level = 1;

        public PlayerData() {}
        
        public PlayerData(List<ItemData> items, string playerName, int playerMoney, int experience, int level)
        {
            Items = items;
            PlayerName = playerName;
            PlayerMoney = playerMoney;
            Experience = experience;
            Level = level;
        }
    }
}