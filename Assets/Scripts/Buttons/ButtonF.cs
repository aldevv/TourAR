using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ButtonF : MonoBehaviour
{

    public GameObject about;
    public GameObject imagen;
    public GameObject texto;
    private bool toogleAbout = true;
    private bool toogleGps = false;
    private bool toogleImagen = true;
    private bool toogleTexto = true;
    public GpsInfo activarBoton;
    public VideoControls2 botonPlay;
   
    

    void Start()
    {


    }
    // Update is called once per frame
    void Update()
    {

    }

    private void OnGUI()
    {
        GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
        myButtonStyle.fontSize = 50;

        GUI.Box(new Rect(220, 1770, 1185, 215), "");

        
        //////////////

        if (GUI.Button(new Rect(815, 1800, 250, 80), "Acerca de" , myButtonStyle))
        {

            about.gameObject.SetActive(toogleAbout);
            toogleGps = true;
            if (toogleAbout && toogleGps)
            {
                activarBoton.gameObject.SetActive(true);
            } else
            {
                activarBoton.gameObject.SetActive(false);
            }
            toogleAbout = toogleAbout == true ? false : true;
        }

        if (GUI.Button(new Rect(535, 1800, 250, 80), "Imagen" , myButtonStyle))
        {  
            imagen.gameObject.SetActive(toogleImagen);

            if (botonPlay.isItPlaying() && toogleImagen)
            {
                botonPlay.PlayPauseVideo();
            }
            toogleImagen = toogleImagen == true ? false : true;

        }

        if (GUI.Button(new Rect(260, 1800, 250, 80), "Info Sitio", myButtonStyle))
        {
            texto.gameObject.SetActive(toogleTexto);
            toogleTexto = toogleTexto == true ? false : true;
        }
    }
}
