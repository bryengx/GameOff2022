using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obsticle : MonoBehaviour
{
    public bool failOnCollision;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player pl = collision.gameObject.GetComponent<Player>();
        if(pl && failOnCollision)
        {
            pl.GetComponent<Rigidbody2D>().simulated = true;
            pl.Loose();
            pl.DeattachInteractable();
        }
    }
}
