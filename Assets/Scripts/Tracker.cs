using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tracker : MonoBehaviour
{
    public GameObject startPosition;
    public float distance;
    public Text distanceText;
    public Vector3 currentPosition, initialPosition;
    
    void FixedUpdate()
    {
        TrackDistance();
    }
    public string TrackDistance()
    {
        distance = Vector3.Distance(startPosition.transform.position, transform.position);
        currentPosition = transform.position;
        initialPosition = startPosition.transform.position;

        distanceText.text = "Distance from Spawn: " + distance.ToString();
        return distanceText.text;
        
    }

}
