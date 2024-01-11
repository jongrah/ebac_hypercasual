using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using DG.Tweening;

public class CoinsAnimationManager : Singleton<CoinsAnimationManager>
{
    [Header("Coin Animation")]

    public float coinScaleDuration = .2f;
    public float coinScaleTimeBetweenPieces = .1f;
    public Ease coinEase = Ease.OutBack;
    public List<ItemCollactableCoin> itens;

    private void Start()
    {
        itens = new List<ItemCollactableCoin>();
    }

    public void RegisterCoin(ItemCollactableCoin i)
    {
        if (!itens.Contains(i))
        {
            itens.Add(i);
            i.transform.localScale = Vector3.zero;
        }
    }

    public void StartAnimations()
    {
        StartCoroutine(CoinScalePiecesByTime());
    }


    IEnumerator CoinScalePiecesByTime()
    {
        foreach (var p in itens)
        {
            p.transform.localScale = Vector3.zero;
        }

        Sort();
        yield return null;

        for (int i = 0; i < itens.Count; i++)
        {
            itens[i].transform.DOScale(1, coinScaleDuration).SetEase(coinEase);
            yield return new WaitForSeconds(coinScaleTimeBetweenPieces);
        }
    }

    private void Sort()
    {
        itens = itens.OrderBy(
            x => Vector3.Distance(this.transform.position, x.transform.position)).ToList();
    }
}
