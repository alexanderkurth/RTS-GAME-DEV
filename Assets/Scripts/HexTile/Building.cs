using UnityEngine;

public class Building : MonoBehaviour
{
    //================================ Variables

    public static Building ins;

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
