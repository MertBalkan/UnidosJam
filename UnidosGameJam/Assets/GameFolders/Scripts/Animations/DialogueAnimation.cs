using System;
using UnityEngine;

namespace UnidosJam.Animations
{
    public class DialogueAnimation : MonoBehaviour
    {
        private Animator _animator;
        private static readonly int StartDialogue = Animator.StringToHash("StartDialogue");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayAnimation()
        {
            _animator.SetTrigger(StartDialogue);
        }
    }
}