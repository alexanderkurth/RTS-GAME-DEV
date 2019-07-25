using UnityEngine;

public class UiInfoManager : MonoBehaviour
{
    //================================ Variables

    private string infoText;
    [SerializeField] HexTileManager hextileManager;

    public InputManager inputManager;

    //================================ Methods

    void Update()
    {
        hextileManager = inputManager.GetHexTileManager();

        if (inputManager.GetHexTileManager() != null)
        {
            GetInformations();
        }
    }

    void GetInformations()//check hextile manager from InputManager
    {
            string hextileName;
            string coordinates;
            string emptyness;

            hextileName = hextileManager.GetHexTile().GetHexTileName();
            coordinates = hextileManager.GetHexTile().GetCoordinates().ToString();
            emptyness = hextileManager.GetHexTile().IsEmpty().ToString();
            infoText = hextileName + "\n" + coordinates + "\n" + emptyness;
        
    }

    //================================ Getters & Setters
    public string GetInfoText() { return this.infoText; }

}