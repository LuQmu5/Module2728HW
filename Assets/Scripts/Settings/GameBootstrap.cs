using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    [SerializeField] private WalletDisplay _walletDisplay;
    [SerializeField] private TestAddValueScript _testAddValueScript;

    private void Awake()
    {
        WalletService walletService = new WalletService();

        _walletDisplay.Init(walletService);
        _testAddValueScript.Init(walletService);
    }
}
