[System.Serializable]
public class Bufficorn
{
    public Nft[] nfts;
  
}

[System.Serializable]
public class Nft
{
    public string contractAddress;
    public int tokenID;
    public string imageUrl;
    public Trait[] traits;
}

[System.Serializable]
public class Trait
{
    public string trait_type;
    public string value;
}
