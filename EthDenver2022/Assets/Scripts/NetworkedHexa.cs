using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkedHexa : MonoBehaviour
{
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;
    public Transform overall;

    private PhotonView photonView;

    public Transform modelHead;
    public Transform modelLeft;
    public Transform modelRight;
    public Transform modelOverall;


    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();

        head = GameObject.Find("/HexaRig/HexaBody/Pelvis/CameraRig/FloorOffset/Scaler/Camera/HeadOffset").transform;
        leftHand = GameObject.Find("/HexaRig/Left/LeftOffset").transform;
        rightHand = GameObject.Find("/HexaRig/Right/RightOffset").transform;
        overall = GameObject.Find("/HexaRig/HexaBody/Knee/Fender/FenderOffset").transform;
    }

    // Update is called once per frame
    void Update()
    {
       

        if (photonView.IsMine)
        {
            MapFull(modelHead, head);
            MapFull(modelLeft, leftHand);
            MapFull(modelRight, rightHand);

            MapPosition(modelOverall, overall);



        }

    }

    void MapFull(Transform target, Transform rigTransform)
    {


        target.position = rigTransform.position;
        target.rotation = rigTransform.rotation;
    }

    void MapPosition(Transform target, Transform rigTransform)
    {


        target.position = rigTransform.position;

    }


}
