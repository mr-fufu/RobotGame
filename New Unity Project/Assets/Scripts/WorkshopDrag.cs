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

    List<RaycastResult> hit_objects = new List<RaycastResult>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {

            selected_object = FindObjectsOnClick(drag_tag);

            Debug.Log(selected_object);

            if(selected_object != null)
            {

                Debug.Log("object Selected!");
                dragging = true;

                selected_object.SetAsLastSibling();

                selected_slot_type = selected_object.gameObject.GetComponent<UIPartComponentType>().part_type;

                original_position = selected_object.position;
                dragged_image = selected_object.GetComponent<Image>();
                dragged_image.raycastTarget = false;
            }
        }

        if (dragging)
        {
            selected_object.position = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (selected_object != null)
            {

                var placement = FindObjectsOnClick(slot_tag);

                if (placement != null) 
                {
                    placed_slot_type = placement.gameObject.GetComponent<UIPartComponentType>().slot_type;

                    if ( placed_slot_type == selected_slot_type)
                    {
                        Instantiate(selected_object.gameObject, selected_object.position, selected_object.rotation);
                        selected_object.position = original_position;
                    }
                }
                else
                {
                    selected_object.position = original_position;
                }
            }
        }

    }

    private Transform FindObjectsOnClick(string find_tag)
    {
        var click_position = new PointerEventData(EventSystem.current);

        click_position.position = Input.mousePosition;

        Debug.Log(click_position.position);

        EventSystem.current.RaycastAll(click_position, hit_objects);

        Debug.Log(hit_objects.First().gameObject.tag);

        if (hit_objects.Count <= 0)
        {
            return null;
        }
        else if (hit_objects.First().gameObject.tag == find_tag)
        {
            return hit_objects.First().gameObject.transform;
        }
        else
        {
            return null;
        }

    }
}
