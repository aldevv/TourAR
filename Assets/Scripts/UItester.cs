using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UItester : MonoBehaviour {

    public GameObject textico;
	// Use this for initialization
	void Start () {
        textico.GetComponent<Text>().text = "SE ABRIOO";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
