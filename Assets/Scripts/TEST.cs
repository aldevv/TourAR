using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour {




    Vector3 originalposition;

    void Start () {

       this.originalposition = transform.position;
         
    } 
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("space"))
            transform.position = new Vector3(8, 8, 8);
           
        


	}
}
