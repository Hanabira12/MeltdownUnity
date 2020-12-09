using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpaceStationExploding : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("makeStationInvisible", 0.1f);
        Invoke("LoadGameOver", 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void makeStationInvisible()
    {
        GameObject.Find("SpaceStation").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("Ship1").transform.localScale = new Vector3(0, 0, 0);
    }

    void LoadGameOver()
    {
        SceneManager.LoadScene("Lose");
    }
}
