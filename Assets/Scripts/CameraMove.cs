using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private GameObject player;
    void Awake()
    {
        player = FindObjectOfType<Player>().gameObject;
    }
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + 10, transform.position.y, transform.position.z);
    }
}
