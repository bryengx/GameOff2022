using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessMode : MonoBehaviour
{
    public static EndlessMode instance;
    public GameObject[] zoneTemplate;
    public GameObject[] bossZones;
    public GameObject[] props;
    public GameObject bird;
    private int birdCounter;
    private float nextBoss;
    private float len;
    void Start()
    {
        instance = this;
        birdCounter = 2;
        nextBoss = 200;
    }
    void Update()
    {

    }
    public GameObject GetRandomBackObj()
    {
        return props[Random.Range(0, props.Length)];
    }
    public GameObject GetRandomZone()
    {
        if(len > nextBoss)
        {
            nextBoss += 300;
            return bossZones[Random.Range(0, bossZones.Length)];
        }
        else
            return zoneTemplate[Random.Range(0, zoneTemplate.Length)];
    }
    public void ExtraContent(Vector3 pos)
    {
        len = pos.x;
        birdCounter++;
        if(birdCounter > 3)
        {
            Vector3 birdPos = new Vector3(pos.x, 10, pos.z);
            GameObject newBird = Instantiate(bird, birdPos, Quaternion.Euler(0, 0, 0));
            birdCounter = 0;
        }
    }
}
