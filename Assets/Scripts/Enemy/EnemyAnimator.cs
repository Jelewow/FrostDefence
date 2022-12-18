using System;
using Jelewow.FrostDefence.Auxiliary;
using UnityEngine;

namespace Jelewow.FrostDefence.Enemy
{
    [RequireComponent(typeof(Animator))]
    public class EnemyAnimator : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayDeathAnimation()
        {
            _animator.SetTrigger(GameConstants.Animation.Die);
        }
    }
}