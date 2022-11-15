using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPost : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FinishLevel()
    {
        Game.instance.ShowFinishScreen();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player pl = collision.gameObject.GetComponent<Player>();
        if (pl && pl.groundObjects.Contains(gameObject))
        {
            //pl.AttachInteractable(ball);
            //pl.transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y + ball.GetRadius() + 1.0f, ball.transform.position.z);
            //pl.GetComponent<Rigidbody2D>().simulated = false;
            Game.instance.ShowFinishScreen();
        }
    }
}
