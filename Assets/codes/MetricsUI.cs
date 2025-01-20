using TMPro;
using UnityEngine;

public class MetricsUI : MonoBehaviour
{
    public TextMeshProUGUI populationText;
    public TextMeshProUGUI lifeExpectancyText;
    public TextMeshProUGUI literacyRateText;

    public GameManager gameManager; // Reference to the GameManager

    private void Update()
    {
        populationText.text = $"Population: {gameManager.population}";
        lifeExpectancyText.text = $"Life Expectancy: {gameManager.lifeExpectancy:F1} years";
        literacyRateText.text = $"Literacy Rate: {gameManager.literacyRate:F1}%";
    }
}
