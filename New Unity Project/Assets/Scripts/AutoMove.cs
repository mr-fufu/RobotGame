using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour {

    public Collider2D EngagedTarget;

    public float moveSpeed;
    private Animator Anim;
    public bool Enemy;
    private int MoveDir;
    public bool Engaged = false;
    
    // Use this for initialization
    void Start () {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {

        //Debug.Log(CollDist);
        if (!Enemy && !Engaged)
        {
            Anim.SetBool("Walk", true);
            MoveDir = 1;
        }
        else if (Enemy && !Engaged)
        {
            Anim.SetBool("Walk", true);
            MoveDir = -1;
        }

        if (
            Anim.GetCurrentAnimatorStateInfo(0).IsName("Move1") ||
            Anim.GetCurrentAnimatorStateInfo(0).IsName("Move2") ||
            Anim.GetCurrentAnimatorStateInfo(0).IsName("Move3") ||
            Anim.GetCurrentAnimatorStateInfo(0).IsName("Move4") ||
            Anim.GetCurrentAnimatorStateInfo(0).IsName("Move")
            )
        {
            transform.Translate(new Vector3(moveSpeed * MoveDir, 0f, 0f));
        }

        if (EngagedTarget == null)
        {
            EngagedTarget = gameObject.GetComponent<Collider2D>();
        }

        if (EngagedTarget != null && Engaged == true)
        {
            if (EngagedTarget.gameObject.GetComponent<Plating>().DestructionTrigger == true)
            {
                Engaged = false;
            }
        }
        
    }

    void OnTriggerStay2D(Collider2D OtherCollider)
    {
        //Debug.Log("collisionDetected");
        
        Vector3 OtherCenter = OtherCollider.gameObject.transform.position;
        Vector3 ObjectCenter = gameObject.transform.position;

        if (!Enemy && OtherCenter.x > ObjectCenter.x)
        {
            EngagedTarget = OtherCollider;
            Engaged = true;
            Anim.SetBool("Walk", false);
        }
        else if (Enemy && OtherCenter.x < ObjectCenter.x)
        {
            EngagedTarget = OtherCollider;
            Engaged = true;
            Anim.SetBool("Walk", false);
        }
    }

    void OnTriggerExit2D(Collider2D ExitCollider)
    {
        Vector3 ExitObject = ExitCollider.gameObject.transform.position;
        Vector3 ObjectCenter = gameObject.transform.position;

        if (Engaged && !Enemy && ExitObject.x > ObjectCenter.x && (ExitCollider.gameObject.tag == "BOT_Player" || ExitCollider.gameObject.tag == "BOT_Enemy"))
        {
            Engaged = false;
        }
        else if (Engaged && Enemy && ExitObject.x < ObjectCenter.x && (ExitCollider.gameObject.tag == "BOT_Player" || ExitCollider.gameObject.tag == "BOT_Enemy"))
        {
            Engaged = false;
        }
    }
}

// Time.deltaTime