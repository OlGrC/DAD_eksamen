using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopUpUnitInfo : MonoBehaviour
{
    public GameObject popUpMachine;
    public GameObject tmpTagName;
    public GameObject tmpMachine;
    public GameObject tmpEngine;
    public GameObject tmpGenerator;
    public GameObject tmpkVA;

    TextMeshProUGUI tagnameText;
    TextMeshProUGUI machineText;
    TextMeshProUGUI engineProdText;
    TextMeshProUGUI genProdText;
    TextMeshProUGUI kVAText;

    // Start is called before the first frame update
    void Start()
    {
        popUpMachine.SetActive(false);
        tagnameText = tmpTagName.GetComponent<TextMeshProUGUI>();
        machineText = tmpMachine.GetComponent<TextMeshProUGUI>();
        engineProdText = tmpEngine.GetComponent<TextMeshProUGUI>();
        genProdText = tmpGenerator.GetComponent<TextMeshProUGUI>();
        kVAText = tmpkVA.GetComponent<TextMeshProUGUI>();
    }

    // Update on trigger enter collider
    private void OnTriggerEnter(Collider other)
    {
        popUpMachine.SetActive(true);
        tagnameText.text = name;

        if (tagnameText.text == "DG1") 
        {
            machineText.text = "Diesel-Electrical GenSet";
            engineProdText.text =  "Volvo Penta";
            genProdText.text = "Stamford";
            kVAText.text = "3500 kVA";
        }
        else if (tagnameText.text == "DG2")
        {
            machineText.text = "Diesel-Electrical GenSet";
            engineProdText.text =  "Volvo Penta";
            genProdText.text = "Stamford";
            kVAText.text = "3500 kVA";
        }
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
