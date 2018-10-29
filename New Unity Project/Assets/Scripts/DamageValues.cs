using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageValues : MonoBehaviour {

    public float rise_speed;
    public int damage_value;
    public Text displayed_value;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        displayed_value.text = "-" + damage_value;
        transform.position = new Vector3(transform.position.x, transform.position.y + (rise_speed * Time.deltaTime), transform.position.z);
	}
}
