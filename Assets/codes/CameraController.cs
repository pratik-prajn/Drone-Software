using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 20f; 
    public float zoomSpeed = 10f; 
    public float minFOV = 30f; 
    public float maxFOV = 90f; 
    public Vector2 panLimit = new Vector2(150f, 150f); 

    private Camera cam; 

    private void Start()
    {
    
        cam = Camera.main;
    }

    private void Update()
    {
        HandleKeyboardPanning(); 
        HandleZooming();
        HandleEdgeScrolling();
    }

    private void HandleKeyboardPanning()
    {
       
        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) move.z += panSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) move.z -= panSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) move.x -= panSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) move.x += panSpeed * Time.deltaTime;

        transform.Translate(move, Space.World);
        transform.position = ClampPosition(transform.position);
    }

    private void HandleZooming()
    {
       
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        cam.fieldOfView -= scroll * zoomSpeed * Time.deltaTime * 100f;
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, minFOV, maxFOV);
    }

    private Vector3 ClampPosition(Vector3 position)
    {
        
        position.x = Mathf.Clamp(position.x, -panLimit.x, panLimit.x);
        position.z = Mathf.Clamp(position.z, -panLimit.y, panLimit.y);
        return position;
    }

    private void HandleEdgeScrolling()
    {
        Vector3 move = Vector3.zero;

        if (Input.mousePosition.x >= Screen.width - 10) move.x += panSpeed * Time.deltaTime;
        if (Input.mousePosition.x <= 10) move.x -= panSpeed * Time.deltaTime;
        if (Input.mousePosition.y >= Screen.height - 10) move.z += panSpeed * Time.deltaTime;
        if (Input.mousePosition.y <= 10) move.z -= panSpeed * Time.deltaTime;

        transform.Translate(move, Space.World);
        transform.position = ClampPosition(transform.position);
    }
}
