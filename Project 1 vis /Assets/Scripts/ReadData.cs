using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*****
 //data conversion from CVS file structure based on tutorial by Game Programming Academy
*****8*/



public class ReadData : MonoBehaviour {

    public  static List<Data> dataPoints = new List<Data>();
    

    //for debuging purpuses 
    public string[] dataX ;
    TextAsset data;
    string[] row;
    public int test;
    Data d;

    // Use this for initialization

 
    public void Start () {

        test = 5;
        data = Resources.Load<TextAsset>("datapointsA");

        dataX = data.text.Split('*');


        for (int i = 0; i < dataX.Length; i++){
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
                for (int j = 0; j < taskSlists.Length; j ++){
                    d.taskDiscriptions.Add(taskSlists[j]);
                }

                dataPoints.Add(d);
            }




        }
        //outside of for loop is being retained - is it casue its local to start?
        Debug.Log("what about outer loop retained?"+dataPoints.Count);//end of for loop 
        //setData();
        //PrintItems(dataPoints);

      
    }

    private void Update()
    {
        Debug.Log("iNSIDE UPDATE" + dataPoints.Count);//end of for loop 
        Debug.Log(getList().Count);
    }


    public  List<Data> getList (){
        //PrintItems(dataPoints);
        Debug.Log("data points being retrieved ..."+ dataPoints.Count);
        return dataPoints;
    }

    void PrintItems(List<Data> da){
        Debug.Log("METHOD called" + da.Count);

        foreach( Data d in da ){
            Debug.Log(d.roomNumber);
            foreach(string s in d.taskDiscriptions){
                Debug.Log("tasks for day"+ d.date 
                          +"are :"+ s);
            }
        }
    }


    //i know it isnt best practice but creating an instance failed after a build - changing to static just to test it out - 
 
    //debugging and checking


}

