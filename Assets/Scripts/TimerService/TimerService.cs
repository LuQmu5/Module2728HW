using System;
using System.Collections;
using UnityEngine;

public class TimerService
{
    private const int OneSecond = 1;

    private uint _initialTime;
    private uint _currentTime;

    private MonoBehaviour _coroutineRunner;
    private Coroutine _timerCoroutine;
    private WaitForSecondsRealtime _tick;

    public bool IsPaused { get; private set; }

    public uint CurrentTime => _currentTime;
    public uint InitialTime => _initialTime;
    public float TimeNormalized => _initialTime == 0 ? 0f : (float)_currentTime / _initialTime;

    public event Action<uint> TimerStarted;
    public event Action<uint> CurrentTimeChanged;
    public event Action TimerFinished;

    public TimerService(MonoBehaviour coroutineRunner)
    {
        _coroutineRunner = coroutineRunner;
        _tick = new WaitForSecondsRealtime(OneSecond);
    }

    public void StartNewTimer(uint seconds)
    {
        if (seconds == 0)
            throw new ArgumentOutOfRangeException(nameof(seconds), "Timer duration can't be zero.");

        StopTimer();

        _initialTime = seconds;
        _currentTime = seconds;
        IsPaused = false;

        TimerStarted?.Invoke(_initialTime);
        CurrentTimeChanged?.Invoke(_currentTime);

        _timerCoroutine = _coroutineRunner.StartCoroutine(CountDownCoroutine());
    }

    public void PauseTimer()
    {
        if (_timerCoroutine == null || IsPaused)
            return;

        _coroutineRunner.StopCoroutine(_timerCoroutine);
        _timerCoroutine = null;
        IsPaused = true;
    }

    public void UnpauseTimer()
    {
        if (_currentTime == 0 || !IsPaused)
            return;

        IsPaused = false;
        _timerCoroutine = _coroutineRunner.StartCoroutine(CountDownCoroutine());
    }

    public void StopTimer()
    {
        if (_timerCoroutine != null)
        {
            _coroutineRunner.StopCoroutine(_timerCoroutine);
            _timerCoroutine = null;
        }

        IsPaused = false;
    }

    private IEnumerator CountDownCoroutine()
    {
        while (_currentTime > 0)
        {
            yield return _tick;
            _currentTime--;
            CurrentTimeChanged?.Invoke(_currentTime);
        }

        TimerFinished?.Invoke();
        _timerCoroutine = null;
    }
}
