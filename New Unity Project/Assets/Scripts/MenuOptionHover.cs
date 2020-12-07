using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuOptionHover : MonoBehaviour
{
    public Vector3 origScale;
    public Text text;
    public string objectToDisappear;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseEnter()
    {
        origScale = GameObject.Find(objectToDisappear).transform.localScale;
        GameObject.Find(objectToDisappear).transform.localScale = new Vector3(0, 0, 0);
        Text startText = text.GetComponent<Text>();
        startText.color = new Color32(0, 168, 1, 255);
    }

    public void OnMouseExit()
    {
        GameObject.Find(objectToDisappear).transform.localScale = origScale;
        Text startText = text.GetComponent<Text>();
        startText.color = Color.black;
    }
}
