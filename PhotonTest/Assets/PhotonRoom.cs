﻿using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhotonRoom : MonoBehaviourPunCallbacks
{

    // Room info
    public static PhotonRoom Room = null;
    private PhotonView pv;
    public bool isGameLoaded;
    public int currentScene;

    //Player info
    private Player[] photonPlayers;
    public int playersInRoom;
    public int myNumberInRoom;

    public int playersInGame;

    //Delayed start
    
    private bool readyToStart;
    public float startingTime;
    private float atMaxPlayer;
    private float timeToStart;

    private const int DefaultWaitTimeToStartGameWhenRoomIsFull = 6;

    void Awake()
    {
        if (Room == null)
        {
            Room = this;
        }
        else
        {
            if (Room != this)
            {
                Destroy(Room.gameObject);
                Room = this;
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        pv = GetComponent<PhotonView>();
        readyToStart = false;
        atMaxPlayer = DefaultWaitTimeToStartGameWhenRoomIsFull; //Cuenta regresiva que arranca de 5
        timeToStart = startingTime;
    }
    public override void OnEnable()
    {
        base.OnEnable();
        PhotonNetwork.AddCallbackTarget(this);
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }
    public override void OnDisable()
    {
        base.OnDisable();
        PhotonNetwork.RemoveCallbackTarget(this);
        SceneManager.sceneLoaded -= OnSceneFinishedLoading;
    }

    // Update is called once per frame
    void Update()
    {
        if (playersInRoom == 1)
        {
            RestartTimer();
        }
        
        if (isGameLoaded == false)
        {
            if (readyToStart)
            {
                atMaxPlayer -= Time.deltaTime;
                timeToStart = atMaxPlayer;
                Debug.Log("Display time to start to the players " + timeToStart);
            }
        
            if (timeToStart <= 0)
            {
                StartGame();
            }
        }
    }

    public override void OnJoinedRoom() //Este callback se llama cuendo YO entro al room
    {
        base.OnJoinedRoom();
        Debug.Log("Se entro a un room");

        photonPlayers = PhotonNetwork.PlayerList;
        playersInRoom = photonPlayers.Length;

        myNumberInRoom = playersInRoom; // Mi numero es el tamaño de la lista porque cuando me uni incremento en uno
        PhotonNetwork.NickName = myNumberInRoom.ToString();

        Debug.Log("Im player " + myNumberInRoom +", Current players in room " + playersInRoom + " / " + MultiplayerSettings.Instance.maxPlayer);
        
        if (playersInRoom == MultiplayerSettings.Instance.maxPlayer)
        {
            readyToStart = true;
            if (PhotonNetwork.IsMasterClient == false)
                return; //No podemos hacer nada porque no somos el master
            PhotonNetwork.CurrentRoom.IsOpen = false;
        }

    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
        Debug.Log("Uh, el player " + (otherPlayer.IsMasterClient ? "MASTER" : "ESCLAVO") + " se fue del room");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer) //Este callback se llama cuando yo estoy en el room y entra otro
    {
        base.OnPlayerEnteredRoom(newPlayer);
        photonPlayers = PhotonNetwork.PlayerList;
        playersInRoom++;

        Debug.Log("Im player " + myNumberInRoom + ", Current players in room " + playersInRoom + " / " + MultiplayerSettings.Instance.maxPlayer);

        if (playersInRoom == MultiplayerSettings.Instance.maxPlayer)
        {
            readyToStart = true;
            if (PhotonNetwork.IsMasterClient == false)
            {
                return;
            }
            PhotonNetwork.CurrentRoom.IsOpen = false;
        }
        
    }

    private void StartGame()
    {
        isGameLoaded = true;

        if (PhotonNetwork.IsMasterClient == false)
            return; //Si no soy el master no tengo que hacer nada

        if (PhotonNetwork.CurrentRoom.IsOpen)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
        }
        else
        {
            Debug.LogWarning("El room ya estaba cerrado");
        }

        PhotonNetwork.LoadLevel(MultiplayerSettings.Instance.multiplayerScene); //El master carga la escena y debido a que lobby tiene AutomaticallySyncScene= true los clientes reciben un mensaje y tambien la cargan
    }

    private void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        currentScene = scene.buildIndex;
        if (currentScene == MultiplayerSettings.Instance.multiplayerScene)
        {
            isGameLoaded = true;
            Debug.Log("Game loaded");
            
            pv.RPC("RPC_LoadedGameScene", RpcTarget.MasterClient);
        }
    }
    private void RestartTimer()
    {
        timeToStart = startingTime;
        atMaxPlayer = DefaultWaitTimeToStartGameWhenRoomIsFull;
        readyToStart = false;
    }

    [PunRPC]
    private void RPC_LoadedGameScene()
    {
        playersInGame++;
    }

    
}
