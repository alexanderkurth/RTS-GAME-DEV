using UnityEngine;

public class Building : MonoBehaviour
{
    //================================ Variables

    public static Building ins;

    private bool inUse;
    private int production;
    private int workers;
    private Resource resourceCrafted;
    private Resource resourceNeeded;

    //================================ Methods

    void Awake()
    {
        ins = this;
    }

    public void DestroyBuilding()
    {
        Destroy(gameObject);
    }

    //================================ Getters & Setters







}
