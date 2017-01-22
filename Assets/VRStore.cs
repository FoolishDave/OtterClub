using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRStore : MonoBehaviour {

    public enum SaleType { WEAPON, BLOCKADE, TRAP, ERR };
    [System.Serializable]
    public struct ShopListing
    {
        public SaleType saleType;
        public GameObject forSale;
        public int salePrice;
    }
    public List<ShopListing> pool;
    public static List<ShopListing> itemPool = new List<ShopListing>();

    public void Awake()
    {
        itemPool = pool;
    }

    public static bool hasStock()
    {
        return itemPool.Count > 0;
    }

    public static ShopListing getNewListing()
    {
        if (itemPool.Count == 0)
        {

        }
        int listingNum = UnityEngine.Random.Range(0, itemPool.Count-1);
        ShopListing listing = itemPool[listingNum];
        itemPool.Remove(listing);
        return listing;
    }
}
