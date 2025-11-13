using System;
using System.Collections.Generic;

namespace Storage.Model
{
    [Serializable]
    public class PlayerData
    {
        public string PlayerName = string.Empty;
        public int PlayerMoney = 0;
        public int Experience = 0;
        public int Level = 1;
        public List<ItemData> Items = new();

        public PlayerData()
        {
        }

        public PlayerData(string playerName, int playerMoney, int experience, int level,  List<ItemData> items)
        {
            PlayerName = playerName;
            PlayerMoney = playerMoney;
            Experience = experience;
            Level = level;
            Items = items;
        }
    }
}