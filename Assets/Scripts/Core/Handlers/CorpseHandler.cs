using System;
using Core.BaseComponents;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Core.Handlers
{
    [RequireComponent(typeof(HealthComponent))]
    public class CorpseHandler : MonoBehaviour
    {
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private StateComponentHandler _stateHandler;
        [SerializeField] private float _destroyedTime = 0.5f;

        private void OnEnable()
        {
            _healthComponent.OnDead.
                DistinctUntilChanged().
                Subscribe(_ => HandleDeath().Forget()).
                AddTo(this);
        }

        private async UniTask HandleDeath()
        {
            try
            {
                _stateHandler.DisableAllComponents();
                
                await UniTask.Delay(TimeSpan.FromSeconds(_destroyedTime),
                    cancellationToken: this.GetCancellationTokenOnDestroy());

                Destroy(this.gameObject);
            }
            catch (OperationCanceledException e)
            {
            }
        }
    }
}