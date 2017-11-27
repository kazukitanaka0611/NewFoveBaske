using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaketBall : MonoBehaviour
{
    private bool isBottom = true;

    public void Shot(Vector3 force)
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = true;
        rigidbody.AddForce(force, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {

       
        
    }
}
