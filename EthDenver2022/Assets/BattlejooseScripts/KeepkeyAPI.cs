using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Net;
using Photon.Pun;

public class KeepkeyAPI : MonoBehaviour
{
    // public RawImage keepRawImage;
    public Text keepAddressText;
    //public Text keepNumText, keepPicURL;
    // public InputField inputField;

    public MyUserInfo userInfo;




    // Start is called before the first frame update
    void Start()
    {
       

        keepAddressText.text = "";
        //keepNumText.text = "";
    }

    public void KeepkeyButtonPress()
    {
        keepAddressText.text = "really Loading...";

        


        Keeper myKeepkey = GetKeepkey();

        Debug.Log(myKeepkey.accounts[0].pubkey);

        keepAddressText.text = myKeepkey.accounts[0].pubkey;

        //put the address in the user info object

        userInfo.SetAddress(myKeepkey.accounts[0].pubkey);

        PhotonNetwork.NickName = myKeepkey.accounts[0].pubkey;

        Debug.Log("my nickname is: " + PhotonNetwork.NickName);


        //keepNumText.text = myKeepkey.weight.ToString();

        //keepPicURL.text = myKeepkey.sprites.front_default;

        //StartCoroutine(GetTexture(myKeepkey.sprites.front_default));





    }

   

    public Keeper GetKeepkey()
    {
        Debug.Log("Im in Get keepkey!");
        string keepkeyURL = "http://localhost:1646/user";


        HttpWebRequest pokeInfoRequest = (HttpWebRequest)WebRequest.Create(keepkeyURL);
        HttpWebResponse response = (HttpWebResponse)pokeInfoRequest.GetResponse();

        StreamReader reader = new StreamReader(response.GetResponseStream());

        string json = reader.ReadToEnd();

        Debug.Log(json);
        

        return JsonUtility.FromJson<Keeper>(json);


    }


}
