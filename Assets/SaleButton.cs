using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaleButton : MonoBehaviour {

    private VRStore.ShopListing listing;
    public SteamVR_TrackedController rightCont;
    public SteamVR_TrackedController leftCont;

    void Start()
    {
        listing = VRStore.getNewListing();
        UpdateText(listing);
    }

    public void OnPress()
    {
        if (PlayerMoney.hasMoney(listing.salePrice))
        {
            PlayerMoney.takeMoney(listing.salePrice);
            switch (listing.saleType)
            {
                case VRStore.SaleType.WEAPON:
                    GameObject newWep = Instantiate<GameObject>(listing.forSale);
                    newWep.transform.SetParent(rightCont.transform);
                    rightCont.GetComponent<WeaponSwap>().weapons.Add(newWep);
                    break;
                case VRStore.SaleType.BLOCKADE:
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
