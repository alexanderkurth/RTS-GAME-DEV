using UnityEngine;

public class UiInfoManager : MonoBehaviour
{
    //================================ Variables

    public HexTile selectedHextile;

    public HexTileManager hextileManager;

    private string infoText;

    public InputManager inputManager;

    //================================ Methods

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ClickOnTile();
        }
    }

    void ClickOnTile()//[TODO] Refactor -- class Input manager + HextileManager + UiManager 
    {

        hextileManager = inputManager.GetHexTileClicked().transform.gameObject.GetComponent<HexTileManager>();
        string hextileName;
        string coordinates;
        string emptyness;

        hextileName = hextileManager.GetHexTile().GetHexTileName();
        coordinates = hextileManager.GetHexTile().GetCoordinates().ToString();
        emptyness = hextileManager.GetHexTile().IsEmpty().ToString();
        infoText = hextileName + "\n" + coordinates + "\n" + emptyness;

        if (!hextileManager.IsSelected() && selectedHextile == null)
        {
            selectedHextile = inputManager.GetHexTileClicked();
            selectedHextile.SetSelected(true);
            hextileManager.SetMaterialColor(Color.red);

        }
        else if (selectedHextile == inputManager.GetHexTileClicked())
        {
            selectedHextile.SetSelected(false);
            selectedHextile = null;
            hextileManager.SetMaterialColor(Color.white);
        }
        else if (!hextileManager.IsSelected() && selectedHextile != null)
        {
            selectedHextile.SetSelected(false);
            selectedHextile.gameObject.GetComponent<HexTileManager>().SetMaterialColor(Color.white);

            selectedHextile = inputManager.GetHexTileClicked();
            selectedHextile.SetSelected(true);
            hextileManager.SetMaterialColor(Color.red);
        }

    }

    //================================ Getters & Setters
    public string GetInfoText() { return this.infoText; }

}