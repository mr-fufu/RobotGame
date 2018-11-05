using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialController : MonoBehaviour {

    public int dial_state = 1;
    public int max_dial_states;

	void Start () {
		
	}
	
	void OnMouseDown () {
        dial_state++;

        if (dial_state > max_dial_states)
        {
            dial_state = 1;
        }
	}
}
