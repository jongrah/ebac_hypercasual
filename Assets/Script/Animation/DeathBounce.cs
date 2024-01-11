using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DeathBounce : MonoBehaviour
{

    [Header("Death Bounce")]

    public float deathScaleDuration = 2f;
    public float deathScaleBounce = 3f;
    public Ease playerEase = Ease.OutBack;

    public void DyingBounce()
    {
        transform.DOScale(deathScaleBounce, deathScaleDuration).SetEase(playerEase).SetLoops(2, LoopType.Yoyo);
    }
}
