using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingScript : MonoBehaviour
{
    public float angle = 0;

    public void OnEnable()
    {
        Debug.Log("Object enabled");
    }

    public void OnDisable()
    {
        Debug.Log("Object disabled");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.Slerp(transform.forward, transform.up, angle / 90) * 10);
    }
}