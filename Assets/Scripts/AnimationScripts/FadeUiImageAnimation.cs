using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeUiImageAnimation : TweenAnimation
{
    [SerializeField] Image image;

    private void Start() {
        image = GetComponent<Image>();
    }

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

    protected virtual void UpdateOpacity(float timer)
    {
        float lerpRatio = _curve.Evaluate(timer);
        Color c = image.color;
        c.a = TweenOpacity(lerpRatio);
        image.color = c;
    }

    protected float TweenOpacity(float lerpRatio)
    {
        return Mathf.LerpUnclamped(0, 1, lerpRatio);
    }
}
