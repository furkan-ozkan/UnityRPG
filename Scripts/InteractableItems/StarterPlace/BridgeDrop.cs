using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BridgeDrop : MonoBehaviour,IInteraction
{
    public GameObject bridge;
    public float dropSpeed;
    private bool _drop=false;
    public NavMeshSurface navMeshSurface;
    
    private void Update()
    {
        if (_drop)
        {
            bridge.transform.position += new Vector3(0, dropSpeed, 0) * Time.deltaTime;
            if (bridge.transform.position.y <= -2.75)
            {
                Destroy(gameObject.GetComponent<BridgeDrop>());
            }
        }
    }

    public void Action()
    {
        _drop = true;
    }
}
