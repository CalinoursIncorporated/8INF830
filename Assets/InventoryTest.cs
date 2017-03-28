using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTest : MonoBehaviour {


    public InventoryController invCtrl;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddItem()
    {
        invCtrl.AddItem(200, 5);
        invCtrl.AddItem(201, 3);

        invCtrl.AddItem(210, 3);
        invCtrl.AddItem(211, 3);
        invCtrl.AddItem(212, 3);
    }
}
