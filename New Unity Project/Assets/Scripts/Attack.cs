using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public bool melee_check = false;
    public bool projectile_check = false;
    public bool attacking_check = false;
    public int attack_speed;

    private Animator Anim;

    // Use this for initialization
    void Start () {
        Anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		if (melee_check == true )
        {

        }
	}
}
