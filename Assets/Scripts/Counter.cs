using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;
    [SerializeField] private float _waitingTime = 0.5f;

    private int _count = 0;

    private bool _isRunning = false;

    private Coroutine _counterCoroutine;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ToggleCounter);
    }

    public void ToggleCounter()
    {
        if (_isRunning == true)
        {
            if (_counterCoroutine != null)
            {
                StopCoroutine(_counterCoroutine);
                _counterCoroutine = null;
            }
        }
        else
        {
            _counterCoroutine = StartCoroutine(CountCoroutine());
        }

            _isRunning = !_isRunning;
    }

    private IEnumerator CountCoroutine()
    {
        var wait = new WaitForSeconds(_waitingTime);

        yield return wait;

        if (_isRunning == true)
        {
            _count++;

            if (_counterText) _counterText.text = _count.ToString();

            _counterCoroutine = StartCoroutine(CountCoroutine());
        }
    }
}
