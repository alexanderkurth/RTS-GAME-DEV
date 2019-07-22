using System.Collections;
using System.Collections.Generic;
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
        infoText.text = uiInfoManager.GetInfoText();
    }
}
