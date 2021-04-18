using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeCanvasGroup : FadeUiImageAnimation
{
    [SerializeField] CanvasGroup canvasGroup;

    public override IEnumerator Play()
    {
        float timer = 0;

        while (timer < 1)
        {
            UpdateOpacity(timer);
            timer += Time.deltaTime / durationInSeconds;
            yield return null;
        }

        UpdateOpacity(1);
    }

    protected override void UpdateOpacity(float timer)
    {
        float lerpRatio = _curve.Evaluate(timer);
        canvasGroup.alpha = TweenOpacity(lerpRatio);
    }
}
