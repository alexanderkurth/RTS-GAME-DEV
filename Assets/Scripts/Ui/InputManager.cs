using UnityEngine;

public class InputManager : MonoBehaviour
{
    //================================ Variables

    [SerializeField] private HexTile selectedHextile;
    [SerializeField] private HexTileManager hexTileManager;
    [SerializeField] private bool blockSelection;

    //================================ Methods

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && blockSelection==false)
        {
            HextileManagement();
        }
        if (RadialButton.GetInstance() != null)
            blockSelection = RadialButton.GetInstance().GetB();
    }

    private void HextileManagement()
    {
        if (GetHexTileClicked())
        {
            hexTileManager = GetHexTileClicked().transform.gameObject.GetComponent<HexTileManager>();

            if (!hexTileManager.IsSelected() && selectedHextile == null)
            {
                selectedHextile = GetHexTileClicked();
                selectedHextile.SetSelected(true);

                RadialMenuSpawner.ins.SpawnMenu(selectedHextile.GetComponent<Interactable>());

            }
            else if (selectedHextile == GetHexTileClicked())
            {
                selectedHextile.SetSelected(false);
                selectedHextile = null;
                hexTileManager = null;

                RadialMenu.ins.Destroy();
            }
            else if (!hexTileManager.IsSelected() && selectedHextile != null)
            {
                selectedHextile.SetSelected(false);
                selectedHextile.gameObject.GetComponent<HexTileManager>().SetMaterialColor(Color.white);

                selectedHextile = GetHexTileClicked();
                selectedHextile.SetSelected(true);
                RadialMenu.ins.Destroy();

                RadialMenuSpawner.ins.SpawnMenu(selectedHextile.GetComponent<Interactable>());

            }
        }
    }


    public HexTile GetHexTileClicked()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
            return hit.transform.gameObject.GetComponent<HexTile>();
        else
            return null;
    }

    public Building GetBuildingClicked()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
            return hit.transform.gameObject.GetComponent<HexTile>().GetBuilding();
        else
            return null;
    }

    //================================ Getters & Setters

    public void SetSelectedHextile(HexTile hextile) { this.selectedHextile = hextile; }

    public HexTileManager GetHexTileManager() { return this.hexTileManager; }
}
