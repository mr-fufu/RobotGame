using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageValues : MonoBehaviour {

    public float RiseSpeed;
    public int Damage;
    public Text DisplayedNumber;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        DisplayedNumber.text = "-" + Damage;
        transform.position = new Vector3(transform.position.x, transform.position.y + (RiseSpeed * Time.deltaTime), transform.position.z);
	}
}
