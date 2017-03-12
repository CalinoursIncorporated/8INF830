using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity {



    BasicFlightControl iaEnemy;

    Rigidbody rb;

    protected override void Start()
    {
        base.Start();
        iaEnemy = GetComponent<BasicFlightControl>();
        rb = GetComponentInParent<Rigidbody>();
    }

    protected override void Update()
    {
        base.Update();
        

    }

}
