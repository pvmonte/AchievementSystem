using System.Collections;
using UnityEngine;

public class WaitingAnimation : TweenAnimation
{
    public override IEnumerator Play()
    {
        yield return new WaitForSeconds(durationInSeconds);
    }
}
