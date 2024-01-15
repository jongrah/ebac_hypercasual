using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using Ebac.Core.Singleton;
using TMPro;
using DG.Tweening;
using UnityEngine.UIElements;

public class PlayerController : Singleton<PlayerController>
{
    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1f;
    private Vector3 _pos;

    [Header("Player Settings")]
    public float speed = 1f;
    public float limits = 4f;
    public Vector2 limitVector = new Vector2(-4.5f, 5);

    [Header("Other Settings")]
    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckEndLine = "EndLine";
    private bool _canRun;
    public GameObject endScreen;
    private float _currentSpeed;
    private Vector3 _startPosition;

    [Header("Animator Settings")]
    public AnimatorManager animatorManagers;
    private float _baseSpeedAnimation = 7;

    [Header("Power Up Settings")]
    public bool invencible = false;
    public TextMeshPro uiTextPowerUp;
    public GameObject powerUpText;
    public GameObject coinCollector;

    [Header("Animation Settings")]
    public AnimatorManager animatorManager;
    [SerializeField] private BounceHelper _bounceHelperStart;
    [SerializeField] private DeathBounce _deathBounce;
    [SerializeField] private VictoryBounce _victoryBounce;
    [SerializeField] private PowerUpAnimation _powerUpBounce;

    [Header("VFX Settings")]
    public ParticleSystem vfxDeath;
    public ParticleSystem vfxVictory;


    private void Start()
    {
        _startPosition = transform.position;
        ResetSpeed();
        BouncePlayer();
    }

    void Update()
    {
        if (!_canRun) return;

        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        /*if(_pos.x < -limits) _pos.x = -limits;
        else if(_pos.x > limits) _pos.x = limits;*/

        if(_pos.x < limitVector.x) _pos.x = limitVector.x;
        else if(_pos.x > limitVector.y) _pos.x = limitVector.y;

        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == tagToCheckEnemy)
        {
            if (!invencible)
            {
                MoveBack();
                EndGame(AnimatorManager.AnimationType.DEAD); 
                if (vfxDeath != null) vfxDeath.Play();
                BounceDeath();
            }
        }
    }

    #region BOUNCES
    public void BouncePlayer()
    {
        if(_bounceHelperStart != null) _bounceHelperStart.Bounce();
    }

    public void BouncePowerUp()
    {
        if (_powerUpBounce != null) _powerUpBounce.PowerUpBounce();
    }
    public void BounceDeath()
    {
        if (_deathBounce != null) _deathBounce.DyingBounce();
    }
    public void BounceVictory()
    {
        if (_victoryBounce != null) _victoryBounce.WinnerBounce();
    }

    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == tagToCheckEndLine)
        {
            EndGame(AnimatorManager.AnimationType.VICTORY);
            if (vfxVictory != null) vfxVictory.Play();
            BounceVictory();
        }
    }

    public void MoveBack()
    {
        transform.DOMoveZ(-1f, .3f).SetRelative();
    }

    private void EndGame(AnimatorManager.AnimationType animationType = AnimatorManager.AnimationType.IDLE)
    {
        _canRun = false;
        endScreen.SetActive(true);
        animatorManagers.Play(animationType);
    }

    public void StartToRun()
    {
        _canRun = true;
        animatorManagers.Play(AnimatorManager.AnimationType.RUN, _currentSpeed / _baseSpeedAnimation);
    }

    #region POWER UPs

    public void SetPowerUpText(string s)
    {
        uiTextPowerUp.text = s;
    }

    public void PowerUpSpeedUp(float f)
    {
        _currentSpeed = f;
    }

    public void SetInvencible(bool b)
    {
        invencible = b;
    }

    public void ResetSpeed()
    {
        _currentSpeed = speed;
    }

    public void ChangeHeight(float amount, float duration, float animationDuration, Ease ease)
    {
        /*var p = transform.position;
        p.y = _startPosition.y + amount;
        transform.position = p;*/

        transform.DOMoveY(_startPosition.y + amount, animationDuration).SetEase(ease);
        Invoke(nameof(ResetHeight), duration); 
    }

    public void ResetHeight()
    {
        /*var p = transform.position;
        p.y = _startPosition.y;
        transform.position = p;*/

        transform.DOMoveY(_startPosition.y, .5f);
    }

    public void ChangeCoinCollectorSize(float amount)
    {
        coinCollector.transform.localScale = Vector3.one * amount;
    }

    #endregion
}
