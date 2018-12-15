using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


class EndDisplay : MonoBehaviour
{
   public Text text;
    private void Start()
    {
        DataManager dataManager = FindObjectOfType<DataManager>();
        text = gameObject.GetComponentInChildren<Text>();
        text.text = "TotalTime spent 14 days --> on art projects :" + dataManager.artTotalHrs +
              "\n TotalTime spent on code :" + dataManager.codingTotalHrs +
              "\n TotalTime spent on reading/ learning materials :" + dataManager.readingTotalHrs;
    }
}