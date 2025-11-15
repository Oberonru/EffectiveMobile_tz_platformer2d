using System;

namespace Storage.Model
{
    [Serializable]
    public class EnemyData
    {
        public string ID;
        public int Level;
        public int Damage;
        public int MaxHealth;
        public int CurrentHealth;

        public EnemyData(int level, int damage, int maxHealth, int currentHealth)
        {
            ID = Guid.NewGuid().ToString();
            Level = level;
            Damage = damage;
            MaxHealth = maxHealth;
            CurrentHealth = currentHealth;
        }
    }
}