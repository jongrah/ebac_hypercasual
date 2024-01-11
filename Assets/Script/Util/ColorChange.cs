using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(MeshRenderer))]
public class ColorChange : MonoBehaviour
{
    public Color _startColor = Color.white;
    private Color _correctColor;
    public MeshRenderer meshRenderer;
    public float duration = 1f;

    private void OnValidate()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        _startColor = meshRenderer.materials[0].GetColor("_Color");
        LerpColor();
    }

    private void LerpColor()
    {
        meshRenderer.materials[0].SetColor("_Color", _startColor);
        meshRenderer.materials[0].DOColor(_correctColor, duration).SetDelay(.5f);
    }
}
