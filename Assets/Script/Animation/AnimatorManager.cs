using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public Animator generalAnimator;
    public List<AnimatorSetup> animatorSetups;


   public enum AnimationType
    {
        IDLE,
        RUN,
        DEAD,
        VICTORY
    }

    public void Play(AnimationType type, float currentSpeedFactor = 1)
    {
        foreach (var animation in animatorSetups)
        {
            if (animation.type == type)
            {
                generalAnimator.SetTrigger(animation.trigger);
                generalAnimator.speed = animation.speed * currentSpeedFactor;
                break;
            }
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Play(AnimationType.RUN);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Play(AnimationType.DEAD);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Play(AnimationType.IDLE);
        }
    }
}


[System.Serializable]
public class AnimatorSetup
{
    public AnimatorManager.AnimationType type;
    public string trigger;
    public float speed = 1f;
}