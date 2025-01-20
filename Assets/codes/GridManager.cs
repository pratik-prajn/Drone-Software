using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int gridWidth = 10; 
    public int gridHeight = 10; 
    public float cellSize = 1f; 

    public Vector3 GetCellCenter(Vector3 position)
    {
       
        int x = Mathf.FloorToInt(position.x / cellSize);
        int z = Mathf.FloorToInt(position.z / cellSize);

       
        float centerX = x * cellSize + cellSize / 2;
        float centerZ = z * cellSize + cellSize / 2;

        return new Vector3(centerX, 0, centerZ); 
    }

    public void DrawGrid()
    {
 
        for (int x = 0; x <= gridWidth; x++)
        {
            for (int z = 0; z <= gridHeight; z++)
            {
                Vector3 start = new Vector3(x * cellSize, 0, 0);
                Vector3 end = new Vector3(x * cellSize, 0, gridHeight * cellSize);
                Debug.DrawLine(start, end, Color.green, 100f);

                start = new Vector3(0, 0, z * cellSize);
                end = new Vector3(gridWidth * cellSize, 0, z * cellSize);
                Debug.DrawLine(start, end, Color.green, 100f);
            }
        }
    }

    private void OnDrawGizmos()
    {
        DrawGrid();
    }
}
