using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatingValues : MonoBehaviour {

    public Slider bar_value;
    public Plating plating_location;

	// Use this for initialization
	void Start () {
        plating_location = transform.parent.gameObject.GetComponent<Plating>();
	}
	
	// Update is called once per frame
	void Update () {
        bar_value.maxValue = plating_location.MaxPlating;
        bar_value.value = plating_location.CurrentPlating;
    }
}
