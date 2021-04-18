using System.Collections;
using UnityEngine;

public abstract class TweenAnimation : MonoBehaviour
{
    [SerializeField] protected AnimationCurve _curve;
    [SerializeField] protected float durationInSeconds;

    public abstract IEnumerator Play();
}
