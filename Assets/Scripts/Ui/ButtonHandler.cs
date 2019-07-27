using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    //================================ Variables

    public InputManager inputManager;
    public GameObject button;

    //================================ Methods

    void Update()
    {
        if (inputManager.GetHexTileManager() )
            button.gameObject.SetActive(true);
        else
            button.gameObject.SetActive(false);
    }
    public void CreateBuilding()
    {
        if (inputManager.GetHexTileManager() != null)
            inputManager.GetHexTileManager().Build();
    }
}
