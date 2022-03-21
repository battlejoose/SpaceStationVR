using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PokemonAPI : MonoBehaviour
{
    public RawImage pokeRawImage;
    public Text pokeNameText;
    public Text pokeNumText;
    public Text pokePicURL;

    public InputField inputField;
    

    // Start is called before the first frame update
    void Start()
    {
        pokeRawImage.texture = Texture2D.blackTexture;

        pokeNameText.text = "";
        pokeNumText.text = "";


    }
    
    public void PokeButtonPress()
    {
        pokeNameText.text = "really Loading...";

        pokeNumText.text = "#";

        Pokemon myPokemon = GetPokemon();

        pokeNameText.text = myPokemon.name;

        pokeNumText.text = myPokemon.weight.ToString();

        pokePicURL.text = myPokemon.sprites.front_default;

        StartCoroutine(GetTexture(myPokemon.sprites.front_default));





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
            pokeRawImage.texture = myTexture;
        }
    }

    public Pokemon GetPokemon()
    {
        Debug.Log("Im in here not enumerating!!!");
        string pokemonURL = "https://pokeapi.co/api/v2/pokemon/" + inputField.text;


        HttpWebRequest pokeInfoRequest = (HttpWebRequest)WebRequest.Create(pokemonURL);
        HttpWebResponse response = (HttpWebResponse)pokeInfoRequest.GetResponse();

        StreamReader reader = new StreamReader(response.GetResponseStream());

        string json = reader.ReadToEnd();

        return JsonUtility.FromJson<Pokemon>(json);


    }

    
}
