using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerDisplayHearts : MonoBehaviour
{
    [SerializeField] private HorizontalLayoutGroup _container;
    [SerializeField] private GameObject _heartPrefab;

    private TimerService _timerService;
    private List<GameObject> _hearts = new();

    public void Init(TimerService timerService)
    {
        _timerService = timerService;

        _timerService.TimerStarted += OnTimerStarted;
        _timerService.CurrentTime.Changed += OnTimeChanged;
    }

    private void OnDestroy()
    {
        _timerService.TimerStarted -= OnTimerStarted;
        _timerService.CurrentTime.Changed -= OnTimeChanged;
    }

    private void OnTimerStarted(uint time)
    {
        ClearHearts();

        for (int i = 0; i < time; i++)
        {
            GameObject heart = Instantiate(_heartPrefab, _container.transform);
            _hearts.Add(heart);
        }
    }

    private void OnTimeChanged(uint oldValue, uint newValue)
    {
        for (int i = 0; i < _hearts.Count; i++)
        {
            _hearts[i].SetActive(i < newValue);
        }
    }

    private void ClearHearts()
    {
        foreach (var heart in _hearts)
        {
            Destroy(heart);
        }

        _hearts.Clear();
    }
}
