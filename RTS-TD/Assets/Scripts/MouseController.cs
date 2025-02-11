using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    Vector3 mousePos;

    //Ray ray;
    //RaycastHit hit;

    public Vector3 dragStartPosition;
    public Vector3 dragCurrentPosition;
    void Start()
    {
        mousePos = Input.mousePosition;

        Cursor.visible = true;
    }

 
    void Update()
    {
        //ray = mainCamera.ScreenPointToRay(mousePos);
        //if (Physics.Raycast(ray, out hit))
        //{
        //    transform.position = hit.point;
        //}

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            transform.position = raycastHit.point;
        }
    }

    void MouseInput()
    {

    }

    void OnMouseOver()
    {
        Debug.Log("Mouse is over");
    }
}
