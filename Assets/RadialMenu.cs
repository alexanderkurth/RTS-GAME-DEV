using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RadialMenu : MonoBehaviour
{
    //================================ Variables

    public Text label;                  
    public RadialButton buttonPrefab;   
    public RadialButton selected;
    public static RadialMenu ins;

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
            newButton.SetRadialMenu(this);
            newButton.Anim();
            yield return new WaitForSeconds(0.1f);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (selected)
            {
                Debug.Log(selected.GetTitle() + " was selected!");
            }
            //Destroy(gameObject);
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
    

}