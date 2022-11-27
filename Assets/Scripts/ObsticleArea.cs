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
            EndlessMode.instance.ExtraContent(zoneObj.transform.position);

            float x = zone.left.position.x + Random.Range(1.25f, 5.5f);
            while (x < zone.right.position.x)
            {
                float y = Random.Range(2.0f, 4.2f);
                GameObject backObj = Instantiate(EndlessMode.instance.GetRandomBackObj());
                backObj.transform.position = new Vector3(x, y, y / 10f);

                x += Random.Range(1.25f, 3.5f);
                if (y < 3)
                    backObj.transform.localScale *= Random.Range(1.4f, 1.6f);
                else if (x < 4)
                    backObj.transform.localScale *= Random.Range(1.2f, 1.35f);
            }

            triggered = true;
        }            
    }
}
