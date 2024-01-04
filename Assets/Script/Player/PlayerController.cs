using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour
{
    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1f;
    private Vector3 _pos;

    [Header("Player Settings")]
    public float speed = 1f;

    void Update()
    {
        _pos = transform.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;


        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }
}
