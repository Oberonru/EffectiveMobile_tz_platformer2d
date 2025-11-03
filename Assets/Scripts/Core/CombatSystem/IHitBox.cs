using Core.BaseComponents;

namespace Core.CombatSystem
{
    public interface IHitBox
    {
        HealthComponent Health { get; }
    }
}