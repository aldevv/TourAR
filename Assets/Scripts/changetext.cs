using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changetext : MonoBehaviour {

    private GameObject newtext;
    
     
    // Use this for initialization
    void Start () {
        newtext = GameObject.FindGameObjectWithTag("Texto");
        newtext.GetComponent<Text>().text = "LO CAMBIASTE!!";
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
