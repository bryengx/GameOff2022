using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoTouchGrass : MonoBehaviour
{
    // Start is called before the first frame update
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
        if (pl && pl.isOk)
        {
            pl.Loose();
        }
    }
}
