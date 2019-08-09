using UnityEngine;

public class InputManager : MonoBehaviour
{
    //================================ Variables

    [Header("Selection Management")]
    [SerializeField] private HexTile selectedHextile;
    [SerializeField] private HexTileManager hexTileManager;
    [SerializeField] private bool blockSelection;

    [SerializeField] private RadialMenu menuPrefab;


    //================================ Methods

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HextileManagement();
        }

        if (RadialMenu.GetInstance() != null)
            blockSelection = RadialMenu.GetInstance().isMouseHoovering();

    }

    private void HextileManagement()
    {
        if (GetHexTileClicked())
        {
            if (blockSelection == false)
                hexTileManager = GetHexTileClicked().transform.gameObject.GetComponent<HexTileManager>();

            if (!hexTileManager.IsSelected() && selectedHextile == null )
            {
                selectedHextile = GetHexTileClicked();
                selectedHextile.SetSelected(true);

                SpawnMenu(selectedHextile.GetComponent<Interactable>());

            }
            else if (selectedHextile == GetHexTileClicked() )
            {
                selectedHextile.SetSelected(false);
                selectedHextile = null;
                hexTileManager = null;

                RadialMenu.GetInstance().Destroy();

            }
            else if (!hexTileManager.IsSelected() && selectedHextile != null)
            {
                selectedHextile.SetSelected(false);
               // selectedHextile.gameObject.GetComponent<HexTileManager>().SetMaterialColor(Color.white);

                selectedHextile = GetHexTileClicked();
                selectedHextile.SetSelected(true);
                RadialMenu.GetInstance().Destroy();

                SpawnMenu(selectedHextile.GetComponent<Interactable>());

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

    public void SpawnMenu(Interactable obj)
    {
        RadialMenu newMenu = Instantiate(menuPrefab) as RadialMenu;
        newMenu.transform.SetParent(transform, false);
        newMenu.transform.position = Input.mousePosition;
        newMenu.SpawnButtons(obj);
    }

    //================================ Getters & Setters

    public void SetSelectedHextile(HexTile hextile) { this.selectedHextile = hextile; }

    public HexTileManager GetHexTileManager() { return this.hexTileManager; }
}
