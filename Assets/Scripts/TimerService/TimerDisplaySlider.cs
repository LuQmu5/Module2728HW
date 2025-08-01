using UnityEngine;
using UnityEngine.UI;

public class TimerDisplaySlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private TimerService _timerService;

    public void Init(TimerService timerService)
    {
        _timerService = timerService;

        _slider.minValue = 0;

        _timerService.TimerStarted += OnTimerStarted;
        _timerService.CurrentTimeChanged += OnTimeChanged;
    }

    private void OnDestroy()
    {
        _timerService.TimerStarted -= OnTimerStarted;
        _timerService.CurrentTimeChanged -= OnTimeChanged;
    }

    private void OnTimerStarted(uint max)
    {
        _slider.maxValue = max;
        _slider.value = max;
    }

    private void OnTimeChanged(uint time)
    {
        _slider.value = time;
    }
}
