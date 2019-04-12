using System.Collections;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

    //Coordenadas del video
    private float lat1;
    private float lon1;
    private float lat2;
    private float lon2;
    private Vector3 PosicionInicialVideo;
    private Vector3 PosicionActualVideo;
    private GameObject objetoTexto;
    private GameObject LatTexto;
    private GameObject LonTexto;
    private GameObject Iteraciones;
    private bool coordIniciales = true;
    float distancia;
    private bool loop = true;

    // Use this for initialization

    void Start()
    {
        objetoTexto = GameObject.FindGameObjectWithTag ("Texto");
        this.PosicionInicialVideo = transform.position;
        this.PosicionActualVideo = transform.position;

        //coroutine permite que la funcion se ejecute aun despues de las condiciones de ejecucion (wait 5 seconds etc)
        StartCoroutine(getLocation());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, PosicionActualVideo, 0.1f);
        //quitar esto
        transform.eulerAngles += new Vector3(0, 1f, 0);
    }

    //codigo encargado de pedir la informacion GPS al celular

    IEnumerator getLocation()
    {
        
        bool enableByRequest = true;
        int itera = 1;

        float UPDATE_TIME = 2f; //Every  1 seconds
        WaitForSeconds updateTime = new WaitForSeconds(UPDATE_TIME);
        //esto comienza el loop 
        while (loop)
          {
            int maxWait = 10;
            Iteraciones.GetComponent<Text>().text = "Iteracion #: " + itera;
            itera++;
            
            {
                LocationService service = Input.location;

                if (!enableByRequest && !service.isEnabledByUser)
                {
                    Debug.Log("Servicios de GPS no habilitados por el usuario");
                    yield break;
                }

                service.Start(2f,0.01f);

                while (service.status == LocationServiceStatus.Initializing && maxWait > 0)
                {
                    yield return new WaitForSeconds(1);
                    maxWait--;
                }

                if (maxWait < 1)
                {
                    Debug.Log("Timed out");
                    yield break;
                }

                if (service.status == LocationServiceStatus.Failed)
                {
                    Debug.Log("imposible determinar ubicacion del celular");
                    yield break;
                }
                else
                {   //se consigue las coordenadas iniciales solo una vez
                    if (coordIniciales)
                    {
                        LatTexto.GetComponent<Text>().text = "Latitud original: " + service.lastData.latitude;
                        LonTexto.GetComponent<Text>().text = "Longitud original: " + service.lastData.longitude;
                        lat1 = service.lastData.latitude;
                        lon1 = service.lastData.longitude;
                        coordIniciales = false;
                    }

                    lat2 = service.lastData.latitude;
                    lon2 = service.lastData.longitude;
                }
                // se consigue la distancia entre las coordenadas
                distancia = CalcularDistancia(lat1, lon1, lat2, lon2);


                objetoTexto.GetComponent<Text>().text = "Distancia: " + distancia;

                PosicionActualVideo = PosicionInicialVideo - new Vector3(0, 0, distancia * 8);
                // Stop service if there is no need to query location updates continuously
                service.Stop();
                yield return updateTime;
            }
        } 
    }

    static float CalcularDistancia(float Lat1, float Lon1, float Lat2, float Lon2)
    {
        //se utiliza la formula de Haversine para encontrar la distancia entre 2 coordenadas
        var R = 6371e3; // metres 
        var Δφ = (Lat2 - Lat1) * Math.PI / 180; //distancia entre latitudes y longitudes
        var Δλ = (Lon2 - Lon1) * Math.PI / 180;
        var φ1 = Lat1 * Math.PI / 180; //para pasar a radianes
        var φ2 = Lat2 * Math.PI / 180;

        var a = Math.Sin(Δφ / 2) * Math.Sin(Δφ / 2) +
            Math.Cos(φ1) * Math.Cos(φ2) *
            Math.Sin(Δλ / 2) * Math.Sin(Δλ / 2);
        var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        var d = R * c;

        return (float)d;
    }

    
    
}


