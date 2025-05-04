using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;

    private Coroutine _counter;
    private int _count;
    private float _delay = 0.5f;
    private int _turnSwitchButtonCode = 0;

    public event Action<TextMeshProUGUI, int> CountChanged;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_turnSwitchButtonCode))
        {
            if (_counter == null)
            {
                _counter = StartCoroutine(StartCounter(_delay));
            }
            else
            {
                StopCoroutine(_counter);

                _counter = null;
            }
        }

    }

    private IEnumerator StartCounter(float delay)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(delay);

        while (enabled)
        {
            yield return waitForSeconds;
            _count++;
            CountChanged?.Invoke(_counterText, _count);
        }
    }
}




