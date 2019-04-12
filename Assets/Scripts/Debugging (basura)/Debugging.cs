using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugging : MonoBehaviour {

    // Use this for initialization
    private Vector2 targetCoordinates;
    private Vector2 deviceCoordinates;
    private float proximity = 0.001f;
    public float sLatitude = 5.0346267f;
    public float sLongitude = -75.458344f;
    public float dLatitude = -6.884687f, dLongitude = 107.605945f;

    void Start()
    {
        targetCoordinates = new Vector2(dLatitude, dLongitude);
        deviceCoordinates = new Vector2(sLatitude, sLongitude);
        proximity = Vector2.Distance(targetCoordinates, deviceCoordinates);
        Debug.Log("la distancia es de :  "+proximity);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
