using System;

namespace Storage.Model
{
    [Serializable]
    public class EnemyData
    {
        public string Name = string.Empty;
        public int Level = 1;
        public int Damage = 1;
        public int MaxHealth = 0; 

        public EnemyData(string name, int level,  int damage,  int maxHealth)
        {
            Name = name;
            Level = level;
            Damage = damage;
            MaxHealth = maxHealth;
        }
    }
}