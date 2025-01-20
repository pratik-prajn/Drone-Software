using UnityEngine;

public class ObjectSnap : MonoBehaviour
{
    public GridManager gridManager; 
    public LayerMask groundMask; 
    private bool[,] occupiedCells; 
    public BuildingSelector buildingSelector;
    public GameManager gameManager; 

   
    public float lifeExpectancyChangeRate = 2f;  
    public float literacyRateChangeRate = 1f;    
    public float populationChangeRate = 5f;      
    public float officeLifeExpectancyDecreaseRate = 1f;  

    private void Start()
    {
        
        occupiedCells = new bool[gridManager.gridWidth, gridManager.gridHeight];
    }

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(1) && buildingSelector.selectedBuilding != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

          
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundMask))
            {
                Vector3 hitPoint = hit.point;

               
                int row = Mathf.FloorToInt(hitPoint.z / gridManager.cellSize);
                int column = Mathf.FloorToInt(hitPoint.x / gridManager.cellSize);

            
                if (row >= 0 && row < gridManager.gridHeight && column >= 0 && column < gridManager.gridWidth)
                {
                    
                    if (!occupiedCells[column, row])
                    {
                        int cost = buildingSelector.GetSelectedBuildingCost(); 

                       
                        if (CoinManager.Instance.SpendCoins(cost))
                        {
                           
                            Vector3 placementPosition = gridManager.GetCellCenter(hitPoint);

                            
                            Instantiate(buildingSelector.selectedBuilding, placementPosition, Quaternion.identity);

                          
                            occupiedCells[column, row] = true;

                            
                            if (buildingSelector.selectedBuilding.name == "Hospital")
                            {
                                gameManager.hospitalsCount++;
                                gameManager.lifeExpectancy += lifeExpectancyChangeRate;  
                                gameManager.literacyRate -= literacyRateChangeRate;    
                                gameManager.population += populationChangeRate;      
                            }
                            else if (buildingSelector.selectedBuilding.name == "School")
                            {
                                gameManager.schoolsCount++;
                                gameManager.literacyRate += literacyRateChangeRate;  
                                gameManager.population += populationChangeRate;     
                            }
                            else if (buildingSelector.selectedBuilding.name == "Office")
                            {
                                gameManager.officesCount++;
                                gameManager.lifeExpectancy -= officeLifeExpectancyDecreaseRate; 
                                gameManager.population += populationChangeRate;      // Increase population due to more offices
                            }

                            Debug.Log($"Placed {buildingSelector.selectedBuilding.name} at: Row = {row}, Column = {column}");
                        }
                        else
                        {
                            Debug.Log("Not enough coins to place this building!");
                        }
                    }
                    else
                    {
                        Debug.Log("This cell is already occupied!");
                    }
                }
                else
                {
                    Debug.Log("Click is outside the grid bounds!");
                }
            }
        }
    }
}
