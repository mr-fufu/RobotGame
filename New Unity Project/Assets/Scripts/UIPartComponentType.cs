using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPartComponentType : MonoBehaviour {

    public bool slot_component;

    public string slot_type;

    public string part_type;

    private void Start()
    {
        if (slot_component)
        {
            part_type = "NOT A PART";
        }

        if (!slot_component)
        {
            slot_type = "NOT A SLOT";
        }
    }
}
