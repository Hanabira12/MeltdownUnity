using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject[] panels;
    public float multiplier;
    public float maxHeight;
    public float minHeight;
    public float startHeight0;
    public float startHeight1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (panels[0].transform.position.y < maxHeight)
        {
            panels[0].transform.position = new Vector3(0, panels[0].transform.position.y + multiplier, 0);
        }
        else 
        {
            panels[0].transform.position = new Vector3(0, startHeight0, 0);
        }

        if (panels[1].transform.position.y > minHeight)
        {
            panels[1].transform.position = new Vector3(0, panels[1].transform.position.y - multiplier, 0);
        }
        else
        {
            panels[1].transform.position = new Vector3(0, startHeight1, 0);
        }
    }
}
