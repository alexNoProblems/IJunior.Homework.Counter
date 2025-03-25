using UnityEngine;
using TMPro;

[RequireComponent(typeof(Counter))]
public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;

    private Counter _counter;
    
    private void Awake()
    {
        _counter = GetComponent<Counter>();
    }

    private void OnEnable()
    {
        _counter.CounterValueChanged += OnCounterValueChanged;
    }

    private void OnDisable()
    {
        _counter.CounterValueChanged -= OnCounterValueChanged;
    }

    private void OnCounterValueChanged(int value)
    {
        if (_counterText)
            _counterText.text = value.ToString();
    }
}
