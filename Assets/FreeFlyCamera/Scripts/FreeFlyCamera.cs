using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FreeFlyCamera : MonoBehaviour
{
    #region UI

    [Space]

    [SerializeField]
    [Tooltip("The script is currently active")]
    private bool _active = true;

    [Space]

    [SerializeField]
    [Tooltip("Camera rotation by mouse movement is active")]
    private bool _enableRotation = true;

    [SerializeField]
    [Tooltip("Sensitivity of mouse rotation")]
    private float _mouseSense = 1.8f;

    [Space]

    [SerializeField]
    [Tooltip("Camera zooming in/out by 'Mouse Scroll Wheel' is active")]
    private bool _enableTranslation = true;

    [SerializeField]
    [Tooltip("Velocity of camera zooming in/out")]
    private float _translationSpeed = 55f;

    [Space]

    [SerializeField]
    [Tooltip("Camera movement by 'W','A','S','D','Q','E' keys is active")]
    private bool _enableMovement = true;

    [SerializeField]
    [Tooltip("Camera movement speed")]
    private float _movementSpeed = 10f;

    [SerializeField]
    [Tooltip("Speed of the quick camera movement when holding the 'Left Shift' key")]
    private float _boostedSpeed = 50f;

    [SerializeField]
    [Tooltip("Boost speed")]
    private KeyCode _boostSpeed = KeyCode.LeftShift;

    [SerializeField]
    [Tooltip("Move up")]
    private KeyCode _moveUp = KeyCode.E;

    [SerializeField]
    [Tooltip("Move down")]
    private KeyCode _moveDown = KeyCode.Q;

    [Space]

    [SerializeField]
    [Tooltip("Acceleration at camera movement is active")]
    private bool _enableSpeedAcceleration = true;

    [SerializeField]
    [Tooltip("Rate which is applied during camera movement")]
    private float _speedAccelerationFactor = 1.5f;

    [Space]

    [SerializeField]
    [Tooltip("This keypress will move the camera to initialization position")]
    private KeyCode _initPositonButton = KeyCode.R;

    #endregion UI

    private CursorLockMode _wantedMode;

    private float _currentIncrease = 1;
    private float _currentIncreaseMem = 0;

    private Vector3 _initPosition;
    private Vector3 _initRotation;

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (_boostedSpeed < _movementSpeed)
            _boostedSpeed = _movementSpeed;
    }
#endif

    private void Start()
    {
        _initPosition = transform.position;
        _initRotation = transform.eulerAngles;

        // Reset camera to initial position and rotation on start
        ResetCamera();
    }

    private void OnEnable()
    {
        if (_active)
        {
            _wantedMode = CursorLockMode.Locked;

            // Reset camera to initial position and rotation when the game starts
            ResetCamera();
        }
    }

    // Apply requested cursor state
    private void SetCursorState()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = _wantedMode = CursorLockMode.None;
        }

        // Apply cursor state
        Cursor.lockState = _wantedMode;
        // Hide cursor when locking
        Cursor.visible = (CursorLockMode.Locked != _wantedMode);
    }

    private void CalculateCurrentIncrease(bool moving)
    {
        _currentIncrease = Time.deltaTime;

        if (!_enableSpeedAcceleration || _enableSpeedAcceleration && !moving)
        {
            _currentIncreaseMem = 0;
            return;
        }

        _currentIncreaseMem += Time.deltaTime * (_speedAccelerationFactor - 1);
        _currentIncrease = Time.deltaTime + Mathf.Pow(_currentIncreaseMem, 3) * Time.deltaTime;
    }

    public void CameraBtn()
    {
        _wantedMode = CursorLockMode.Locked;
        
    }

    public Transform topDownPos;  // Variable for top-down position
    private bool _isTopDownMode = false;
    private Vector3 _topDownPosition;  // Store the position before entering top-down mode
    private Quaternion _topDownRotation;  // Store the rotation before entering top-down mode

    private void ToggleTopDownMode()
    {
        _isTopDownMode = !_isTopDownMode;

        if (_isTopDownMode)
        {
            // Enter top-down mode
            _wantedMode = CursorLockMode.None;  // Unlock cursor for user interaction

            // Store current position and rotation
            _topDownPosition = transform.position;
            _topDownRotation = transform.rotation;

            // Set camera to a predefined top-down position and rotation
            transform.position = topDownPos.position;
            transform.rotation = topDownPos.rotation;
            _enableRotation = false;  // Disable rotation in top-down mode
        }
        else
        {
            // Exit top-down mode
            _wantedMode = CursorLockMode.Locked;  // Lock cursor

            // Restore position and rotation
            transform.position = _topDownPosition;
            transform.rotation = _topDownRotation;
            _enableRotation = true;  // Enable rotation when exiting top-down mode
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleTopDownMode();
        }

        if (!_active)
            return;

        SetCursorState();

        if (Cursor.visible)
            return;

        // Handle top-down mode controls
        if (_isTopDownMode)
        {
            // Translation (WASD movement)
            Vector3 deltaPositionTopDown = Vector3.zero;
            deltaPositionTopDown += Input.GetKey(KeyCode.W) ? Vector3.forward : Vector3.zero;
            deltaPositionTopDown += Input.GetKey(KeyCode.S) ? -Vector3.forward : Vector3.zero;
            deltaPositionTopDown += Input.GetKey(KeyCode.A) ? -Vector3.right : Vector3.zero;
            deltaPositionTopDown += Input.GetKey(KeyCode.D) ? Vector3.right : Vector3.zero;

            transform.position += deltaPositionTopDown * _movementSpeed * Time.deltaTime;

            // Zoom (scroll wheel)
            transform.Translate(Vector3.forward * Input.mouseScrollDelta.y * Time.deltaTime * _translationSpeed);
        }
        else
        {
            // Handle free-fly mode controls
            // ... (existing code)

            // Movement
            if (_enableMovement)
            {
                Vector3 deltaPosition = Vector3.zero;
                float currentSpeed = _movementSpeed;

                if (Input.GetKey(_boostSpeed))
                    currentSpeed = _boostedSpeed;

                if (Input.GetKey(KeyCode.W))
                    deltaPosition += transform.forward;

                if (Input.GetKey(KeyCode.S))
                    deltaPosition -= transform.forward;

                if (Input.GetKey(KeyCode.A))
                    deltaPosition -= transform.right;

                if (Input.GetKey(KeyCode.D))
                    deltaPosition += transform.right;

                if (Input.GetKey(_moveUp))
                    deltaPosition += transform.up;

                if (Input.GetKey(_moveDown))
                    deltaPosition -= transform.up;

                // Calc acceleration
                CalculateCurrentIncrease(deltaPosition != Vector3.zero);

                transform.position += deltaPosition * currentSpeed * _currentIncrease;
            }

            // Rotation
            if (_enableRotation)
            {
                // Pitch
                transform.rotation *= Quaternion.AngleAxis(
                    -Input.GetAxis("Mouse Y") * _mouseSense,
                    Vector3.right
                );

                // Yaw
                transform.rotation = Quaternion.Euler(
                    transform.eulerAngles.x,
                    transform.eulerAngles.y + Input.GetAxis("Mouse X") * _mouseSense,
                    transform.eulerAngles.z
                );
            }
        }

        // Return to init position
        if (Input.GetKeyDown(_initPositonButton))
        {
            transform.position = _initPosition;
            transform.eulerAngles = _initRotation;
        }
    }
    public Transform camPos;
    private void ResetCamera()
    {
        transform.position = camPos.position;
        transform.rotation = camPos.rotation;
    }
}
