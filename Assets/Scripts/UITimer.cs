using TMPro;
using UnityEngine;

public class UITimer : MonoBehaviour
{
    [SerializeField] private Timer _timer;

    private void OnEnable()
    {
        _timer.CountChanged += OnShowCounter;
    }

    private void OnDisable()
    {
        _timer.CountChanged -= OnShowCounter;
    }

    private void OnShowCounter(TextMeshProUGUI text, int count)
    {
        text.text = count.ToString();
    }
}
