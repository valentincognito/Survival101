using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonNetworkManager : Photon.MonoBehaviour {

    [SerializeField] private Text connectText;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject lobbyCamera;

    // Use this for initialization
    void Start ()
    {
        PhotonNetwork.ConnectUsingSettings("v1.0");
	}

    public virtual void OnJoinedLobby()
    {
        Debug.Log("lobby joined");
        //RoomOptions roomOptions = new RoomOptions();
        PhotonNetwork.JoinOrCreateRoom("New", null, null);
    }

    public virtual void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate(player.name, spawnPoint.position, spawnPoint.rotation, 0);
        lobbyCamera.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        connectText.text = PhotonNetwork.connectionStateDetailed.ToString();
	}
}
