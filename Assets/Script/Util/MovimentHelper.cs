using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentHelper : MonoBehaviour
{
    [Header("Moviment Settings")]
    public List<Transform> position;
    public float duration = 1f;
    private int _index = 0;

    private void Start()
    {
        transform.position = position[0].transform.position;
        NextIndex();
        StartCoroutine(StartMoviment());
    }

    private void NextIndex()
    {
        _index++;

        if (_index >= position.Count) _index = 0;
    }
    IEnumerator StartMoviment()
    {
        float _time = 0;

        while (true)
        {
            var currentPositionMove = transform.position;

            while (_time < duration)
            {
                transform.position = Vector3.Lerp(currentPositionMove, position[_index].transform.position, (_time/duration));
                _time += Time.deltaTime;
                yield return null;
            }

            NextIndex();
            _time = 0;

            yield return null;
        }
    }
}
