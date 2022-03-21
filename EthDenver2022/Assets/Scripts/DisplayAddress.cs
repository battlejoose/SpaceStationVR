using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class DisplayAddress : MonoBehaviour
{
    public PhotonView photonView;
    public Text addressText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        addressText.text = photonView.Owner.NickName;
    }
}
