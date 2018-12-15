using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random  ;
public class Items : MonoBehaviour {

    // Use this for initialization
    public int roomNumber;// just for testing if valuew was coppied right 
    //public int codingInfo, artInfo, adminInfo, readingInfo, otherInfo; //done in a bad way - just to test it out now 
    public GameObject[] objectsInstanPoints = new GameObject[3];//update this to 4 once i have more objects 
    public GameObject[] PointBalls = new GameObject[3];
    public BoxCollider triggerPoint;
    public GameObject thePlayer;
    PlayerGuide playerGuide;
    public Data dp;
    public bool canPass = true;


    void Start () {
        thePlayer = GameObject.Find("/player/cart");
        playerGuide = FindObjectOfType<PlayerGuide>();

        //showTotalTime(dp.readingInfo,0);
    }

    private void dropThePoints(int numberOfBalls, int locationAndPos)
    {
        for (int i = 0; i < numberOfBalls; i++)
        {
            float offSet = Random.Range(-0.4f, 1f);
            Vector3 tempPos = new Vector3(objectsInstanPoints[locationAndPos].transform.position.x + offSet,
                                          objectsInstanPoints[locationAndPos].transform.position.y,//change 0 to generic method and then send in 0 and the points 
                                          objectsInstanPoints[locationAndPos].transform.position.z + offSet);
            Instantiate(PointBalls[locationAndPos], tempPos, Quaternion.identity);

        }
    }

    // Update is called once per frame - change this to trigger tho - too much  extra processing 
    void Update () {
        float dist = Vector3.Distance(thePlayer.transform.position, transform.position);
        if (canPass)
        {
            if (dist <= 1 && dist >= 0)
            {
                dropThePoints(dp.readingInfo, 0);
                dropThePoints(dp.codingInfo, 1);
                dropThePoints(dp.artInfo, 2);
                showTotalTime(dp.readingInfo,0);
                showTotalTime(dp.codingInfo, 1); 
                showTotalTime(dp.artInfo, 2);
                playerGuide.StartCoroutine(playerGuide.SetText(dp.taskDiscriptions, dp.date));
                          
                canPass = false;
            }
        }
     
    }

    private void showTotalTime(int number , int pos)
    {
        Vector3 tempPos = new Vector3(objectsInstanPoints[pos].transform.position.x - 5f, 
                                      objectsInstanPoints[pos].transform.position.y,//change 0 to generic method and then send in 0 and the points 
                                      objectsInstanPoints[pos].transform.position.z );
        int min = number * 30;
        TimeSpan hr = TimeSpan.FromMinutes(min);
        GameObject textMesh;
        textMesh = new GameObject("TEXT");
        textMesh.AddComponent<MeshRenderer>();
        textMesh.AddComponent<TextMesh>();
        textMesh.GetComponent<TextMesh>().text =  "Time spent :"+ hr.ToString();
        textMesh.GetComponent<TextMesh>().fontSize = 8;

        Instantiate(textMesh, tempPos, Quaternion.identity);

    }



    //does not work --- instead trigger it based on distance?

    private void OnTriggerEnter(Collider other)
    {
        ////instantiate objects here ---- for now done in start but change it soon 
        if(other.tag=="Player"){
            Debug.Log("Player passed the room and the" +
                      "number of points for code : " + dp.codingInfo);
        }
        else {
            Debug.Log("sonething else hit it" + other.name);
        }
      
    }




}
