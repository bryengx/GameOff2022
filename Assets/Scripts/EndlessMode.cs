using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessMode : MonoBehaviour
{
    public static EndlessMode instance;
    public GameObject[] zoneTemplate;
    void Start()
    {
        instance = this;
    }
    void Update()
    {
        
    }
    public GameObject GetRandomZone()
    {
        return zoneTemplate[Random.Range(0, zoneTemplate.Length)];
    }
}
