using UnityEngine;

public class ClickAndDrag : MonoBehaviour
{
    public bool isLocked = false;
    public float rotationSpeed = 10f;
    private bool isDragging = false;
    private bool isRotating = false;
    private Vector3 initialOffset;
    private Rigidbody rb;
    private bool isRightMouseClicked = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null) Debug.LogError("Rigidbody component not found on the object.");
    }

    void Update()
    {
        HandleMouseInput();
        HandleGKey();
    }

    void HandleMouseInput()
    {
        HandleLeftMouse();
        HandleRightMouse();
        HandleRotation();
        HandleMouseScrollWheel();
    }

    void HandleLeftMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (IsMouseOverObject() && !isLocked && !Input.GetKey(KeyCode.LeftShift))
            {
                isDragging = true;
                initialOffset = transform.position - GetMouseWorldPos();
            }
            else
            {
                isDragging = false;
            }
        }

        if (Input.GetMouseButton(0) && isDragging)
        {
            Vector3 newPosition = GetMouseWorldPos() + initialOffset;

            
            if (!IsColliding(newPosition))
            {
                transform.position = newPosition;
            }
        }
    }

    
    bool IsColliding(Vector3 newPosition)
    {
        Collider[] colliders = Physics.OverlapBox(newPosition, transform.localScale / 2f, transform.rotation);

        foreach (Collider collider in colliders)
        {
            if (collider.gameObject != gameObject) 
            {
                return true; 
            }
        }

        return false; 
    }


    void HandleRightMouse()
    {
        if (Input.GetMouseButtonDown(1) && IsMouseOverObject())
        {
            isLocked = !isLocked;
            isRightMouseClicked = !isRightMouseClicked;
        }
    }

    void HandleRotation()
    {
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.E))
        {
            isRotating = IsMouseOverObject();
            float rotationAmount = (Input.GetKey(KeyCode.Q) ? -1f : 1f) * rotationSpeed * Time.deltaTime;
            transform.Rotate(0f, isRotating ? rotationAmount : 0f, 0f, Space.World);
        }
    }

    void HandleMouseScrollWheel()
    {
        float scrollWheelInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheelInput != 0f && IsMouseOverObject() && !isLocked && !Input.GetKey(KeyCode.LeftShift))
        {
            Vector3 newPosition = transform.position + Camera.main.transform.forward * scrollWheelInput * 5f;

            
            if (!IsColliding(newPosition))
            {
                transform.position = newPosition;
            }
        }
    }

    void HandleGKey()
    {
        if (Input.GetKeyDown(KeyCode.G) && IsMouseOverObject()) ToggleKinematicState();
    }

    void ToggleKinematicState()
    {
        if (rb != null) rb.isKinematic = !rb.isKinematic;
    }

    bool IsMouseOverObject()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject;
    }

    Vector3 GetMouseWorldPos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        return Physics.Raycast(ray, out hit) ? hit.point : Vector3.zero;
    }
}
