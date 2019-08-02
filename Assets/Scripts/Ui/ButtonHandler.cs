using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    //================================ Variables

    [SerializeField] private InputManager inputManager;

    public static ButtonHandler ins;

    //================================ Methods

    void Awake()
    {
        ins = this;
    }

    public void CreateBuilding()
    {
        if (inputManager.GetHexTileManager() != null)
            inputManager.GetHexTileManager().Build();
    }

    public void DestroyBuilding()
    {
        if (inputManager.GetHexTileManager() != null)
           inputManager.GetHexTileManager().GetHexTile().GetBuilding().DestroyBuilding();
    }
}
