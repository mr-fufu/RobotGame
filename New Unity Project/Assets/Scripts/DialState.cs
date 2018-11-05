﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialState : MonoBehaviour {

    public int dial_state;
    public int dial_no;
    private Color selected_color = new Color(1, 1, 1, 1);
    private Color unselected_color = new Color(0, 0, 0, 0);
    private SpriteRenderer dial_sprite;

    void Start () {
        dial_sprite = GetComponent<SpriteRenderer>();
    }
	
	void Update () {
        dial_state = transform.parent.gameObject.GetComponent<DialController>().dial_state;

        if (dial_state == dial_no)
        {
            dial_sprite.color = selected_color;
        }
        else
        {
            dial_sprite.color = unselected_color;
        }
    }

    private void OnMouseDown()
    {
        transform.parent.gameObject.GetComponent<DialController>().dial_state = dial_no;
    }
}
