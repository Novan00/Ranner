using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Heart : MonoBehaviour
{
    [SerializeField] private float _lerpDuration;

    private Image _image;
    private Coroutine _coroutine;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.fillAmount = 1;
    }

    public void ToFill()
    {
        ChangeHeartValue(0, 1, _lerpDuration, Fill);
    }

    public void ToEmpty()
    {
        ChangeHeartValue(1, 0, _lerpDuration, Destroy);
    }

    private void Destroy(float value)
    {
        _image.fillAmount = value;
        Destroy(gameObject);
    }

    private void Fill(float value)
    {
        _image.fillAmount = value;
    }

    private IEnumerator Filling(float startValue, float endValue, float duration, Action<float> learpingEnd)
    {
        float elapsed = 0;
        float nextValue;

        while (elapsed < duration)
        {
            nextValue = Mathf.Lerp(startValue, endValue, elapsed / duration);
            _image.fillAmount = nextValue;
            elapsed += Time.deltaTime;

            yield return null;
        }

        learpingEnd?.Invoke(endValue);
    }

    private void ChangeHeartValue(float startValue, float endValue, float duration, Action<float> learpingEnd)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(Filling(startValue, endValue, duration, learpingEnd));
    }
}
