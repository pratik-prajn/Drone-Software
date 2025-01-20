using UnityEngine;

public class GetGridCoordinates : MonoBehaviour
{
    public GridManager gridManager; 
    public LayerMask groundMask;

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundMask))
            {
                Vector3 hitPoint = hit.point;

                
                int row = Mathf.FloorToInt(hitPoint.z / gridManager.cellSize);
                int column = Mathf.FloorToInt(hitPoint.x / gridManager.cellSize);

                
                Debug.Log($"Grid Coordinates: Row = {row}, Column = {column}");
            }
        }
    }
}
