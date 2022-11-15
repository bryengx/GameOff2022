 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour, IInteractable
{
    private Rigidbody2D rb;
    private Player player;
    public Transform R;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void LinkPlayer(Player pl)
    {
        player = pl;
    }
    public void JumpInteraction()
    {
        player.GetComponent<Rigidbody2D>().simulated = true;
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(rb.velocity.x, 0);
        rb.angularVelocity = -rb.angularVelocity;
        rb.velocity = -rb.velocity;
        player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 500);
        player.DeattachInteractable();
    }

    public void MoveInteraction(int turnInt)
    {
        if (turnInt == 1)
        {
            if (rb.angularVelocity < 100)
                rb.angularVelocity += 5;
        }
        else if (turnInt == 2)
        {
            if (rb.angularVelocity > -150)
                rb.angularVelocity -= 5;
        }
    }
    public void Position()
    {
        player.transform.position = new Vector3(transform.position.x, player.transform.position.y, player.transform.position.z);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.collider.GetComponent<Ball>();
        if (ball)
        {
            if (player)
            {
                player.GetComponent<Rigidbody2D>().simulated = true;
                ball.rb.velocity = rb.velocity;
                rb.velocity = -rb.velocity;
                ball.rb.angularVelocity = rb.angularVelocity;
                rb.angularVelocity = -rb.angularVelocity;
                player.Loose();
                player.DeattachInteractable();
            }
        }
        FinishPost post = collision.collider.GetComponent<FinishPost>();
        if (post)
        {
            if (player)
            {
                player.GetComponent<Rigidbody2D>().simulated = true;
                //ball.rb.velocity = rb.velocity;
                rb.velocity = -rb.velocity;
                //ball.rb.angularVelocity = rb.angularVelocity;
                rb.angularVelocity = -rb.angularVelocity;
                player.Loose();
                player.DeattachInteractable();
            }
        }
        Obsticle obs = collision.collider.GetComponent<Obsticle>();
        if (obs)
        {
            if (player)
            {
                player.GetComponent<Rigidbody2D>().simulated = true;
                rb.velocity = -rb.velocity;
                rb.angularVelocity = -rb.angularVelocity;
                player.Loose();
                player.DeattachInteractable();
            }
        }
    }
    public float GetRadius()
    {
        return Vector3.Distance(transform.position, R.position);
    }
}
