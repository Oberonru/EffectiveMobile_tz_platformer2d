using UnityEngine;

namespace Core.CombatSystem
{
    public struct DamageContext
    {
        public int Damage;
        public Vector2 AttackerPosition;
        public float ThrowingForce;

        public DamageContext(int damage, Vector2 attackerPosition, float throwingForce)
        {
            Damage = damage;
            AttackerPosition = attackerPosition;
            ThrowingForce = throwingForce;
        }
    }
}