using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabelManager : MonoBehaviour
{
    public Text text;
    public UiInfoManager uiInfoManager;

    private void Start()
    {
        if (uiInfoManager.labels[gameObject.name] != null)
        {
            text.text = uiInfoManager.labels[gameObject.name];
        }
    }
}
