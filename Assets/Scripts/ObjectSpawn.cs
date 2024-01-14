using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectSpawn : MonoBehaviour, IPointerDownHandler
{
    public GameObject objectPrefab;
    public Vector3 spawnLocation = Vector3.zero; 
    private GameObject spawnedObject;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            spawnedObject = Instantiate(objectPrefab, spawnLocation, Quaternion.identity);
        }
    }
}
