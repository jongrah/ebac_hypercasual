using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VictoryBounce : MonoBehaviour
{

    [Header("Victory Bounce")]

    public float victoryScaleDuration = 2f;
    public float victoryUpScaleBounce = 5f;
    public Ease playerEase = Ease.OutBack;

    public void WinnerBounce()
    {
        transform.DOScale(victoryUpScaleBounce, victoryScaleDuration).SetEase(playerEase).SetLoops(2, LoopType.Yoyo);
    }
}
