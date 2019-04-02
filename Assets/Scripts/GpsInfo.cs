using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GpsInfo : MonoBehaviour
{
    public GameObject canvasGPS;
    private bool toogleGPS= true;

    // Use this for initialization
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
        myButtonStyle.fontSize = 30;

        if (GUI.Button(new Rect(0, 0, 80, 35), "GPS", myButtonStyle))
        {
            canvasGPS.gameObject.SetActive(toogleGPS);
            toogleGPS = toogleGPS == true ? false : true;
        }



    }
}
