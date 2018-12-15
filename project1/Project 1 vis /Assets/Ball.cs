using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    AudioSource a;
    bool canPlay = true;
	// Use this for initialization
	void Start () {
        a = GetComponent<AudioSource>();
        Invoke("stopSound", 8);
        //Invoke("destroyGO", 45);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision c)
    {
        if(!a.isPlaying && c.gameObject.tag =="floor")
        if(canPlay){
                a.PlayOneShot(a.clip);
            }
    }
    void destroyGO(){
        Destroy(gameObject);
    }
    void stopSound()
    {
        canPlay = false;
        //Destroy(gameObject);
    }
}
