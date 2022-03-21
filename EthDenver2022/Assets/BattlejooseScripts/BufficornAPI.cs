using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class BufficornAPI : MonoBehaviour
{
    public MyUserInfo myUserInfo;

    public RawImage buffRawImage;
    public Text buffNameText;
    public Text buffNumText;
    public Text buffPicURL;

    public Text trait0;
    public Text value0;
    public Text trait1;
    public Text value1;
   


    public InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        buffRawImage.texture = Texture2D.blackTexture;

        buffNameText.text = "";
        buffNumText.text = "";

    }

    public void BuffButtonPress()
    {
        buffNameText.text = "really Loading...";

        buffNumText.text = "#";

        Bufficorn myBufficorn = GetBufficorn();

        Debug.Log(myBufficorn.ToString());

        Debug.Log("contract address: " + myBufficorn.nfts[0].contractAddress);

        buffNameText.text = myBufficorn.nfts[0].contractAddress;

        buffNumText.text = myBufficorn.nfts[0].tokenID.ToString();

        buffPicURL.text = myBufficorn.nfts[0].imageUrl;

        trait0.text = myBufficorn.nfts[0].traits[0].trait_type;
        value0.text = myBufficorn.nfts[0].traits[0].value;

        trait1.text = myBufficorn.nfts[0].traits[1].trait_type;
        value1.text = myBufficorn.nfts[0].traits[1].value;


        StartCoroutine(GetTexture(myBufficorn.nfts[0].imageUrl));



    }

    IEnumerator GetTexture(string myURL)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(myURL);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            buffRawImage.texture = myTexture;
        }
    }
    public Bufficorn GetBufficorn()
    {
        Debug.Log("Im in here not enumerating!!!");
        string pokemonURL = "https://pioneers.dev/api/v1/nft/" + myUserInfo.address;

        Debug.Log("nft url: " + pokemonURL);

        HttpWebRequest pokeInfoRequest = (HttpWebRequest)WebRequest.Create(pokemonURL);
        HttpWebResponse response = (HttpWebResponse)pokeInfoRequest.GetResponse();

        StreamReader reader = new StreamReader(response.GetResponseStream());

        string json = reader.ReadToEnd();

        Debug.Log("Original JSON OBJECT.... as a string!!!! " + json);


        return JsonUtility.FromJson<Bufficorn>(json);


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
