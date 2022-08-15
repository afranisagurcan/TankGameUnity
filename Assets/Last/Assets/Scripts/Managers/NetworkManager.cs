using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public PhotonView playerPrefab;
    public static NetworkManager instance;
    public global::GameManager gameMan;
    public GameObject m_TankPrefab;
    public CameraControl m_CameraControl;
    public int i = 0;
 
    void Awake()
    {
        
        if(instance != null && instance != this)
            gameObject.SetActive(false);
        else
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        //OnConnectedToMaster();   
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined a room.");
        gameMan.m_Tanks.m_Instance = PhotonNetwork.Instantiate(playerPrefab.name,gameMan.m_Tanks.m_SpawnPoint.position, gameMan.m_Tanks.m_SpawnPoint.rotation);
        gameMan.m_Tanks.m_PlayerNumber = i + 1;
        gameMan.m_Tanks.Setup();
        gameMan.SetCameraTargets(gameMan.m_Tanks);
        i++;
    }
    
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master server.");
        PhotonNetwork.JoinRandomOrCreateRoom();
    }
    
    public void ChangeScene(string sceneName)
    {
        PhotonNetwork.LoadLevel(sceneName);
    }
}
