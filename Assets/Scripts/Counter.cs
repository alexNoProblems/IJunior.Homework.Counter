using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public event Action<int> CounterValueChanged;

    [SerializeField] private float _waitingTime = 0.5f;

    private int _count = 0;
    private bool _isRunning = false;
    
    private void Start()
    {
        StartCoroutine(CountCoroutine());
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
            _isRunning = !_isRunning;
    }

    private IEnumerator CountCoroutine()
    {
        var wait = new WaitForSeconds(_waitingTime);

        while (true)
        {
            if (_isRunning == true)
            {
                _count++;
                CounterValueChanged?.Invoke(_count);
            }

            yield return wait;
        }
    }
}
