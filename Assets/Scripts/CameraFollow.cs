using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    public float lerpRate;
    public bool gameOver;

    private void Start()
    {
        offset = player.transform.position - transform.position;
        gameOver = false;
    }
    private void Update()
    {
        if(!gameOver)
        {
            Follow();
        }
    }
    void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 targetPos =player.transform.position - offset;
        pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime);
        transform.position = pos;
    }
}
