using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BounceHelper : MonoBehaviour
{
    [Header("Bounce Animation")]

    public float playerScaleDuration = .2f;
    public float playerScaleBounce = .1f;
    public Ease playerEase = Ease.OutBack;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Bounce();
        }
    }

    public void Bounce()
    {
        transform.DOScale(playerScaleBounce, playerScaleDuration).SetEase(playerEase).SetLoops(2, LoopType.Yoyo);
    }
}
