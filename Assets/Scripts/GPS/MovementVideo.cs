using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MovementVideo : MonoBehaviour
{

    //Coordenadas del video
    private float lat1;
    private float lon1;
    public float lat2;
    public float lon2;
    public float movimiento;
    private Vector3 PosicionDebugVideo;
    public Vector3 PosicionInicialVideo;
    private Vector3 PosicionActualVideo;
    public GameObject objetoTexto;
    public GameObject LatTexto;
    public GameObject LonTexto;
    public GameObject Iteraciones;
    public GameObject DebugDistance;
    public GPSSite GEO;
    public CalcDistancia calculo;
    private bool coordIniciales = true;
    float distancia;
    private bool loop = true;
    
    // lo´primero que se ejecuta al iniciar la aplicacion
    void Awake()
    {   
        firstrun();
    }

    //es para conseguir el gps de manera inmediata al iniciar la aplicacion
    IEnumerator firstrun()
    {
        bool enableByRequest = true;

        int maxWait = 10;

        LocationService service = Input.location;

        if (!enableByRequest && !service.isEnabledByUser)
        {
            Debug.Log("Servicios de GPS no habilitados por el usuario");
            yield break;
        }

        service.Start(1f, 1f);

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
            distancia = calculo.CalcularDistancia(lat1, lon1, lat2, lon2);
            movimiento = distancia * 12;

            objetoTexto.GetComponent<Text>().text = "Distancia: " + distancia;

        }
    }


    void Start()
    {
        
        PosicionInicialVideo = transform.position;
        PosicionActualVideo = transform.position;
        PosicionActualVideo = PosicionInicialVideo - new Vector3(0, 0, movimiento);

        //coroutine permite que la funcion se ejecute con algunas condiciones de ejecucion (wait 5 seconds etc)
        // en lugar de ponerlo en el update se pone en start y tiene un while dentro para que se siga repitiendo
        StartCoroutine(getLocation());
    }

    
    void Update()
    {    // mueve el video segun se va moviendo el celular!
        if (transform.position.z >= 110)
        {                                                                 // mientras mas pequeño el numero mas despacio se acerca
            transform.position = Vector3.Lerp(transform.position, PosicionActualVideo, 0.008f);
        }
        else
        {
            PosicionDebugVideo = PosicionActualVideo;
            PosicionDebugVideo.z = 170;
            DebugDistance.GetComponent<Text>().text = "Debug: " + movimiento;
            transform.position = Vector3.Lerp(transform.position, PosicionDebugVideo, 0.05f);
        }



    }

    //codigo encargado de pedir la informacion GPS al celular

    IEnumerator getLocation()
    {

        bool enableByRequest = true;
        int itera = 1;

        //esto comienza el loop 

        //https://answers.unity.com/questions/759854/unity3d-location-services-not-updating-regularly.html
        // el while puede ser redundante, se deben hacer pruebas (poniendo las actualizaciones en el update)
        //ademas testear esto https://stackoverflow.com/questions/41783288/auto-updating-gps-location
        //poner el return yield wait para esperar segundos

      /*  float UPDATE_TIME = 2f; //Every  1 seconds
        WaitForSeconds updateTime = new WaitForSeconds(UPDATE_TIME);
        */
        while (loop)  
        {
            int maxWait = 10;
            Iteraciones.GetComponent<Text>().text = "Iteracion #: " + itera;
            itera++;

            LocationService service = Input.location;

            if (!enableByRequest && !service.isEnabledByUser)
            {
                Debug.Log("Servicios de GPS no habilitados por el usuario");
                yield break;
            }

            service.Start(3f, 0.1f);

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
            distancia = calculo.CalcularDistancia(lat1, lon1, lat2, lon2);
            movimiento = distancia * 11;

            objetoTexto.GetComponent<Text>().text = "Distancia: " + distancia;

            PosicionActualVideo = PosicionInicialVideo - new Vector3(0, 0, movimiento);
            // Stop service if there is no need to query location updates continuously

            // el metodo Triangulacion del objeto GEO es el que decide si mostrar o no el video 
            GEO.Triangulacion();
            service.Stop();

           // yield return updateTime;
        }
    }
}


