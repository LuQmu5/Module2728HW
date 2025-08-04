using System;
using System.Collections;
using UnityEngine;

public class TimerService
{
    public ReactiveVariable<uint> CurrentTime { get; private set; } = new();
    public bool IsPaused { get; private set; }
    public bool IsRunning => !_isFinished && !IsPaused;

    public uint InitialTime { get; private set; }

    public event Action<uint> TimerStarted;
    public event Action TimerFinished;

    private float _startTime;
    private float _pauseStartTime;
    private float _totalPausedDuration;
    private bool _isFinished;

    private MonoBehaviour _runner;

    public TimerService(MonoBehaviour runner)
    {
        _runner = runner;
        _runner.StartCoroutine(UpdateCoroutine());
    }

    public void StartNewTimer(uint seconds)
    {
        if (seconds == 0)
            throw new ArgumentOutOfRangeException(nameof(seconds), "Timer duration can't be zero.");

        InitialTime = seconds;
        _startTime = Time.realtimeSinceStartup;
        _totalPausedDuration = 0f;
        IsPaused = false;
        _isFinished = false;

        CurrentTime.Value = seconds;
        TimerStarted?.Invoke(InitialTime);
    }

    public void PauseTimer()
    {
        if (IsPaused || _isFinished)
            return;

        IsPaused = true;
        _pauseStartTime = Time.realtimeSinceStartup;
    }

    public void UnpauseTimer()
    {
        if (!IsPaused || _isFinished)
            return;

        IsPaused = false;
        _totalPausedDuration += Time.realtimeSinceStartup - _pauseStartTime;
    }

    public void StopTimer()
    {
        IsPaused = false;
        _isFinished = true;
    }

    private IEnumerator UpdateCoroutine()
    {
        WaitForEndOfFrame wait = new();

        while (true)
        {
            yield return wait;

            if (_isFinished || IsPaused || InitialTime == 0)
                continue;

            float elapsed = Time.realtimeSinceStartup - _startTime - _totalPausedDuration;
            float remaining = InitialTime - elapsed;

            if (remaining <= 0f)
            {
                CurrentTime.Value = 0;
                _isFinished = true;
                TimerFinished?.Invoke();
            }
            else
            {
                uint secondsRemaining = (uint)Mathf.CeilToInt(remaining);
                if (secondsRemaining != CurrentTime.Value)
                    CurrentTime.Value = secondsRemaining;
            }
        }
    }
}
