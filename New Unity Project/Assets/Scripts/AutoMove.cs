using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour {

    public Collider2D engaged_target;

    public float move_speed;
    private Animator Anim;
    public bool enemy_check;
    private int move_dir;
    public bool engaged_check = false;
    
    // Use this for initialization
    void Start () {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {

        //Debug.Log(CollDist);
        if (!enemy_check && !engaged_check)
        {
            Anim.SetBool("Walk", true);
            move_dir = 1;
        }
        else if (enemy_check && !engaged_check)
        {
            Anim.SetBool("Walk", true);
            move_dir = -1;
        }

        if (
            Anim.GetCurrentAnimatorStateInfo(0).IsName("Move1") ||
            Anim.GetCurrentAnimatorStateInfo(0).IsName("Move2") ||
            Anim.GetCurrentAnimatorStateInfo(0).IsName("Move3") ||
            Anim.GetCurrentAnimatorStateInfo(0).IsName("Move4") ||
            Anim.GetCurrentAnimatorStateInfo(0).IsName("Move")
            )
        {
            transform.Translate(new Vector3(move_speed * move_dir, 0f, 0f));
        }

        if (engaged_target == null)
        {
            engaged_target = gameObject.GetComponent<Collider2D>();
        }

        if (engaged_target != null && engaged_check == true)
        {
            if (engaged_target.gameObject.GetComponent<Plating>().destruction_trigger == true)
            {
                engaged_check = false;
            }
        }
        
    }

    void OnTriggerStay2D(Collider2D OtherCollider)
    {
        //Debug.Log("collisionDetected");
        
        Vector3 OtherCenter = OtherCollider.gameObject.transform.position;
        Vector3 ObjectCenter = gameObject.transform.position;

        if (!enemy_check && OtherCenter.x > ObjectCenter.x)
        {
            engaged_target = OtherCollider;
            engaged_check = true;
            Anim.SetBool("Walk", false);
        }
        else if (enemy_check && OtherCenter.x < ObjectCenter.x)
        {
            engaged_target = OtherCollider;
            engaged_check = true;
            Anim.SetBool("Walk", false);
        }
    }

    void OnTriggerExit2D(Collider2D ExitCollider)
    {
        Vector3 ExitObject = ExitCollider.gameObject.transform.position;
        Vector3 ObjectCenter = gameObject.transform.position;

        if (engaged_check && !enemy_check && ExitObject.x > ObjectCenter.x && (ExitCollider.gameObject.tag == "BOT_Player" || ExitCollider.gameObject.tag == "BOT_Enemy"))
        {
            engaged_check = false;
        }
        else if (engaged_check && enemy_check && ExitObject.x < ObjectCenter.x && (ExitCollider.gameObject.tag == "BOT_Player" || ExitCollider.gameObject.tag == "BOT_Enemy"))
        {
            engaged_check = false;
        }
    }
}

// Time.deltaTime