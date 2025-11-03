using Core.BaseComponents;
using Core.Interfaces;

namespace Core.Enemies
{
    public interface IEnemyInstance : IStateComponent
    {
        HealthComponent Health { get; }
    }
}