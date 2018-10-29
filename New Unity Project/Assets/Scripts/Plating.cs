using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plating : MonoBehaviour {

    public int max_plating;
    public int current_plating;
    public bool destruction_trigger = false;
    public Object plating_bar;
    
    // Use this for initialization
    void Start () {
        current_plating = max_plating;
        Instantiate(plating_bar, gameObject.transform);

    }

    // Update is called once per frame
    void Update() {
        if (current_plating <= 0)
        {
            destruction_trigger = true;
            Destroy(gameObject);
        }
    }

    public void DamagePlating(int DamageInflicted)
        {
            current_plating -= DamageInflicted;
        }

    public void RepairPlating(int RepairInflicted)
        {
            current_plating += RepairInflicted;
        }
}
