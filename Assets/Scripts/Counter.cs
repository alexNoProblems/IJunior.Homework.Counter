using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _waitingTime = 0.5f;

    private int _count = 0;
    private bool _isRunning = false;

    private Coroutine _counterCoroutine;

    public event Action<int> CounterValueChanged;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _isRunning = !_isRunning;

            if (_counterCoroutine != null)
            {
                StopCoroutine(_counterCoroutine);
                _counterCoroutine = null;
            }

            if (_isRunning)
                _counterCoroutine = StartCoroutine(CountCoroutine());
        }
    }

    private IEnumerator CountCoroutine()
    {
        var wait = new WaitForSeconds(_waitingTime);

        while (_isRunning)
        {
            _count++;
            CounterValueChanged?.Invoke(_count);

            yield return wait;
        }
    }
}
