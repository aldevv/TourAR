using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour {

    public VideoControls2 control;
    public Camera cameras;
    string panel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // detecta si se toca la pantalla
		if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = cameras.ScreenPointToRay(Input.GetTouch(0).position);
            // detecta si el ray toco algun objeto
            RaycastHit Hit;
            if (Physics.Raycast(ray, out Hit)) {

                panel = Hit.transform.name;
                if (panel == "Plane")
                {
                    control.PlayPauseVideo();
                }
            }
        }
	}
}
