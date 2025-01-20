using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int hospitalsCount = 0;
    public int officesCount = 0;
    public int schoolsCount = 0;
    public float population = 100f;  
    public float lifeExpectancy = 70f;  
    public float literacyRate = 85f; 

    public TextMeshProUGUI populationText;
    public TextMeshProUGUI lifeExpectancyText;
    public TextMeshProUGUI literacyRateText;

    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        
        populationText.text = "Population: " + population.ToString("F1"); 
        lifeExpectancyText.text = "Life Expectancy: " + lifeExpectancy.ToString("F1") + " years"; 
        literacyRateText.text = "Literacy Rate: " + literacyRate.ToString("F1") + "%"; 
    }
}
