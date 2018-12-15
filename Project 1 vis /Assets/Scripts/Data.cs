using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Data this class holds all data for a single day - and the overall score 
/// not the cleanest/ best way --- 
/// </summary>
public class Data {


    public int  roomNumber;
    public string date;
    public int codingInfo, artInfo,  adminInfo, readingInfo, otherInfo;
    public int maxScore = 10;
    public int productivityScore;
    public List<string> taskDiscriptions = new List<string>();
    //public string taskDiscriptions;


}
