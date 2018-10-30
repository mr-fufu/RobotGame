using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour {

    public int projectile_speed = 4;
    public bool enemy_check;
    public int damage_val;

    public GameObject sparks_object;
    public GameObject damage_values;
    public Transform impact_point;
    public int travel_range;
    private int travel_dist;
    private int move_dir = 0;

    // Use this for initialization
    void Start () {

        if (enemy_check == false)
        {
            move_dir = 1;
        }
        else if (enemy_check == true)
        {
            move_dir = -1;
        }
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(projectile_speed, 0f, 0f));
        travel_dist++;
        if (travel_dist >= (50 + 50*travel_range))
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D Target)
    {
        if (!enemy_check && Target.gameObject.tag == "BOT_Enemy")
        {
            Target.gameObject.GetComponent<Plating>().DamagePlating(damage_val);
            Instantiate(sparks_object, impact_point.position, impact_point.rotation);
            var clone = (GameObject)Instantiate(damage_values, impact_point.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<DamageValues>().damage_value = damage_val;
            Destroy(gameObject);
        }
        else if (enemy_check && Target.gameObject.tag == "BOT_Player")
        {
            Target.gameObject.GetComponent<Plating>().DamagePlating(damage_val);
            Instantiate(sparks_object, impact_point.position, impact_point.rotation);
            var clone = (GameObject)Instantiate(damage_values, impact_point.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<DamageValues>().damage_value = damage_val;
            Destroy(gameObject);
        }

    }

}
