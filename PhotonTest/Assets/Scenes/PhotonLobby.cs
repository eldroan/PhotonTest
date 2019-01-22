using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonLobby : MonoBehaviourPunCallbacks {

    public static PhotonLobby lobby;
    public GameObject battleButton;
    public GameObject cancelButton;
    public Text statusText;
    RoomInfo[] rooms;

    // Use this for initialization
    void Awake () {
        lobby = this;
	}

    private void Start()
    {
        statusText.text = "Conectando..";
        PhotonNetwork.ConnectUsingSettings(); //Setear la version en PhotonServerSettings
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to the Photon master server");
        statusText.text = "Conectado!!";
        battleButton.SetActive(true);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Tried to join a randon game but failed, there must be no open games avaiable");
        CreateRoom();
    }

    void CreateRoom()
    {
        int randomRoomName = Random.Range(0, 10000); //Mira con la cara que te mira conan, esto puede tirar 2 nombres iguales
        RoomOptions roomops = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 10 };
        PhotonNetwork.CreateRoom("Room" + randomRoomName, roomops);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Tried to create a new room but failed, there must already be a room with the same name");
        CreateRoom();
    }
    
    public void OnBattleButtonClicked()
    {
        battleButton.SetActive(false);
        cancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom(); 
    }
    public override void OnJoinedLobby()
    {
        Debug.Log("Se entro a un lobby");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Se entro a un room");
    }
    public void OnCancelButtonClicked()
    {
        cancelButton.SetActive(false);
        battleButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }
}
