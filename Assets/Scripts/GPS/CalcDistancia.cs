using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcDistancia : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public float CalcularDistancia(float Lat1, float Lon1, float Lat2, float Lon2)
    {
        //se utiliza la formula de Haversine para encontrar la distancia entre 2 coordenadas
        var R = 6371e3; // metres 
        var Δφ = (Lat2 - Lat1) * Mathf.PI / 180; //distancia entre latitudes y longitudes
        var Δλ = (Lon2 - Lon1) * Mathf.PI / 180;
        var φ1 = Lat1 * Mathf.PI / 180; //para pasar a radianes
        var φ2 = Lat2 * Mathf.PI / 180;

        var a = Mathf.Sin(Δφ / 2) * Mathf.Sin(Δφ / 2) + Mathf.Cos(φ1) * Mathf.Cos(φ2) * Mathf.Sin(Δλ / 2) * Mathf.Sin(Δλ / 2);
        var c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));

        var d = R * c;

        return (float)d;
    }
}
