using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonLobby : MonoBehaviourPunCallbacks {

    public static PhotonLobby lobby;
    public GameObject battleButton;
    public Text statusText;
    RoomInfo[] rooms;

    // Use this for initialization
    void Awake () {
        lobby = this;
	}

    private void Start()
    {
        statusText.text = "Conectando..";
        PhotonNetwork.ConnectUsingSettings(); //Se conecta usando el asset PhotonServerSettings donde tambien esta la version (diferentes versiones nop juegan juntos)
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to the Photon master server");
        PhotonNetwork.AutomaticallySyncScene = true;
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
        int randomRoomName = Random.Range(0, 10000); 
        RoomOptions roomops = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)MultiplayerSettings.Instance.maxPlayer };
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
        PhotonNetwork.JoinRandomRoom(); 
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Se entro a un lobby");
    }

    public void OnCancelButtonClicked()
    {//Nada, no se puede cancelar
    }
}
