using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool facingRight = true;
    private Animator anim;
    private bool dead = false;

    public float flightHeight = 5f;
    public float upForce = 5f;
    public GameObject rag;
    public AudioClip popSound;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //flightHeight = transform.position.y;
        Flip();
    }
    void FixedUpdate()
    {
        if (transform.position.y < flightHeight)
        {
            anim.Play("Flap");
            rb.AddForce(Vector3.up * upForce);
        };


        if ((rb.velocity.x < 0f) && (facingRight))
            Flip();
        if ((rb.velocity.x > 0f) && !(facingRight))
            Flip();

        if (rb.velocity.magnitude > 2f)
            rb.velocity = rb.velocity * 0.98f;


        if (Mathf.Abs(rb.velocity.x) < 1f)
        {
            if (facingRight)
                rb.AddForce(Vector3.right * 1f);
            if (!facingRight)
                rb.AddForce(Vector3.right * -1f);

        }
    }
    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    foreach (var cnt in collision.contacts)
    //    {
    //        Collider2D c = cnt.collider;
    //        if (c.gameObject.CompareTag("MapData") && c.gameObject != gameObject && Mathf.Abs(rb.velocity.x) < 0.1f)
    //        {
    //            Flip();
    //        }
    //    }
    //}
    public void Poof(Player pl)
    {
        Instantiate(popSound, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        if (!dead)
        {
            for (int i = 0; i < 6; i++)
            {
                GameObject g = Instantiate(rag, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                g.GetComponent<Renderer>().material.color = GetComponent<Renderer>().material.color;

                Vector3 dir = Quaternion.AngleAxis(60 * i, Vector3.forward) * Vector3.right;

                g.GetComponent<Rigidbody2D>().AddForce(dir * 500);
                g.transform.rotation = Quaternion.Euler(new Vector3(0, 0, i * 60));
                Destroy(g, 5);
            }
            dead = true;
            rb.freezeRotation = false;
            gameObject.layer = 9;
            GetComponent<Bird>().enabled = false;
            pl.AddScore(250);
            EffectsManager.PlayClip(transform.position, popSound);
            Game.CreateTextMessage("250", transform.position, Color.white);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Player pl = col.GetComponent<Player>();
        if (pl)
        {
            Poof(pl);
        }
    }
}
