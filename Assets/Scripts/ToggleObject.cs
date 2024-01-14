using UnityEngine;
using UnityEngine.UI;

public class ToggleObject : MonoBehaviour
{
    public GameObject targetObject;
    public Toggle toggle;

    void Start()
    {
        
        toggle.onValueChanged.AddListener(ToggleValueChanged);
    }

    void ToggleValueChanged(bool isOn)
    {
        
        targetObject.SetActive(isOn);
    }
}
