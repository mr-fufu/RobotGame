using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    public bool Enemy;
    public int DamageVal;
    public GameObject Sparks;
    public GameObject DamageValues;
    public Transform ImpactPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerEnter2D(Collider2D Target)
    {
        if (!Enemy && Target.gameObject.tag == "BOT_Enemy")
        {
            Target.gameObject.GetComponent<Plating>().DamagePlating(DamageVal);
            Instantiate(Sparks, ImpactPoint.position, ImpactPoint.rotation);
            var clone = (GameObject) Instantiate(DamageValues, ImpactPoint.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<DamageValues>().Damage = DamageVal;
        }
        else if (Enemy && Target.gameObject.tag == "BOT_Player")
        {   
            Target.gameObject.GetComponent<Plating>().DamagePlating(DamageVal);
            Instantiate(Sparks, ImpactPoint.position, ImpactPoint.rotation);
            var clone = (GameObject)Instantiate(DamageValues, ImpactPoint.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<DamageValues>().Damage = DamageVal;
        }
    }
}
