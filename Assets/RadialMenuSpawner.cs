using UnityEngine;

public class RadialMenuSpawner : MonoBehaviour
{

    public static RadialMenuSpawner ins;
    public RadialMenu menuPrefab;           //prefab menu to instantiate

    void Awake()
    {
        ins = this;
    }

    //instantiates the menu at the position of the mouse
    public void SpawnMenu(Interactable obj)
    {
        RadialMenu newMenu = Instantiate(menuPrefab) as RadialMenu;
        newMenu.transform.SetParent(transform, false);
        newMenu.transform.position = Input.mousePosition;
    }

}