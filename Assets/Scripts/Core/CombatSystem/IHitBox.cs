using Core.BaseComponents;
using UnityEngine;

namespace Core.CombatSystem
{
    public interface IHitBox
    {
        HealthComponent Health { get; }
        AudioClip[] Clips { get; }
    }
}