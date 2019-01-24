using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour {

    public bool isMyTurn;
    public string nick;
    private PhotonView pv;
    public Text esMiTurno;
    public Text minick;
    public Data myData;

    // Use this for initialization
    void Awake() {
        isMyTurn = PhotonNetwork.IsMasterClient;

        pv = this.GetComponent<PhotonView>();
        nick = PhotonNetwork.IsMasterClient ? "Maestro" : "Esclavo";
        PhotonNetwork.NickName = nick;
    }

    // Update is called once per frame
    void Update() {
        if (isMyTurn)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                pv.RPC("RPC_PressButton", RpcTarget.All, nick, "A");
                pv.RPC("RPC_SharedData", RpcTarget.Others, JsonUtility.ToJson(myData));
                isMyTurn = false;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                pv.RPC("RPC_PressButton", RpcTarget.All, nick, "S");
                pv.RPC("RPC_SharedData", RpcTarget.Others, JsonUtility.ToJson(myData));

                isMyTurn = false;
            }
        }


        esMiTurno.text = isMyTurn ? "SI" : "NO";
        minick.text = nick.ToString();
    }

    [PunRPC]
    private void RPC_PressButton(string caller, string buttonPressed)
    {
        if (caller.Equals(nick))
        {
            Debug.Log("Aprete el boton " + buttonPressed);
        }
        else
        {
            Debug.Log(caller + " apreto el boton " + buttonPressed);
            isMyTurn = true;
        }
    }

    [PunRPC]
    private void RPC_SharedData(string jsonDataReceived)
    {
        myData = JsonUtility.FromJson<Data>(jsonDataReceived);
    }
}
