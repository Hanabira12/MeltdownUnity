using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    private Vector2 velocity;
    public bool bounds;
    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;
    public float smoothTimeY;
    public float smoothTimeX;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void LateUpdate()
    {
        //float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        //float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

        //transform.position = new Vector3(posX, posY, transform.position.z);

        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2, transform.position.z);

        if (bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
                Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
                Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z) );
        }

    }
    //private void LateUpdate()
    //{
    //    transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2, transform.position.z);
    //}
}
