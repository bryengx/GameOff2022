using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Mathf.Abs(transform.rotation.eulerAngles.z) < 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            Destroy(this);
        }
        else
        {
            if (transform.rotation.eulerAngles.z > 0)
                transform.Rotate(Vector3.forward, 1);
            else
                transform.Rotate(Vector3.forward, -1);
        }
    }
}
