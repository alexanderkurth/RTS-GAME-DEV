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

    void Update()
    {

    }
    public void CreateBuilding()
    {
        if (inputManager.GetHexTileManager() != null)
            inputManager.GetHexTileManager().Build();
    }
}
