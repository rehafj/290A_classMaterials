using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastRoomDisplays : MonoBehaviour {
    public GameObject thePlayer;
    DataManager dataManager;
    public GameObject stoppingpoint;
    PlayerController plr;
    EndDisplay endDisplay;

    //copied for now for quick implementation ---- refactor later 
    public GameObject[] objectsInstanPoints = new GameObject[3];//update this to 4 once i have more objects 
    public GameObject[] PointBalls = new GameObject[3];
    public bool canPass = true;
    // Use this for initialization
    void Start () {
        plr = FindObjectOfType<PlayerController>();
        thePlayer = GameObject.Find("/player/cart");
        dataManager = FindObjectOfType<DataManager>();

    }

    // Update is called once per frame
    void Update () {
        float dist = Vector3.Distance(thePlayer.transform.position, stoppingpoint.transform.position);
        if (canPass)
        {
            if (dist <= 5 && dist >= 0)
            {
                plr.haultPlayer();
                dropAllPoints(dataManager.totalReading, 0);
                dropAllPoints(dataManager.totalCode, 1);
                dropAllPoints(dataManager.totalReading, 2);
          
                canPass = false;


            }
        }

    }

    //copied for now -- call method later an dmake it more generic 
    private void dropAllPoints(int numberOfBalls, int locationAndPos)
    {
        for (int i = 0; i < numberOfBalls; i++)
        {
            float offSet = Random.Range(-0.2f, 0.2f);
            Vector3 tempPos = new Vector3(objectsInstanPoints[locationAndPos].transform.position.x + offSet,
                                          objectsInstanPoints[locationAndPos].transform.position.y,//change 0 to generic method and then send in 0 and the points 
                                          objectsInstanPoints[locationAndPos].transform.position.z + offSet);
            Instantiate(PointBalls[locationAndPos], tempPos, Quaternion.identity);

        }
    }
}
