using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour, IInteractable
{
    private bool used;
    private Player player;
    public Transform attachpoint;
    public float power;
    public AudioClip boomSound;
    public GameObject smokeEmmiter;

    void Start()
    {
        used = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player pl = collision.GetComponent<Player>();
        if (pl && !used)
        {
            player = pl;
            player.AttachInteractable(this);
            player.transform.position = attachpoint.position;
            player.GetComponent<Rigidbody2D>().simulated = false;
            player.transform.SetParent(attachpoint);
            used = true;
        }
    }

    public void LinkPlayer(Player pl)
    {
        player = pl;
    }

    public void JumpInteraction()
    {
        player.transform.position = attachpoint.position;
        player.GetComponent<Rigidbody2D>().simulated = true;
        player.transform.SetParent(null);
        player.AddForce(power);
        player.gameObject.AddComponent<CorrectRotation>();
        player.DeattachInteractable();
        EffectsManager.PlayClip(transform.position, boomSound);
        GameObject smoke = Instantiate(smokeEmmiter, attachpoint);
        smoke.transform.rotation = transform.rotation;
        Destroy(smoke, 3);
        foreach (var item in GetComponents<Collider2D>())
        {
            item.enabled = false;
        }
    }

    public void MoveInteraction(int turnInt)
    {
        if (turnInt == 1)
        {
            transform.Rotate(Vector3.forward, 1);
        }
        else if (turnInt == 2)
        {
            transform.Rotate(Vector3.forward, -1);
        }
    }

    public void Position()
    {
        //throw new System.NotImplementedException();
    }

    public Vector2 GetVelocity()
    {
        return Vector2.zero;
    }
}
