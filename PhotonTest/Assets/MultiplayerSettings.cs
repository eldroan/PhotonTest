using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerSettings : MonoBehaviour {

	public static MultiplayerSettings Instance { get; private set; }
    /*public bool delayedStart;*/ // Si es true esperamos a que todos esten para arrancar
    public int maxPlayer;

    public int menuScene; //El número de la escena menu en build
    public int multiplayerScene;

    void Awake () {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            if(Instance != this)
            {
                Destroy(this.gameObject);
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }
	
}
