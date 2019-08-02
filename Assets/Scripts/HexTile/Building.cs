﻿using UnityEngine;

public class Building : MonoBehaviour
{
    //================================ Variables

    public static Building ins;

    [SerializeField] protected bool inUse;



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
