using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PowerUpAnimation : MonoBehaviour
{

    [Header("Power Up Bounce Animation")]

    public float powerUpScaleDuration = 1.2f;
    public float powerUpScaleBounce = 1.2f;
    public Ease playerEase = Ease.OutBack;

    public void PowerUpBounce()
    {
        transform.DOScale(powerUpScaleBounce, powerUpScaleDuration).SetEase(playerEase).SetLoops(2, LoopType.Yoyo);
    }
}
