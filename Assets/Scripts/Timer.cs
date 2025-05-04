using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private ShowTimer _showTimer;
    [SerializeField] private TextMeshProUGUI _counterText;

    private Coroutine _counter;
    private int _count;
    private float _delay = 0.5f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_counter == null)
            {
                _counter = StartCoroutine(StartCounter(delay));
            }
            else
            {
                StopCoroutine(_counter);
                _counter = null;
            }
        }

        _showTimer.ShowCounter(_counterText, _count);
    }

    private IEnumerator StartCounter(float delay)
    {
        WaitForSeconds _waitForSeconds = new WaitForSeconds(delay);

        while (enabled)
        {
            yield return _waitForSeconds;
            _count++;
        }
    }
}




