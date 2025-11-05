using Core.BaseComponents;
using Core.Interfaces;
using UnityEngine;

namespace Core.Enemies
{
    public interface IEnemyInstance : IStateComponent
    {
        HealthComponent Health { get; }
        Transform Transform { get; }
    }
}