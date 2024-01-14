using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MeasuringTool : MonoBehaviour
{
    public float measurementMultiplier = 1.0f;
    public TMP_FontAsset font;
    public int fontSize = 12;
    public Toggle toggle;

    private LineRenderer lineRenderer;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private TextMeshPro distanceText;
    private bool isMeasuring = false;
    private bool isToolActive = false;

    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.useWorldSpace = true;
        lineRenderer.material = new Material(Shader.Find("Standard"));
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;

        GameObject textObject = new GameObject("DistanceText");
        distanceText = textObject.AddComponent<TextMeshPro>();
        distanceText.font = font;
        distanceText.alignment = TextAlignmentOptions.Center;
        distanceText.color = Color.red;

        textObject.SetActive(false);
        isToolActive = false;
    }

    void Update()
    {
        HandleInput();

        if (isToolActive && isMeasuring)
        {
            UpdateMeasurement();
        }
    }

    void HandleInput()
    {
        if (toggle != null)
        {
            isToolActive = toggle.isOn;

            if (!isToolActive || !Input.GetMouseButton(0))
            {
                StopMeasuring();
                distanceText.gameObject.SetActive(false);
            }
        }

        if (isToolActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartMeasuring();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                StopMeasuring();
            }
        }
    }

    void StartMeasuring()
    {
        isMeasuring = true;
        startPosition = GetMousePosition();
        endPosition = startPosition;
        lineRenderer.SetPosition(0, startPosition);
        lineRenderer.SetPosition(1, endPosition);

        distanceText.gameObject.SetActive(true);
        distanceText.text = "0 ft";
        UpdateTextPosition();
    }

    void StopMeasuring()
    {
        isMeasuring = false;
        distanceText.gameObject.SetActive(false);
    }

    void UpdateMeasurement()
    {
        endPosition = GetMousePosition();
        lineRenderer.SetPosition(1, endPosition);

        float distance = Vector3.Distance(startPosition, endPosition) * measurementMultiplier;

        int roundedDistance = Mathf.CeilToInt(distance);

        distanceText.text = roundedDistance.ToString() + " ft";
        UpdateTextPosition();
    }

    void UpdateTextPosition()
    {
        Vector3 textPosition = endPosition + Vector3.up * 0.5f;
        distanceText.transform.position = textPosition;

        distanceText.transform.LookAt(distanceText.transform.position + Camera.main.transform.forward);

        distanceText.fontSize = fontSize;
    }

    Vector3 GetMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            return hit.point;
        }
        return Vector3.zero;
    }
}
