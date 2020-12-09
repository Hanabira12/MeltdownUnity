using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoodEnding : MonoBehaviour
{
    public AudioSource adSource;
    public AudioClip[] adClips;
    public GameObject ship;
    public float multiplier;
    public float maxSize;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(playAudioSequentially());
        Invoke("makeStationInvisible", 0.1f);
        Invoke("LoadCredits", 3.0f);


    }

    // Update is called once per frame
    void Update()
    {
        if (ship.transform.localScale.x < maxSize)
        {
            ship.transform.localScale = new Vector3(ship.transform.localScale.x + multiplier, ship.transform.localScale.y + multiplier, ship.transform.localScale.z + multiplier);
        }

        ship.transform.position = new Vector3(0, ship.transform.position.y + multiplier, 0);
    }

    void makeStationInvisible()
    {
        GameObject.Find("SpaceStation").transform.localScale = new Vector3(0, 0, 0);
    }

    void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    IEnumerator playAudioSequentially()
    {
        yield return null;

        adSource.clip = adClips[0];
        adSource.Play();
        while (adSource.isPlaying)
        {
            yield return null;
        }

        adSource.clip = adClips[1];
        adSource.Play();
        while (adSource.isPlaying)
        {
            yield return null;
        }
    }
}
