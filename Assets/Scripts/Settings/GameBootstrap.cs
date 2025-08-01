using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    [SerializeField] private WalletDisplay _walletDisplay;
    [SerializeField] private TestAddValueScript _testAddValueScript;
    [SerializeField] private TestSetTimer _testSetTimer;
    [SerializeField] private TimerDisplaySlider _timerDisplaySlider;
    [SerializeField] private TimerDisplayHearts _timerDisplayHearts;

    private void Awake()
    {
        WalletService walletService = new WalletService();

        _walletDisplay.Init(walletService);
        _testAddValueScript.Init(walletService);

        TimerService timerService = new TimerService(this);

        _testSetTimer.Init(timerService);

        _timerDisplaySlider.Init(timerService);
        _timerDisplayHearts.Init(timerService);
    }
}
