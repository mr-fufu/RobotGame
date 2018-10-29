using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    public bool enemy_check;
    public int damage_val;
    public GameObject sparks_object;
    public GameObject damage_values;
    public Transform impact_point;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerEnter2D(Collider2D Target)
    {
        if (!enemy_check && Target.gameObject.tag == "BOT_Enemy")
        {
            Target.gameObject.GetComponent<Plating>().DamagePlating(damage_val);
            Instantiate(sparks_object, impact_point.position, impact_point.rotation);
            var clone = (GameObject) Instantiate(damage_values, impact_point.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<DamageValues>().damage_value = damage_val;
        }
        else if (enemy_check && Target.gameObject.tag == "BOT_Player")
        {   
            Target.gameObject.GetComponent<Plating>().DamagePlating(damage_val);
            Instantiate(sparks_object, impact_point.position, impact_point.rotation);
            var clone = (GameObject)Instantiate(damage_values, impact_point.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<DamageValues>().damage_value = damage_val;
        }
    }
}
