using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Net;

public class PopUpUnitInfo : MonoBehaviour
{
    public GameObject popUpMachine;
    public GameObject tmpTagName;
    public GameObject tmpMachine;
    public GameObject tmpEngine;
    public GameObject tmpGenerator;
    public GameObject tmpkVA;
    public GameObject tmpStatus;
    public GameObject tmpFrequency;
    public GameObject tmpVoltage;
    public GameObject tmpVelocity;
    public GameObject tmpLoad;
    public GameObject tmpLoadkVAR;
    public GameObject tmpL1I;
    public GameObject tmpL2I;
    public GameObject tmpL3I;

    public string phpURL;
    private string urlStatus;
    private string urlFrequency;
    private string urlVoltage;
    private string urlVelocity;
    private string urlLoad;
    private string urlLoadkVAR;
    private string urlL1I;
    private string urlL2I;
    private string urlL3I;

    TextMeshProUGUI tagnameText;
    TextMeshProUGUI machineText;
    TextMeshProUGUI engineProdText;
    TextMeshProUGUI genProdText;
    TextMeshProUGUI kVAText;
    TextMeshProUGUI statusText;
    TextMeshProUGUI frequencyText;
    TextMeshProUGUI voltageText;
    TextMeshProUGUI velocityText;
    TextMeshProUGUI loadText;
    TextMeshProUGUI loadkVARText;
    TextMeshProUGUI l1IText;
    TextMeshProUGUI l2IText;
    TextMeshProUGUI l3IText;

    // Start is called before the first frame update
    void Start()
    {
        popUpMachine.SetActive(false);
        tagnameText = tmpTagName.GetComponent<TextMeshProUGUI>();
        machineText = tmpMachine.GetComponent<TextMeshProUGUI>();
        engineProdText = tmpEngine.GetComponent<TextMeshProUGUI>();
        genProdText = tmpGenerator.GetComponent<TextMeshProUGUI>();
        kVAText = tmpkVA.GetComponent<TextMeshProUGUI>();
        statusText = tmpStatus.GetComponent<TextMeshProUGUI>();
        frequencyText = tmpFrequency.GetComponent<TextMeshProUGUI>();
        voltageText = tmpVoltage.GetComponent<TextMeshProUGUI>();
        velocityText = tmpVelocity.GetComponent<TextMeshProUGUI>();
        loadText = tmpLoad.GetComponent<TextMeshProUGUI>();
        loadkVARText = tmpLoadkVAR.GetComponent<TextMeshProUGUI>();
        l1IText = tmpL1I.GetComponent<TextMeshProUGUI>();
        l2IText = tmpL2I.GetComponent<TextMeshProUGUI>();
        l3IText = tmpL3I.GetComponent<TextMeshProUGUI>();
    }

    // Update on trigger enter collider
    private void OnTriggerEnter(Collider other)
    {
        urlStatus = phpURL + "?name=" + name + "-RUN" + "&amount=1";
        urlFrequency = phpURL + "?name=" + name + "-GEN-FRQ" + "&amount=1";
        urlVoltage = phpURL + "?name=" + name + "-GEN-V" + "&amount=1";
        urlVelocity = phpURL + "?name=" + name + "-VELOC" + "&amount=1";
        urlLoad = phpURL + "?name=" + name + "-LOAD" + "&amount=1";
        urlLoadkVAR = phpURL + "?name=" + name + "-LOAD-KVAR" + "&amount=1";
        urlL1I = phpURL + "?name=" + name + "-I-L1" + "&amount=1";
        urlL2I = phpURL + "?name=" + name + "-I-L2" + "&amount=1";
        urlL3I = phpURL + "?name=" + name + "-I-L3" + "&amount=1";

        popUpMachine.SetActive(true);
        tagnameText.text = name;

        if (tagnameText.text == "DG1") 
        {
            machineText.text = "Diesel-Electrical GenSet";
            engineProdText.text =  "Volvo Penta";
            genProdText.text = "Stamford";
            kVAText.text = "180 kVA";
        }
        else if (tagnameText.text == "DG2")
        {
            machineText.text = "Diesel-Electrical GenSet";
            engineProdText.text =  "Volvo Penta";
            genProdText.text = "Stamford";
            kVAText.text = "180 kVA";
        }

        string statusData = GetDataFromDatabase(urlStatus);
        string frequencyData = GetDataFromDatabase(urlFrequency);
        string voltageData = GetDataFromDatabase(urlVoltage);
        string velocityData = GetDataFromDatabase (urlVelocity);
        string loadData = GetDataFromDatabase(urlLoad);
        string loadkVARData = GetDataFromDatabase(urlLoadkVAR);
        string l1IData = GetDataFromDatabase(urlL1I);
        string l2IData = GetDataFromDatabase(urlL2I);
        string l3IData = GetDataFromDatabase(urlL3I);

        string tempStatusText = GetDataByIndex(statusData, 1);
        if (tempStatusText == "1")
        {
            statusText.text = "Running";
        }
        else
        {
            statusText.text = "Stopped";
        }

        frequencyText.text = GetDataByIndex(frequencyData, 1) + " Hz";
        voltageText.text = GetDataByIndex(voltageData, 1) + " V";
        velocityText.text = GetDataByIndex(velocityData, 1) + " RPM";
        loadText.text = GetDataByIndex(loadData, 1) + " kW";
        loadkVARText.text = GetDataByIndex(loadkVARData, 1) + " kVAR";
        l1IText.text = GetDataByIndex(l1IData, 1) + " A";
        l2IText.text = GetDataByIndex(l2IData, 1) + " A";
        l3IText.text = GetDataByIndex(l3IData, 1) + " A";
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

    // Update on trigger exit collider
    private void OnTriggerExit(Collider other)
    {
        popUpMachine.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
