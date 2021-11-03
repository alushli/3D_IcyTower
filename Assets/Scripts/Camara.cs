using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed = 0.05f, speedToAdd = 0.02f;
    private float camaraBaffer = 15f, timeBuffer = 11f;
    public bool isGameStop = false;
    public float leftTime = 10f;

    // Update is called once per frame
    // when the player height bigger then camaraBuffer,
    // the camera start to move up every timeBuffer sec and change her speed
    void Update()
    {
        if((player.transform.position.y >= camaraBaffer) && !isGameStop)
        {
            if (leftTime < 0)
            {
               speed += speedToAdd;
               leftTime = timeBuffer;
            }
            leftTime -= Time.deltaTime;
            transform.position += Vector3.up * speed;
        }
    }
}
