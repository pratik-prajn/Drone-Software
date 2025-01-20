using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;
    public int coins = 0; 
    public int coinsPerSecond = 1; 

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        
        InvokeRepeating(nameof(GenerateCoins), 1f, 1f);
    }

    private void GenerateCoins()
    {
        coins += coinsPerSecond;
        Debug.Log($"Coins: {coins}");
    }

    public bool SpendCoins(int amount)
    {
        if (coins >= amount)
        {
            coins -= amount;
            Debug.Log($"Spent {amount} coins. Remaining: {coins}");
            return true;
        }
        else
        {
            Debug.Log($"Not enough coins! Needed: {amount}, Available: {coins}");
            return false;
        }
    }
}
