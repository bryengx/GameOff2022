using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToBall : MonoBehaviour
{
    public Ball ball;
    private Player player;
    void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D");
        Ball b = collision.collider.GetComponent<Ball>();
        if (b && player.isOk)
        {
            ball = b;
            if (player.groundObjects.Contains(ball.gameObject))
            {
                player.AttachInteractable(ball);
                player.transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y + ball.GetRadius() + 1.0f, ball.transform.position.z);
                player.GetComponent<Rigidbody2D>().simulated = false;
            }
            else
            {
                player.Loose();
            }
        }
    }
}
