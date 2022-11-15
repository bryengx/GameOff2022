using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void LinkPlayer(Player pl);
    void JumpInteraction();
    void MoveInteraction(int turnInt);
    void Position();
}
public class Utils : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
