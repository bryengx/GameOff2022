using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private int turnInt;
    private Rigidbody2D rb;
    private IInteractable interactable;
    private bool grounded;
    public List<GameObject> groundObjects;
    public bool isOk;
    private float distance;
    private int score;
    void Start()
    {
        groundObjects = new List<GameObject>();
        rb = GetComponent<Rigidbody2D>();
        isOk = true;
        distance = 0;
        score = 0;
    }
    public int GetScore()
    {
        return score;
    }

    public string GetDistance()
    {
        return distance.ToString("0.00");
    }
    public void AddScore(int val)
    {
        score += val;
    }
    void Update()
    {

    }
    private void FixedUpdate()
    {
        if (interactable != null)
        {
            interactable.Position();
            interactable.MoveInteraction(turnInt);
        }
        else
        {
            if (grounded)
            {
                if (turnInt == 1)
                {
                    if (rb.velocity.x > -2)
                        rb.velocity += Vector2.left * 25 * Time.fixedDeltaTime;
                }
                else if (turnInt == 2)
                {
                    if (rb.velocity.x < 3)
                        rb.velocity += Vector2.right * 25 * Time.fixedDeltaTime;
                }
            }
        }
        if (isOk)
        {
            if(distance < transform.position.x)
                distance = transform.position.x;
        }
    }
    public void Loose()
    {
        isOk = false;
        rb.freezeRotation = false;
        rb.angularVelocity = rb.velocity.x * 15;
        Game.instance.ShowGameOverScreen();
        Game.instance.PlaySheepSound(transform.position);
        DataStore.SaveLongestDist(distance);
        DataStore.SaveHighScore(score);
    }
    public void Jump()
    {
        if (interactable != null)
        {
            interactable.JumpInteraction();
            Game.instance.PlayJumpSound(transform.position);
        }
        else
            if(grounded)
                rb.AddForce(Vector2.up * 400);
    }
    public void MoveInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector2 vect = (Vector2)context.ReadValueAsObject();

            if (vect != null)
            {
                if (vect.x < -0.4f)
                    turnInt = 1;
                else if (vect.x > 0.4f)
                    turnInt = 2;
                else
                    turnInt = 0;
            }
            else
                turnInt = 0;
        }
        if (context.canceled)
            turnInt = 0;
    }
    public void AttachInteractable(IInteractable inter)
    {
        interactable = inter;
        interactable.LinkPlayer(this);
    }
    public void DeattachInteractable()
    {
        interactable.LinkPlayer(null);
        interactable = null;
    }
    public void Move(InputAction.CallbackContext context)
    {
        MoveInput(context);
    }
    public void ActionBtnDown(InputAction.CallbackContext context)
    {
        if (context.started && !context.canceled)
        {
            Jump();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Solid"))
        {
            grounded = true;
            if (!groundObjects.Contains(collision.gameObject))
                groundObjects.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Solid"))
        {
            grounded = false;
            if (groundObjects.Contains(collision.gameObject))
                groundObjects.Remove(collision.gameObject);
        }
    }
}
