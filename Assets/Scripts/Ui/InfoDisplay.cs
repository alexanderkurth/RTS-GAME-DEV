using UnityEngine;
using UnityEngine.UI;

public class InfoDisplay : MonoBehaviour
{
    //================================ Variables

    public Text infoText;

    public UiInfoManager uiInfoManager;

    //================================ Methods

    void Update()
    {

        if (gameObject.name == "Hextile_Information")
            infoText.text = uiInfoManager.GetInfoText();

        if (gameObject.name == "Mine_Number")
            infoText.text = uiInfoManager.GetMineNumber().ToString();

        if (gameObject.name == "StockPile_Number")
            infoText.text = uiInfoManager.GetStockPileNumber().ToString();

        if (gameObject.name == "Building_Number")
            infoText.text = uiInfoManager.GetBuildingNumber().ToString();

        if (gameObject.name == "Resource_stocked")
            infoText.text = ResourceHandler.ins.quantite.ToString();
    }



}
