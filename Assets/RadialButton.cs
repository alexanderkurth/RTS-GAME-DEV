using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RadialButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //================================ Variables

    [SerializeField] private Image circle;
    [SerializeField] private Image icon;
    [SerializeField] private string title;
    [SerializeField] private RadialMenu myMenu;
    [SerializeField] private float speed = 8f;

    [SerializeField] private Color defaultColor;

    [SerializeField] private bool b;

    [SerializeField] private static RadialButton ins;

    void Awake()
    {
        ins = this;
    }

    public void Anim()
    {
        StartCoroutine(AnimateButtonIn());
    }

    IEnumerator AnimateButtonIn()
    {
        transform.localScale = Vector3.zero;
        float timer = 0f;
        while (timer < (1 / speed))
        {
            timer += Time.deltaTime;
            transform.localScale = Vector3.one * timer * speed;
            yield return null;
        }
        transform.localScale = Vector3.one;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        myMenu.selected = this;
        defaultColor = circle.color;
        circle.color = Color.white;
        b = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        myMenu.selected = null;
        circle.color = defaultColor;
        b = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            OnMouseDownzd();
    }

    void OnMouseDownzd()
    {
        ButtonHandler.ins.CreateBuilding();
    }

    public static RadialButton GetInstance() { return ins; }
    public bool GetB() { return b; }
    public Image GetImage() { return circle; }
    public Image GetIcon() { return icon; }
    public string GetTitle() { return title; }
    public void SetTitle(string str) { title = str; }
    public RadialMenu GetRadialMenu() { return myMenu; }
    public void SetRadialMenu(RadialMenu menu) { myMenu = menu; }
}
