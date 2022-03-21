using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Trying to connect to the server");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnConnectedToMaster()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if(sceneName == "MoonTest") 
        {
            PhotonNetwork.JoinRandomOrCreateRoom();
        }

        if (sceneName == "PlanetRoom")
        {
            PhotonNetwork.JoinRandomOrCreateRoom();
        }

    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined a room!!!");
        base.OnJoinedRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("A new Player joined!!!");
        base.OnPlayerEnteredRoom(newPlayer);
    }

    public void ConnectButton()
    {
        PhotonNetwork.JoinRandomOrCreateRoom();
    }
   
}
