using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI counter;
    public int currentLocationIndex = 0;
    public FadeInOut fadeInOut;
   
    private Location currentLocation;
    private int locationGoal;
    private LocationLoader locationLoader;
    private ObjectDestroyer destination;

    private void Start()
    {
        locationLoader = gameObject.GetComponent<LocationLoader>();
        LoadLevel();
    }

    private void Update()
    {
        locationGoal = currentLocation.goal;
        counter.text = $"{destination.destroyCounter}/{locationGoal}";
        if (destination.destroyCounter >= locationGoal)
        {
            destination.destroyCounter = 0;
            FinishLevel();
        }
    }

    private void FinishLevel()
    {
        fadeInOut.StartFadeIn(0.5f);
        Debug.Log($"level {currentLocationIndex} Finished!!");
        currentLocationIndex++;
        LoadLevel();
    }

    private void LoadLevel()
    {
        currentLocation = locationLoader.InstantiateLocation(currentLocationIndex);
        destination = currentLocation.destination;
        fadeInOut.StartFadeOut(0.5f);
    }

    public void ReloadLevel()
    {
        destination.destroyCounter = 0;
        currentLocation.Reload();
    }

}
