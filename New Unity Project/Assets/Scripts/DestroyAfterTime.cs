using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime: MonoBehaviour {

    public float LifeTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        LifeTime -= Time.deltaTime;
        if (LifeTime <= 0) 
        {
            Destroy(gameObject);
        }
	}
}
