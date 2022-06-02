using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class NetworkLauncher : MonoBehaviourPunCallbacks
{
    //public GameObject nameUI;
    //public InputField roomName;
    //public InputField PlayerName;

    
    
    //public GameObject playerName;

    public void Start(){
        PhotonNetwork.ConnectUsingSettings();
    }

    public void Update(){
        //string textValue = gameObject.GetCompenenet<InputField>().text;
    }

    public override void OnConnectedToMaster(){
        //nameUI.SetActive(true);

        base.OnConnectedToMaster();
        Debug.Log("www");

        PhotonNetwork.JoinOrCreateRoom("Room", new Photon.Realtime.RoomOptions() { MaxPlayers = 4}, default);
    }

    public override void OnJoinedRoom(){
        base.OnJoinedRoom();
        PhotonNetwork.Instantiate("Player", new Vector3(1,1,0), Quaternion.identity, 0);
    }

    //public void PlayButton(){
        //PhotonNetwork.NickName = PlayerName.text;
    //}

}
