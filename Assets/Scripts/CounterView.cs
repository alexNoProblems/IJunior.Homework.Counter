using UnityEngine;
using TMPro;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;
    [SerializeField] private Counter _counter;
    
    private void Awake()
    {
        if (_counter == null)
        {
            Debug.LogError("CounterView: Counter не назначен!");
            enabled = false;
            
            return;
        }

        if (_counterText == null)
        {
            Debug.LogError("CounterView: TextMeshProUGUI не назначен!");
            enabled = false;
        }
            
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
        _counterText.text = value.ToString();
    }
}
