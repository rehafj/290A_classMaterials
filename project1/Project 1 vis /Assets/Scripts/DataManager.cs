using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// this is the overall manager for instanitaing rooms / tracks..etc 

/// </summary>
public class DataManager : MonoBehaviour {

    //Iinitilizations ---- 
    int numberOfDays = 10;
    public GameObject room;
    public GameObject tracks;
    public GameObject dataObject; //truing it out through gam eobjects - calling by ref yeilds wrong results for somereason - 
    float lenghtofARoom, leangthOfGameobject;
    Vector3 lastroomPos;
    private float lastroomZ = 0;
    //public List<Data> datapoints;
    public int totalCode, totalReading, totalArt, totalAdmin;

    List<GameObject>roomsList = new List<GameObject>() ;

    public string codingTotalHrs, artTotalHrs, readingTotalHrs;
    public GameObject lastRoom;

    PlayerController plr;
    public GameObject Reader;
    //public int x;

    //----------------------------------------------------------//
    //----------------------adding script here c------------------------------------//
    //----------------------------------------------------------//

    public  List<Data> dataPoints = new List<Data>();
    //for debuging purpuses 
    public string[] dataX;
    TextAsset data;
    string[] row;
    public int test;
    Data d;

    // excuse the mess - script is too big, code coppied from my other script for testing ( unity acted oddly after a build with accsessing data via readeR)  ---

    void Start () {



        test = 5;
        data = Resources.Load<TextAsset>("datapointsA");

        dataX = data.text.Split('*');


        //this four loop ( reading from an cvs file) is based on a tutorial by codingacadmay - check the credits section :) 
        setData();
  
        init();
        spaceSetUp(dataPoints.Count, lastroomZ, room, lenghtofARoom +3);//was 1 (methof 1st)
        setUpObjects();
        spaceSetUp(dataPoints.Count * 4, lastroomZ, tracks, leangthOfGameobject +3);
        plr = FindObjectOfType<PlayerController>();


 }

   

    private void setUpObjects()
    {
        for (int i = 0; i < roomsList.Count; i++){
            roomsList[i].GetComponent<Items>().roomNumber = dataPoints[i].roomNumber;
            //roomsList[i].GetComponent<Items>().dp[i] = datapoints[i];
            roomsList[i].GetComponent<Items>().dp = dataPoints[i]; //for per room instantaion - set each row as an item collection
            addPoints(i);

        }
    }

    private void addPoints(int i)
    {
        totalArt += dataPoints[i].artInfo;
        totalCode += dataPoints[i].codingInfo;
        totalReading += dataPoints[i].readingInfo;
        totalAdmin += dataPoints [i].adminInfo;

        codingTotalHrs = returnTimeiNHous(totalCode);
        artTotalHrs = returnTimeiNHous(totalArt);
        readingTotalHrs = returnTimeiNHous(totalReading);

    


    }

    string returnTimeiNHous(float min){
        TimeSpan hr = TimeSpan.FromMinutes(min * 30);
        return hr.ToString();

    }

    private void init(){

        // clean up later 
        lenghtofARoom = voidGetLength(room); //room.GetComponentInChildren<MeshRenderer>().bounds.size.z;
        leangthOfGameobject = voidGetLength(tracks);
        lastroomPos = new Vector3(0, 0, 0);
        //lastroomZ = lenghtofARoom +2;

    }

    float voidGetLength(GameObject gameobj){
        float Zlength = gameobj.GetComponentInChildren<MeshRenderer>().bounds.size.z;
        return Zlength;
    }



    //for testing - change later just quick methods for  now 
    //coying the method below - for some reason after building it it removed e rything ---- debugging excuse unclean code 
    private void spaceSetUp(int maxLimit, float roomSize, GameObject instantiatedObj, float length)
    {
        lastroomZ = length;

        for (int i = 0; i < maxLimit; i++)
        {

            Vector3 roomPos = new Vector3(instantiatedObj.transform.position.x,
                                          instantiatedObj.transform.position.y,
                                          gameObject.transform.position.z + lastroomZ);

            GameObject obj =  Instantiate(instantiatedObj, roomPos, Quaternion.identity);
            if(instantiatedObj.name == "room"){
                roomsList.Add(obj);
            }
          
            lastroomZ = roomPos.z + length;

            if(instantiatedObj.name == "tracks 1" && i == maxLimit -1 )
            {//obj.name == "tracks 1" &&
                Vector3 newPos = new Vector3(roomPos.x,
                                      roomPos.y,
                                      roomPos.z - 20f);
                Instantiate(lastRoom, newPos, Quaternion.identity);
                Debug.Log("last item instanintaed!");
            }

        }
    }


    private void setData()
    {
        for (int i = 0; i < dataX.Length; i++)
        {
            if (i == 0)
            {
                //skip the first header
            }
            else
            {
                row = dataX[i].Split(',');
                d = new Data();
                int.TryParse(row[0], out d.roomNumber);
                d.date = row[1];
                d.codingInfo = int.Parse(row[2]);
                d.artInfo = int.Parse(row[3]);
                d.adminInfo = int.Parse(row[4]);
                d.readingInfo = int.Parse(row[5]);
                d.otherInfo = int.Parse(row[6]);

                d.productivityScore = int.Parse(row[7]);

                string[] taskSlists = row[8].Split('-');
                for (int j = 0; j < taskSlists.Length; j++)
                {
                    d.taskDiscriptions.Add(taskSlists[j]);
                }

                dataPoints.Add(d);
            }

        }
    }


}
