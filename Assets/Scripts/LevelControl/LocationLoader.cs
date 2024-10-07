using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LocationLoader : MonoBehaviour
{
    // Лист префабов уровней
    public List<Location> locations;
    [SerializeField]
    private GameObject levelContainer;
    
    private int currentLocationIndex = -1;
    private Location currentLocationInstance;

    // Метод для инстанциирования локации
    public Location InstantiateLocation(int locationIndex)
    {
        if (locationIndex > locations.Count)
        {
            Debug.Log($"locationIndex out of range - ({locationIndex} from {locations.Count})");
            return currentLocationInstance.GetComponent<Location>();
        }
        if (currentLocationInstance != null)
        {
            currentLocationInstance.ClearLevel();
            Destroy(currentLocationInstance.gameObject);
        }

        currentLocationInstance = Instantiate(locations[locationIndex], levelContainer.transform);
        return currentLocationInstance.GetComponent<Location>();
    }
}