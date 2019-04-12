using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugging2 : MonoBehaviour {

    public CalcDistancia calculo3;
    private float sLatitude = 5.0346267f;
    private float sLongitude = -75.458344f;
    private float dLatitude = -6.884687f, dLongitude = 107.605945f;
    private float distancia;

	void Start () {
        distancia = calculo3.CalcularDistancia(sLatitude, sLongitude, dLatitude, dLongitude);
        Debug.Log("la distancia por formula 2 es de :  " + distancia);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
