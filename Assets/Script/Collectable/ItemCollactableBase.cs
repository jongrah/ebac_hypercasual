using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollactableBase : MonoBehaviour
{
    public string compareTag = "Player";
    public ParticleSystem particleCoin;
    public float timeToHide = 3;
    public GameObject graphicItem;

    [Header("Sounds")]
    public AudioSource audioSource;


    private void Awake()
    {
        if (audioSource != null)
        {
            audioSource.transform.parent = null;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        HideObject();
        OnCollect();
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }

    private void DelayParticleCoin()
    {
        particleCoin.transform.parent = null;
        particleCoin.Play();
    }

    protected virtual void OnCollect()
    {
        if (particleCoin != null)
        {
            DelayParticleCoin();
        }

        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
