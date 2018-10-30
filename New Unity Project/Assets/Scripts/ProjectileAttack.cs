using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : MonoBehaviour {

    public int projectile_range;
    public int projectile_damage;

    public int attack_speed;
    public GameObject projectile;
    private int reloadtime = 100;
    private bool enemy_check;
    public Transform launch_point;

    // Use this for initialization
    void Start () {
        enemy_check = gameObject.GetComponent<StandardStatBlock>().ENEMY;
    }
	
	// Update is called once per frame
	void Update () {
        reloadtime -= attack_speed;
        if (reloadtime <= 0 )
        {
            var clone = (GameObject) Instantiate(projectile, launch_point.position, launch_point.rotation);
            clone.GetComponent<ProjectileDamage>().damage_val = projectile_damage;
            clone.GetComponent<ProjectileDamage>().travel_range = projectile_range;
            clone.GetComponent<ProjectileDamage>().enemy_check = enemy_check;
            reloadtime = 100;
        }
	}
}
