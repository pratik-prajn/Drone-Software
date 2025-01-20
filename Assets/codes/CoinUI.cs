using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    public TextMeshProUGUI coinText; 

    private void Update()
    {
        coinText.text = $"Coins: {CoinManager.Instance.coins}";
    }
}
