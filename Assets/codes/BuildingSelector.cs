using UnityEngine;

public class BuildingSelector : MonoBehaviour
{
    public GameObject hospitalPrefab;
    public GameObject officePrefab;
    public GameObject schoolPrefab;

    [HideInInspector]
    public GameObject selectedBuilding; 

    private int hospitalCost = 75;
    private int officeCost = 75;
    private int schoolCost = 50;

    private int selectedBuildingCost = 0;

    public void SelectHospital()
    {
        selectedBuilding = hospitalPrefab;
        selectedBuildingCost = hospitalCost;
        Debug.Log("Selected: Hospital");
    }

    public void SelectOffice()
    {
        selectedBuilding = officePrefab;
        selectedBuildingCost = officeCost;
        Debug.Log("Selected: Office");
    }

    public void SelectSchool()
    {
        selectedBuilding = schoolPrefab;
        selectedBuildingCost = schoolCost;
        Debug.Log("Selected: School");
    }

    public int GetSelectedBuildingCost()
    {
        return selectedBuildingCost;
    }
}
