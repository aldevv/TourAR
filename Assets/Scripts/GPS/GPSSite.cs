using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
public class GPSSite : MonoBehaviour
{
    public MovementVideo Data;
    public GameObject textoProximidad;
    public GameObject lati;
    public GameObject longi;
    public VideoPlayer video;
    public GameObject monitorTog;
    public CalcDistancia calculo2;
    bool primeraVez = false;
    ///////////////////////////////
    private float latSitio1 = 5.034707f;
    private float lonSitio1 = -75.458288f;
    /*private float latSitio2;
      private float lonSitio2;
      private float latSitio3;
      private float lonSitio3; */
    //////////////////////////////
    //distancia  minima permitida para poder mostrar el video
    private float DistanciaMinima = 25f;

    //tiempos para refrescar
    /*  private float waitTime = 3.0f;
      private float timer = 0.0f;
      private bool timerActive = false;
      */


    void Start()
    {
       

    }

    void Update()
    {
        
    }

    // PERMITE MOSTRAR EL VIDEO SI SE CUMPLE EL REQUISITO
    public void Triangulacion()
    {
        bool toogle;
        float Proximidad, Distancia1; //, Distancia2, Distancia3;
        // Data es un objeto tipo movement video
        lati.GetComponent<Text>().text = "Lat actual es "+ Data.lat2;
        longi.GetComponent<Text>().text ="Lon actual es "+ Data.lon2;

        // el objeto calculo 2 es de tipo calcDistancia
        Distancia1 = calculo2.CalcularDistancia(Data.lat2, Data.lon2, latSitio1, lonSitio1);
        Proximidad = Distancia1;
        Data.movimiento = Data.PosicionInicialVideo.z;
        //si la distancia del celular al sitio es menor o igual a la distancia minima permitida (en metros en este caso 10) entonces se activa el AR
        if (Proximidad <= DistanciaMinima)
        {
            toogle = true;
            monitorTog.GetComponent<VideoPlayer>().enabled = toogle;
            monitorTog.GetComponent<MeshRenderer>().enabled = toogle;
            
            textoProximidad.GetComponent<Text>().text = "Encontrado! :" + Proximidad + " metros";
           
            if (!primeraVez && video.isPlaying)
            {
                video.GetComponent<VideoPlayer>().Pause();
                primeraVez = true;
            }
        }
        else //este else deberia quitarse para el producto final ya que podria ser inconveniente que se quitara el video de la nada
        {
            toogle = false;
            video.GetComponent<VideoPlayer>().Pause();
            monitorTog.GetComponent<VideoPlayer>().enabled = toogle;
            monitorTog.GetComponent<MeshRenderer>().enabled = toogle;
            textoProximidad.GetComponent<Text>().text = "Proximidad: " + Proximidad + " metros";
        }











        /*Distancia2 = Data.CalcularDistancia(Data.lat1, Data.lon1, latSitio2, lonSitio2);
          Distancia3 = Data.CalcularDistancia(Data.lat1, Data.lon1, latSitio3, lonSitio3);


          */

        //Implementacion para multiples sitios

        //oh utilizar Mathf.min(Distancia1, Distancia2 , Distancia3);

        /*  if(Distancia1 < Distancia2 && Distancia1 < Distancia3)
          {
              //sitio 1 es el mas cercano
          }   else
          {
              if (Distancia2 < Distancia1 && Distancia2 < Distancia3)
              {
                  //sitio 2 es el mas cercano
              }
              else
              {
                  if (Distancia3 < Distancia2 && Distancia3 < Distancia1)
                  {
                      //sitio 3 es el mas cercano
                  }
              }
          } */

    }
}
