using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGuide : MonoBehaviour {

    Text mytext;
    float timer = 10;
    Animator anim;
    public int i = 0;
	// Use this for initialization
	void Start () {
        mytext = GetComponentInChildren<Text>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if(timer <= 0){
            i++;
            if(i==1){
                mytext.text = "interact witht the buttons to move, play, speed up or slow down( slowing down can take you in reverse!)";

            }
            if(i ==2 ){
                mytext.text = "in this tour, each ball represents 30 min  ";
            }
            if (i >= 3)
            {
                anim.SetBool("canEnd", true); //change this to cond when a cou nter reaches 3 ( text switched already
            }
            timer = 4;
        }
	}


    public IEnumerator SetText(List<string> text, string date){
        Debug.Log("settext was called!");
        int i = text.Count;
        yield return new WaitForSeconds(1);
        anim.SetBool("canEnd", false);
        anim.Play("openAnimation_gui");
        string fullStrig = " ,  ";
        foreach( string t in text){
            fullStrig = fullStrig + t;
        }
        mytext.text = "tasks for this date: " + 
            date + " are: \n" + fullStrig;

        yield return new WaitForSeconds(8);
        anim.SetBool("canEnd", true);

        /*
        anim.Play("openAnimation_gui");
        string fullStrig = " "; 
        while (i >=0){
            fullStrig += text[i] + " \n";
        }
        mytext.text = fullStrig;
        yield return new WaitForSeconds(5);
        anim.SetBool("canEnd", true);
*/
    }



}
