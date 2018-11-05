using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarSelect : MonoBehaviour {

    public int box_no;
    public int selected_box;
    private SpriteRenderer boxSprite;
    private Color selected_color = new Color(0, 1, 1);
    private Color unselected_color = new Color(255, 255, 255);

    void Start ()
    {
        boxSprite = GetComponent<SpriteRenderer>();
	}

    void Update()
    {
        selected_box = transform.parent.gameObject.GetComponent<BarSelectParentLink>().selected_box;

        if (selected_box == box_no)
        {
            boxSprite.color = selected_color;
        }
        else
        {
            boxSprite.color = unselected_color;
        }
    }

    private void OnMouseDown()
    {
        if (selected_box != box_no)
        {
            transform.parent.gameObject.GetComponent<BarSelectParentLink>().selected_box = box_no;
        }
    }


}
