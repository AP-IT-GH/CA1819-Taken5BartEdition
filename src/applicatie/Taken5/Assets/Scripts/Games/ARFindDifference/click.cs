﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class click : MonoBehaviour {

    public GameObject Object;
// Use this for initialization$
void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        // Code for OnMouseDown in the iPhone. Unquote to test.
        RaycastHit hit = new RaycastHit();
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase.Equals(TouchPhase.Began))
            {
                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log("hit");
                }
            }
        }
    }
}