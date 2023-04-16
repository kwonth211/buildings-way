using UnityEngine;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class AuctionListManager : MonoBehaviour
{
    public GameObject auctionItemPrefab;
    public TextAsset jsonFile; // JSON 파일을 불러오기 위한 변수

    private void Start()
    {
        LoadAuctions();
    }

    public void LoadAuctions()
    {
        List<AuctionBuilding> auctions = GetAuctions();

        foreach (AuctionBuilding auction in auctions)
        {
            GameObject auctionItemInstance = Instantiate(auctionItemPrefab, transform);
            AuctionItem auctionItem = auctionItemInstance.GetComponent<AuctionItem>();
            auctionItem.SetAuctionData(auction);
        }
    }

    private List<AuctionBuilding> GetAuctions()
    {
        string jsonString = jsonFile.text;

        List<AuctionBuilding> auctions = JsonConvert.DeserializeObject<List<AuctionBuilding>>(jsonString);

        return auctions;
    }
}
