using System.Collections;
using UnityEngine;

public class UiElementMovementAnimation : TweenAnimation
{
    [SerializeField] Vector2 startPosition;
    [SerializeField] Vector2 endPosition;
    [SerializeField] RectTransform _rectTransform;

    public override IEnumerator Play()
    {
        float timer = 0;

        while (timer < 1)
        {
            UpdatePosition(timer);
            timer += Time.deltaTime / durationInSeconds;
            yield return null;
        }

        UpdatePosition(1);
    }

    private void UpdatePosition(float timer)
    {
        float lerpRatio = _curve.Evaluate(timer);
        _rectTransform.anchoredPosition = TweenPosition(lerpRatio);
    }

    private Vector2 TweenPosition(float lerpRatio)
    {
        return Vector2.LerpUnclamped(startPosition, endPosition, lerpRatio);
    }
}
