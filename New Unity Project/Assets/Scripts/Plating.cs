using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plating : MonoBehaviour {

    public int MaxPlating;
    public int CurrentPlating;
    public bool DestructionTrigger = false;
    public Object PlatingBar;
    
    // Use this for initialization
    void Start () {
        CurrentPlating = MaxPlating;
        Instantiate(PlatingBar, gameObject.transform);
    }

    // Update is called once per frame
    void Update() {
        if (CurrentPlating <= 0)
        {
            DestructionTrigger = true;
            Destroy(gameObject);
        }
    }

    public void DamagePlating(int DamageInflicted)
        {
            CurrentPlating -= DamageInflicted;
        }

    public void RepairPlating(int RepairInflicted)
        {
            CurrentPlating += RepairInflicted;
        }
}
