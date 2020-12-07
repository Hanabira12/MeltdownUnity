using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasAnchor : MonoBehaviour
{
    private Vector2 velocity;
    public bool bounds;
    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
                Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
                Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
        }
    }
}
