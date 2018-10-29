using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public bool Melee = false;
    public bool Projectile = false;
    public bool Attacking = false;
    public int AttackSpeed;

    private Animator Anim;

    // Use this for initialization
    void Start () {
        Anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		if (Melee == true )
        {

        }
	}
}
