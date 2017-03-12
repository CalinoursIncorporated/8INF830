using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstratForce : MonoBehaviour {

    public float Weight;

    public abstract Vector3 CalculateForce();
}
