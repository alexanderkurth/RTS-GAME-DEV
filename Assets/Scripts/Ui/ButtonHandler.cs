using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    //================================ Variables

    public InputManager inputManager;
    public GameObject button;

    public static ButtonHandler ins;

    //================================ Methods

    void Start()
    {
        ins = this;
    }

    void Update()
    {
        if (inputManager.GetHexTileManager())
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
