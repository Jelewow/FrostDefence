using System.Collections;
using UnityEngine;

namespace Jelewow.FrostDefence.Infrastructure
{
    public interface ICoroutineRunner
    {
        public Coroutine StartCoroutine(IEnumerator enumerator);
    }
}