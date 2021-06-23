using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private LineRenderer lr;
    private Vector3 laserEnd =Vector3.zero;
    public PlayerMovement plreference;
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    { 
       
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, laserEnd);
    }
}
