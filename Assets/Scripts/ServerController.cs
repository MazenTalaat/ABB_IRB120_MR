using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Oculus.Interaction;
using UnityEngine.UI;
using System;

public class ServerController : MonoBehaviour
{
    public GameObject toggleButtonPrefab;
    public GameObject scrollViewContent;
    public GameObject serverCylinder;
    public TextMeshProUGUI statusText;
    public List<Button> serverButtons;
    private List<int> emg1;
    private string serverIP;
    private short serverPort;
    private GameObject emgLine;

    // Start is called before the first frame update
    void Start()
    {
        UpdateServers();
        serverButtons[0].interactable = true;
        serverButtons[1].interactable = true;
        serverButtons[2].interactable = false;
    }

    public void UpdateServers()
    {
        for (int i=0; i<scrollViewContent.transform.childCount; i++)
        {
            Destroy(scrollViewContent.transform.GetChild(i).gameObject);
        }

        //discoveryResponses = RTClient.GetInstance().GetServers();
        //foreach (DiscoveryResponse server in discoveryResponses)
        //{
        //    var toggleButtonGO = GameObject.Instantiate(toggleButtonPrefab, scrollViewContent.transform);
        //    toggleButtonGO.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "Host name: " + server.HostName + "\nIP: " + server.IpAddress + ":" + server.Port;
        //    // print("************************************************");
        //    // print("Host name: " + server.HostName + "\nIP: " + server.IpAddress + ":" + server.Port);
        //    // print("************************************************");
        //    toggleButtonGO.GetComponent<ToggleDeselect>().group = scrollViewContent.GetComponent<ToggleGroup>();
        //    toggleButtonGO.GetComponent<ToggleDeselect>().onValueChanged.AddListener(delegate {
        //        if (toggleButtonGO.GetComponent<ToggleDeselect>().isOn)
        //        {
        //            serverIP = server.IpAddress;
        //            serverPort = server.Port;
        //        }
        //    });
        //}
    }

    // Update is called once per frame
    void Update()
    {
        // One -> A, Two -> B, Three -> X, Four -> Y
        if (OVRInput.GetDown(OVRInput.Button.Start) || Input.GetKeyDown("m"))
        {
            serverCylinder.SetActive(!serverCylinder.activeSelf);
        }
    }

public void ConnectOnClick()
    {
        StartCoroutine(Connect());
    }

    IEnumerator Connect()
    {
        //192.168.0.122 22222
        //RTClient.GetInstance().StartConnecting("192.168.0.122", 22222, false, true, false, false, true, true, false);
        //RTClient.GetInstance().StartConnecting(serverIP, serverPort, false, true, false, false, true, true, false);
        statusText.text = "Connecting ...";
        statusText.color = Color.yellow;
        print("Connecting ...");

        //while (RTClient.GetInstance().ConnectionState == RTConnectionState.Connecting)
        //{
        //    serverButtons[0].interactable = false;
        //    serverButtons[1].interactable = false;
        //    yield return null;
        //}
        //if (RTClient.GetInstance().ConnectionState == RTConnectionState.Connected)
        //{
        //    serverButtons[0].interactable = false;
        //    serverButtons[1].interactable = false;
        //    serverButtons[2].interactable = true;
        //    serverCylinder.SetActive(false);
        //    statusText.text = "Connected";
        //    statusText.color = Color.green;
        //    print("Connected");
        //}
        //else
        //{
        //    serverButtons[0].interactable = true;
        //    serverButtons[1].interactable = true;
        //    serverButtons[2].interactable = false;
        //    statusText.text = "Could not connect to this server";
        //    statusText.color = Color.red;
        //    print("Could not connect to this server");
        //}
        yield return null;
    }

    public void DisconnectOnClick()
    {
        serverButtons[0].interactable = true;
        serverButtons[1].interactable = true;
        serverButtons[2].interactable = false;
        statusText.text = "Waiting";
        statusText.color = Color.white;
        //RTClient.GetInstance().Disconnect();
    }
}
