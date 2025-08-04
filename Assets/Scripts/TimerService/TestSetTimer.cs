using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TestSetTimer : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private Button _startTimerButton;
    [SerializeField] private Button _togglePauseButton;
    [SerializeField] private Button _stopButton;

    private TimerService _timerService;

    public void Init(TimerService timerService)
    {
        _timerService = timerService;

        _startTimerButton.onClick.AddListener(OnStartClicked);
        _togglePauseButton.onClick.AddListener(OnTogglePauseClicked);
        _stopButton?.onClick.AddListener(OnStopClicked);

        _timerService.CurrentTime.Changed += (_, value) => OnTimeChanged(value);
        _timerService.TimerStarted += OnTimeChanged;
    }

    private void OnDestroy()
    {
        _startTimerButton.onClick.RemoveListener(OnStartClicked);
        _togglePauseButton.onClick.RemoveListener(OnTogglePauseClicked);
        _stopButton?.onClick.RemoveListener(OnStopClicked);

        _timerService.CurrentTime.Changed -= (_, value) => OnTimeChanged(value);
        _timerService.TimerStarted -= OnTimeChanged;
    }

    private void OnStartClicked()
    {
        if (uint.TryParse(_inputField.text, out uint value))
        {
            _timerService.StartNewTimer(value);
        }
    }

    private void OnTogglePauseClicked()
    {
        if (_timerService.IsPaused)
            _timerService.UnpauseTimer();
        else
            _timerService.PauseTimer();
    }

    private void OnStopClicked()
    {
        _timerService.StopTimer();
    }

    private void OnTimeChanged(uint seconds)
    {
        _inputField.text = seconds.ToString();
    }
}
