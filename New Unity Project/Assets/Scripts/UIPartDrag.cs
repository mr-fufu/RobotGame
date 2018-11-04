using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPartDrag : MonoBehaviour {

    public Transform init_position;


	// Use this for initialization
	void Start () {
        init_position = gameObject.Transform;
	}
	
    void Update()
    {
        Input.GetMouseButtonDown(0);
    }

	// Update is called once per frame
	void OnMouseDrag () {
		
	}
}
