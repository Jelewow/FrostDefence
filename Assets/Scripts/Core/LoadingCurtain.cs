using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jelewow.FrostDefence.Core
{
    public class LoadingCurtain : MonoBehaviour
    {
        [SerializeField] private float _timeToFade;
        [SerializeField] private CanvasGroup _canvasGroup;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            _canvasGroup.alpha = 1;
        }

        public void Hide()
        {
            StartCoroutine(FadeIn(1f / _timeToFade));
        }

        private IEnumerator FadeIn(float step)
        {
            while (_canvasGroup.alpha >= 0.1f)
            {
                _canvasGroup.alpha = Mathf.Lerp(_canvasGroup.alpha, 0, step * Time.deltaTime);
                step += Time.deltaTime;
                yield return null;
            }

            gameObject.SetActive(false);
        }
    }
}