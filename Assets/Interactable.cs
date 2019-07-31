﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [System.Serializable]
    public class Action
    {
        public Color color;
        public Sprite sprite;
        public string title;
    }

    public string title;


    public Action[] options;

    void Start()
    {
        if (title == "" || title == null)
        {
            title = gameObject.name;
        }
    }

    void OnMouseDown()
    {
     //   RadialMenuSpawner.ins.SpawnMenu(this);
    }

}
