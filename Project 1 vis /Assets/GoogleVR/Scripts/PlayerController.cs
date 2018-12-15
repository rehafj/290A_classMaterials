using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    ////just for tesring 

    public Rigidbody m_Rigidbody;
    public float m_Speed = 0.2f;
    public bool canGo = false;
    // Use this for initialization
    void Start()
    {
        m_Rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canGo){
            m_Rigidbody.velocity = transform.forward * m_Speed;

        } else{
            m_Rigidbody.velocity = Vector3.zero;
        }

    }

    public void stopPlayer(){
        //Debug.Log("clicked! can go is " + canGo);
       
        if(canGo == false){
            canGo = true;
            //m_Speed = 0.66f;
            return;
           
        }
        if( canGo ==true) {
            canGo = false; 
            //m_Speed = 0f;
            return;
        }
    }

    public void  haultPlayer(){
        Debug.Log("stopping player was called");
        m_Speed = 0f;
        canGo = false;
    }

    public void speedUp(){
        if (! (m_Speed>= 50))
            m_Speed += 5;
        else
            m_Speed = 3;
    }
    public void slowDown()
    {
        if(!(m_Speed <=-10))
        m_Speed -= 5;
        else
            m_Speed = 2;
    }


}


////have the player move based on sections and go on when they look at the atom --- 