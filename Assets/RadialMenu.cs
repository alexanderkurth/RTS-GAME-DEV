using UnityEngine;

public class RadialMenu : MonoBehaviour
{
    public RadialButton buttonPrefab;   //button to instantiate
    public RadialButton selected;       //button that is selected (leave this empty)

    void Start()
    {
        RadialButton newButton = Instantiate(buttonPrefab) as RadialButton;
        newButton.transform.SetParent(transform, false);
        newButton.transform.localPosition = new Vector3(0, 100, 0f);

    }
}