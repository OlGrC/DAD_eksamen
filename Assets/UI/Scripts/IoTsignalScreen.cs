using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Net;

public class IoTsignalScreen : MonoBehaviour
{
    public GameObject tmpCoolingPWin;
    public GameObject tmpCoolingPWout;
    public GameObject tmpCoolingWin;
    public GameObject tmpCoolingWout;
    public GameObject tmpTempMotorRoom;
    public GameObject tmpHumMotorRoom;

    public string phpURL;
    private string urlCoolingPWin;
    private string urlCoolingPWout;
    private string urlCoolingWin;
    private string urlCoolingWout;
    private string urlTempMotorRoom;
    private string urlHumMotorRoom;

    TextMeshProUGUI coolingPWinText;
    TextMeshProUGUI coolingPWoutText;
    TextMeshProUGUI coolingWinText;
    TextMeshProUGUI coolingWoutText;
    TextMeshProUGUI tempMotorRoomText;
    TextMeshProUGUI humMotorRoomText;


    // Start is called before the first frame update
    void Start()
    {
        coolingPWinText = tmpCoolingPWin.GetComponent<TextMeshProUGUI>();
        coolingPWoutText = tmpCoolingPWout.GetComponent<TextMeshProUGUI>();
        coolingWinText = tmpCoolingWin.GetComponent<TextMeshProUGUI>();
        coolingWoutText = tmpCoolingWout.GetComponent<TextMeshProUGUI>();
        tempMotorRoomText = tmpTempMotorRoom.GetComponent<TextMeshProUGUI>();
        humMotorRoomText = tmpHumMotorRoom.GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        urlCoolingPWin = phpURL + "?name=723TE301" + "&amount=1";
        urlCoolingPWout = phpURL + "?name=723TE302" + "&amount=1";
        urlCoolingWin = phpURL + "?name=723TE303" + "&amount=1";
        urlCoolingWout = phpURL + "?name=723TE304" + "&amount=1";
        urlTempMotorRoom = phpURL + "?name=301TE101" + "&amount=1";
        urlHumMotorRoom = phpURL +  "?name=301HE102" + "&amount=1";

        string coolingPWinData = GetDataFromDatabase(urlCoolingPWin);
        string coolingPWoutData = GetDataFromDatabase(urlCoolingPWout);
        string coolingWinData = GetDataFromDatabase(urlCoolingWin);
        string coolingWoutData = GetDataFromDatabase(urlCoolingWout);
        string tempMotorRoomData = GetDataFromDatabase(urlTempMotorRoom);
        string humMotorRoomData = GetDataFromDatabase (urlHumMotorRoom);

        coolingPWinText.text =  ":  " + GetDataByIndex(coolingPWinData, 1) + " °C";
        coolingPWoutText.text = ":  " + GetDataByIndex(coolingPWoutData, 1) + " °C";
        coolingWinText.text =   ":  " + GetDataByIndex(coolingWinData, 1) + " °C";
        coolingWoutText.text =  ":  " + GetDataByIndex (coolingWoutData, 1) + " °C";
        tempMotorRoomText.text =":  " + GetDataByIndex(tempMotorRoomData, 1) + " °C";
        humMotorRoomText.text = ":  " + GetDataByIndex(humMotorRoomData, 1) + " %";
    }
    private string GetDataByIndex(string data, int index)
    {
        string[] parts = data.Split(',');
        return parts[index];
    }

    private string GetDataFromDatabase(string url)
    {
        string response;
        using (WebClient client = new WebClient())
        {
            response = client.DownloadString(url);
        }
        return response;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
