using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    public GameObject DebugInfo;
    public GameObject DebugInfo2;
    public GameObject DebugInfo3;
    private bool toogle = true;



    void Start()
    {
        

    }
    // Update is called once per frame
    void Update()
    {

    }

    private void OnGUI()
    {
        GUI.Box(new Rect(220, 1770, 1185, 215), "");

        if (GUI.Button(new Rect(815, 1800, 250, 80), "Debug"))
        {
            
            DebugInfo.gameObject.SetActive(toogle);
            toogle = toogle == true ? false : true;
        }

        if (GUI.Button(new Rect(535, 1800, 250, 80), "GPS"))
        {
            DebugInfo2.gameObject.SetActive(toogle);
            toogle = toogle == true ? false : true;
        }

        if (GUI.Button(new Rect(260, 1800, 250, 80), "Info Sitio"))
        {
            DebugInfo3.gameObject.SetActive(toogle);
            toogle = toogle == true ? false : true;
        }
    }
}
