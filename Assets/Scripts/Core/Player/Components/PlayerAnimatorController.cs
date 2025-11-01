using UniRx;
using UnityEngine;

namespace Core.Player.Components
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimatorController : MonoBehaviour
    {
        [SerializeField] Animator _animator;
        [SerializeField] PlayerController _controller;

        private static readonly int JumpHash = Animator.StringToHash("Jump");
        private static readonly int RunHash = Animator.StringToHash("IsRun");
        private static readonly int AttackHash = Animator.StringToHash("Attack");
        private static readonly int DeathHash = Animator.StringToHash("Death");

        private void OnEnable()
        {
            _controller.OnJump.
                Subscribe(_ => _animator.SetTrigger(JumpHash)).
                AddTo(this);
            
            _controller.OnRun.
                DistinctUntilChanged().
                Subscribe(isRun => _animator.SetBool(RunHash,  isRun)).
                AddTo(this);
            
            _controller.OnAttack.
                Subscribe(_ => _animator.SetTrigger(AttackHash)).
                AddTo(this);
        }
        
        private void OnValidate()
        {
            if (_animator == null) _animator = GetComponent<Animator>();
            if (_controller == null) _controller = GetComponent<PlayerController>();
        }
    }
}