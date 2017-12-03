using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBottom : MonoBehaviour
{
    [SerializeField] ScoreManager scoreManager = null;

    private Collider parentCollider = null;

    public AudioClip se;

    public void SetCollider(Collider collider)
    {
        parentCollider = collider;
    }

    private void OnTriggerEnter(Collider collider)
    {

        if (parentCollider == collider)
        {
            print("Detected!");
            if (scoreManager)
            {
                GetComponent<AudioSource>().PlayOneShot(se);
                scoreManager.AddScore(2);
            }
           
        }

    }
}
