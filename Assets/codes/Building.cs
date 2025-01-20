using UnityEngine;

public class Building : MonoBehaviour
{
    public int coinRateIncrease = 0;

    private void Start()
    {
        CoinManager.Instance.coinsPerSecond += coinRateIncrease;
        Debug.Log($"{gameObject.name} placed. Coin generation rate increased by {coinRateIncrease}.");
    }
}
