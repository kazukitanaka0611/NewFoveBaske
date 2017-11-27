using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTop : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {

        GoalBottom bottom = GetComponentInChildren<GoalBottom>();
        bottom.SetCollider(collider);

    }

}
