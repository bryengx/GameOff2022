using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObsticleArea : MonoBehaviour
{
    public Transform left;
    public Transform right;
    public GameObject newZone;
    private bool triggered = false;
    void Awake()
    {
        triggered = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        Player pl = collision.gameObject.GetComponent<Player>();
        if ((ball && ball.HasPlayer()) || (pl && !triggered))
        {
            ObsticleArea lastZone = FindObjectsOfType<ObsticleArea>().OrderBy(x => x.transform.position.x).LastOrDefault();
            GameObject zoneObj = Instantiate(EndlessMode.instance.GetRandomZone());
            ObsticleArea zone = zoneObj.GetComponentInChildren<ObsticleArea>();
            zoneObj.transform.position = new Vector3(lastZone.right.position.x + (zone.transform.position.x - zone.left.position.x), lastZone.transform.position.y, 0);
            triggered = true;
        }            
    }
}
