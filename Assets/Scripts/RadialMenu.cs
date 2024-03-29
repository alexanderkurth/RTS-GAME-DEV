﻿using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class RadialMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //================================ Variables

    [SerializeField] private Text label;
    [SerializeField] private RadialButton buttonPrefab;
    [SerializeField] private RadialButton selected;
    [SerializeField] private static RadialMenu ins;

    [SerializeField] private bool mouseHoover;

    //================================ Methods

    void Awake()
    {
        ins = this;
    }

    public void SpawnButtons(Interactable obj)
    {
        StartCoroutine(AnimateButtons(obj));
    }

    IEnumerator AnimateButtons(Interactable obj)
    {
        for (int i = 0; i < obj.GetOptions().Length; i++)
        {
            RadialButton newButton = Instantiate(buttonPrefab) as RadialButton;
            newButton.transform.SetParent(transform, false);
            float theta = (2 * Mathf.PI / obj.GetOptions().Length) * i;
            float xPos = Mathf.Sin(theta);
            float yPos = Mathf.Cos(theta);
            newButton.transform.localPosition = new Vector3(xPos, yPos, 0f) * 100f;
            newButton.GetImage().color = obj.GetOptions()[i].GetColor();
            newButton.GetIcon().sprite = obj.GetOptions()[i].GetSprite();
            newButton.SetTitle(obj.GetOptions()[i].GetTitle());
            newButton.num = i;
            newButton.SetRadialMenu(this);
            newButton.Anim();
            yield return new WaitForSeconds(0.1f);
        }
    }

    //[TODO] Refactor
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (selected)
            {
                if (selected.num == 1)
                    ButtonHandler.GetInstance().DestroyBuilding();

                Debug.Log(selected.GetTitle() + " was selected!");


                if (selected.num == 0 && !BuildingHandler.ins.isSimpleBuildingMaxCountReached)
                    ButtonHandler.GetInstance().CreateBuilding(BuildingHandler.ins.GetSimpleBuilding());


                if (selected.num == 2 && !BuildingHandler.ins.isMineMaxCountReached)
                    ButtonHandler.GetInstance().CreateBuilding(BuildingHandler.ins.GetMine());

                if (selected.num == 3 && !BuildingHandler.ins.isStockpileMaxCountReached)
                    ButtonHandler.GetInstance().CreateBuilding(BuildingHandler.ins.GetStockPile());
            }

        }

    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseHoover = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseHoover = false;
    }

    //================================ Getters & Setters

    public bool isMouseHoovering() { return mouseHoover; }

    public RadialButton GetSelected() { return selected; }
    public void SetRadialButton(RadialButton button) { selected = button; }
    public static RadialMenu GetInstance() { return ins; }

}