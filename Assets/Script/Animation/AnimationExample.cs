using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationExample : MonoBehaviour
{
    [Header("Animation Setting")]
    public Animation animationDefault;

    public AnimationClip run;
    public AnimationClip idle;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PlayAnimation(run);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            PlayAnimation(idle);
        }
        
    }

    private void PlayAnimation(AnimationClip c)
    {
        //animation.clip = c;
        animationDefault.CrossFade(c.name);
    }
}
