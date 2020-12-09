using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public Text scrollingCreditsText;
    public GameObject ship;
    public float multiplier;
    public float minPosition;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadMainMenu", 89f);
    }

    // Update is called once per frame
    void Update()
    {
        if (scrollingCreditsText.transform.position.y > minPosition)
        {
            scrollingCreditsText.transform.position = new Vector3(0, scrollingCreditsText.transform.position.y - multiplier, 0);
        }
        else
        {
            ship.transform.position = new Vector3(0, ship.transform.position.y + (multiplier * 2f), 0);
        }
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene("Title_Screen");
    }
}
