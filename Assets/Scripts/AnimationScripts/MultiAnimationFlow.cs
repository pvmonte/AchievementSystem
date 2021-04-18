using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiAnimationFlow : MonoBehaviour
{
    [SerializeField] TweenAnimation[] _animations;

    public IEnumerator Play()
    {
        for (int i = 0; i < _animations.Length; i++)
        {
            yield return _animations[i].Play();
        }
    }
}
