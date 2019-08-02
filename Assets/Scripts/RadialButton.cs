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

    [SerializeField] private static RadialButton ins;

    public bool clicked;
    public int num;

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
        myMenu.SetRadialButton(this);
        defaultColor = circle.color;
        circle.color = Color.white;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        myMenu.SetRadialButton(null);
        circle.color = defaultColor;
    }

    void Update()
    {
    }

        //================================ Getters & Setters


    public static RadialButton GetInstance() { return ins; }
    public Image GetImage() { return circle; }
    public Image GetIcon() { return icon; }
    public string GetTitle() { return title; }
    public void SetTitle(string str) { title = str; }
    public RadialMenu GetRadialMenu() { return myMenu; }
    public void SetRadialMenu(RadialMenu menu) { myMenu = menu; }
}
