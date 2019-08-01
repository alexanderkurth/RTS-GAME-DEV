using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [System.Serializable]
    public class Action
    {
        [SerializeField] private Color color;
        [SerializeField] private Sprite sprite;
        [SerializeField] private string title;

        public Color GetColor() { return color; }
        public Sprite GetSprite() { return sprite; }
        public string GetTitle() { return title; }
    }

    //================================ Variables

    [SerializeField] private string title;


    [SerializeField] private Action[] options;

    void Start()
    {
        if (title == "" || title == null)
        {
            title = gameObject.name;
        }
    }

    //================================ Getters & Setters

    public Action[] GetOptions() { return options; }


}
