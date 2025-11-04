using System;

namespace Storage.Model
{
    [Serializable]
    public class EnemyData
    {
        public string Id;
        public string Name;
        public int Level;
        public int Damage;
        public int MaxHealth;
        public int CurrentHealth;

        public EnemyData(string id, string name, int level, int damage, int maxHealth, int currentHealth)
        {
            Id = id;
            Name = name;
            Level = level;
            Damage = damage;
            MaxHealth = maxHealth;
            CurrentHealth = currentHealth;
        }
    }
}