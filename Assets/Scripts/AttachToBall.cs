using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttachToBall : MonoBehaviour
{
    public Ball ball;
    public Ball lastBall;
    public int[] pointsMatrix;
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
        Ball b = collision.collider.GetComponent<Ball>();
        if (b && player.isOk)
        {
            lastBall = ball;
            ball = b;
            if (player.groundObjects.Contains(ball.gameObject))
            {
                player.AttachInteractable(ball);
                player.transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y + ball.GetRadius() + 1.0f, ball.transform.position.z);
                player.GetComponent<Rigidbody2D>().simulated = false;
                if(lastBall != null)
                {
                    int points = CalcPoints();
                    player.AddScore(points);
                    Game.instance.PlaySuccessSound(ball.transform.position, 0);
                    Game.CreateTextMessage(points.ToString(), player.transform.position + (Vector3.up * 2), Color.white);
                    if (points > 200)
                        Game.CreateStars(transform.position);
                }
            }
            else
            {
                player.Loose();
            }
        }
    }
    public int CalcPoints()
    {
        ScoreItem[] items = FindObjectsOfType<ScoreItem>().Where(x => x.transform.position.x > lastBall.transform.position.x && x.transform.position.x < ball.transform.position.x).ToArray();
        return pointsMatrix[Mathf.Min(items.Length, pointsMatrix.Length - 1)];
    }
}
