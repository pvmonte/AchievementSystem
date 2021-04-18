using System.Collections;
using UnityEngine;

public class MovementAnimation : TweenAnimation
{
    [SerializeField] Vector3 startPosition;
    [SerializeField] Vector3 endPosition;

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
        transform.localPosition = TweenPosition(lerpRatio);
    }

    private Vector2 TweenPosition(float lerpRatio)
    {
        return Vector3.LerpUnclamped(startPosition, endPosition, lerpRatio);
    }
}
