using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkPlayer : MonoBehaviour
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

        head = GameObject.Find("/MyRig/PlayerController/CameraRig/TrackingSpace/CenterEyeAnchor/IKEyeTarget").transform;
        leftHand = GameObject.Find("/MyRig/PlayerController/CameraRig/TrackingSpace/LeftHandAnchor/LeftControllerAnchor/LeftController/IKLeftHandTarget/LeftOffset").transform;
        rightHand = GameObject.Find("/MyRig/PlayerController/CameraRig/TrackingSpace/RightHandAnchor/RightControllerAnchor/RightController/IKRightHandTarget/RightOffset").transform;
        overall = GameObject.Find("/MyRig/PlayerController/CameraRig/TrackingSpace/TrackerAnchor").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //rightHand.gameObject.SetActive(false);
        //leftHand.gameObject.SetActive(false);
        //head.gameObject.SetActive(false);

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
