using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateDataOBJ : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ThePalayer")
        {
            Debug.Log("PLAYER COLLIDED WITH ROOM ");
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
