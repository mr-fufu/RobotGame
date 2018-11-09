using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WorkshopDrag : MonoBehaviour {

    public const string drag_tag = "DraggableUIPart";
    public const string slot_tag = "UIPartSlot";
    private string selected_slot_type;
    private string placed_slot_type;

    private bool dragging = false;

    private Vector2 original_position;
    private Transform selected_object;
    private Image dragged_image;

    private GameObject hit_object;
    private bool occupied;

    //List<RaycastResult> hit_objects = new List<RaycastResult>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    selected_object = FindObjectsOnClick(drag_tag);

        //    if(selected_object != null)
        //    {
        //        dragging = true;

        //        selected_object.SetAsLastSibling();

        //        selected_slot_type = selected_object.gameObject.GetComponent<UIPartComponentType>().part_type;

        //        original_position = selected_object.position;
        //        dragged_image = selected_object.GetComponent<Image>();
        //        dragged_image.raycastTarget = false;
        //    }
        //}

        //if (dragging)
        //{
        //    selected_object.position = GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
        //}

        //if (Input.GetMouseButtonUp(0))
        //{
        //    if (selected_object != null)
        //    {

        //        var placement = FindObjectsOnClick(slot_tag);

        //        if (placement != null) 
        //        {
        //            placed_slot_type = placement.gameObject.GetComponent<UIPartComponentType>().slot_type;

        //            if ( placed_slot_type == selected_slot_type)
        //            {
        //                Instantiate(selected_object.gameObject, placement.transform);
        //                selected_object.position = original_position;
        //            }
        //        }
        //        else
        //        {
        //            selected_object.position = original_position;
        //        }
        //    }
        //}

        if (Input.GetMouseButtonDown(0))
        {
            if (!dragging)
            {
                selected_object = FindObjectsOnClick(drag_tag);

                if (selected_object != null)
                {
                    dragging = true;

                    selected_slot_type = selected_object.gameObject.GetComponent<UIPartComponentType>().part_type;

                    original_position = selected_object.position;
                    selected_object.GetComponent<Collider2D>().enabled = false;

                }
            }
            
        }

        if (dragging)
        {
            selected_object.position = GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {

            if (selected_object != null)
            {

                var placement = FindObjectsOnClick(slot_tag);

                if (placement != null)
                {
                    placed_slot_type = placement.gameObject.GetComponent<UIPartComponentType>().slot_type;

                    if (placed_slot_type == selected_slot_type)
                    {
                        foreach (Transform slot_containment in placement.transform)
                        {
                            GameObject.Destroy(slot_containment.gameObject);
                        }

                        var slot_component = Instantiate(selected_object.gameObject, placement.position, placement.rotation);

                        slot_component.transform.parent = placement.transform;
                        slot_component.name = placed_slot_type;
                        slot_component.transform.localScale = placement.transform.localScale;

                        selected_object.position = original_position;
                    }
                    else
                    {
                        selected_object.position = original_position;
                    }
                }
                else
                {
                    selected_object.position = original_position;
                }
            }

            else
            {
                selected_object.position = original_position;
            }

            selected_object.GetComponent<Collider2D>().enabled = true;
            selected_object = null;
            dragging = false;
        }

    }

    private Transform FindObjectsOnClick(string find_tag)
    {
        var click_position = GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);

        //click_position = Input.mousePosition;

        RaycastHit2D ray_hit = (Physics2D.Raycast(click_position, Vector2.zero, Mathf.Infinity));

        if (ray_hit.collider != null)
        {
            if (ray_hit.collider.gameObject.tag == find_tag)
            {
                return ray_hit.collider.gameObject.transform;
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }
}

