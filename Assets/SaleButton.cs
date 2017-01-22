using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaleButton : MonoBehaviour {

    private VRStore.ShopListing listing;
    public SteamVR_TrackedController rightCont;
    public SteamVR_TrackedController leftCont;
    GameObject wallSpawner;

    void Start()
    {
        listing = VRStore.getNewListing();
        wallSpawner = GameObject.FindGameObjectWithTag("WallSpawn");
        UpdateText(listing);
    }

    public void OnPress()
    {
        if (VrGoldManager.hasMoney(listing.salePrice))
        {
            VrGoldManager.takeMoney(listing.salePrice);
            switch (listing.saleType)
            {
                case VRStore.SaleType.WEAPON:
                    GameObject newWep = Instantiate<GameObject>(listing.forSale,rightCont.transform,false);
                    rightCont.GetComponent<WeaponSwap>().weapons.Add(newWep);
                    break;
                case VRStore.SaleType.BLOCKADE:
                    GameObject newBlock = Instantiate<GameObject>(listing.forSale);
                    newBlock.transform.position = wallSpawner.transform.position;
                    break;
                case VRStore.SaleType.TRAP:
                    break;
                default:
                    break;
            }
            if (VRStore.hasStock())
            {
                listing = VRStore.getNewListing();
                UpdateText(listing);
            }
            else
                Destroy(this.gameObject);
        }
    }

    void UpdateText(VRStore.ShopListing listing)
    {
        GetComponentInChildren<Text>().text = listing.forSale.name + "\n" + listing.salePrice.ToString();
    }
}
