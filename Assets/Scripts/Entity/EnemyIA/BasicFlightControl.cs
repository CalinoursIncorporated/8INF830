﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFlightControl : MonoBehaviour{

    Enemy parent;
    Rigidbody rb;


    public float MainThrust = 5.0f;
    public float AuxThrust = 2.5f;
    public float rotationSpeed = 0.01f;

    protected void Start()
    {
       
        parent = GetComponent<Enemy>();
        if(parent == null)
        {
            enabled = false;
        }

        rb = GetComponent<Rigidbody>();

    }

    public void Update()
    {
        Vector3 force = CalculateForces();
        //Forward axis
        Vector3 forwardForce = Vector3.Project(force, gameObject.transform.forward);
        if (forwardForce.magnitude >= MainThrust)
        {
            
            forwardForce = forwardForce.normalized;
            forwardForce *= MainThrust;
        }

        rb.AddForce(forwardForce);

        //Up axis
        Vector3 upForce = Vector3.Project(force, gameObject.transform.up);
        if (upForce.magnitude >= AuxThrust)
        {

            upForce = upForce.normalized;
            upForce *= AuxThrust;
        }

        rb.AddForce(upForce);

        //Red axis
        Vector3 rightForce = Vector3.Project(force, gameObject.transform.right);
        if (rightForce.magnitude >= AuxThrust)
        {    
            rightForce = rightForce.normalized;
            rightForce *= AuxThrust;
        }


        rb.AddForce(rightForce);

        Vector3 newDir = Vector3.RotateTowards(transform.forward, force, rotationSpeed, 0.0F);
        transform.rotation = Quaternion.LookRotation(newDir);

    }

    /// <summary>
    /// Comptute to form the desired force for the next frame
    /// </summary>
    /// <returns></returns>
    public Vector3 CalculateForces()
    {
        AbstratForce[] tabForce =  GetComponents<AbstratForce>();
        Vector3 totalForce = new Vector3();
        foreach (AbstratForce actForce in tabForce )
        {
            totalForce += actForce.CalculateForce().normalized * actForce.Weight;
        }
        return totalForce;
    }

}
