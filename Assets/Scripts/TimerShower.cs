using TMPro;
using UnityEngine;

public class TimerShower : MonoBehaviour
{
    [SerializeField] private Timer _timer;

    private void OnEnable()
    {
        _timer.OnCountChanged += ShowCounter;
    }

    private void OnDisable()
    {
        _timer.OnCountChanged -= ShowCounter;
    }
    private void ShowCounter(TextMeshProUGUI text, int count)
    {
        text.text = count.ToString();
    }
}
