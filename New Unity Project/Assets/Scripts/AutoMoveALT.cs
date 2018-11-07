using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoveALT : MonoBehaviour {

    public Collider2D engaged_target;

    public float move_dist;
    public float move_speed;
    private Animator Anim;
    private bool enemy_check;
    private int move_dir;
    public bool engaged_check = false;

    Collider2D[] check_colliders = new Collider2D[5];
    ContactFilter2D collider_filter = new ContactFilter2D();


    // Use this for initialization
    void Start () {
        collider_filter = collider_filter.NoFilter();

        Anim = GetComponent<Animator>();
        enemy_check = gameObject.GetComponent<StandardStatBlock>().ENEMY;

        Anim.speed = move_speed;
    }

    // Update is called once per frame
    void Update () {

        //-------------------------------------------------------------------
        // Set Walk Direction based on Enemy or Player owned bot (enemy_check bool)

        if (!enemy_check)
        {
            move_dir = 1;
        }
        else if (enemy_check)
        {
            move_dir = -1;
        }

        //-------------------------------------------------------------------
        // Set Bot to walk if not Engaged

        if (!engaged_check)
        {
            Anim.SetBool("WalkState", true);
        }
        else if (engaged_check)
        {
            Anim.SetBool("WalkState", false);
        }

        //-------------------------------------------------------------------
        // Disengage if the target is destroyed (receive destruction trigger 
        // prior to destruction from plating script of engaged target)
        // Also Resets target if it has been destroyed

        if (engaged_target != null && engaged_check == true)
        {
            if (engaged_target.gameObject.GetComponent<Plating>().destruction_trigger == true)
            {
                engaged_target = gameObject.GetComponent<Collider2D>();
                engaged_check = false;
            }
        }

    }

    void OnTriggerStay2D(Collider2D OtherCollider)
    {
        //Debug.Log("collisionDetected");

        // If collided with another bot in front (positions based on x position value of object centers)
        // sets engaged to true and acquires engaged target

        Vector3 OtherCenter = OtherCollider.gameObject.transform.position;
        Vector3 ObjectCenter = gameObject.transform.position;

        if (!enemy_check && OtherCenter.x > ObjectCenter.x && (OtherCollider.gameObject.tag == "BOT_Enemy" || OtherCollider.gameObject.tag == "BOT_Player"))
        {
            engaged_target = OtherCollider;
            engaged_check = true;
            Anim.SetBool("WalkState", false);
        }
        else if (enemy_check && OtherCenter.x < ObjectCenter.x && (OtherCollider.gameObject.tag == "BOT_Player" || OtherCollider.gameObject.tag == "BOT_Enemy"))
        {
            engaged_target = OtherCollider;
            engaged_check = true;
            Anim.SetBool("WalkState", false);
        }
    }

    void OnTriggerExit2D(Collider2D ExitCollider)
    {
        //used for disengagement of bots exiting without being destroyed
        //exit direction must agree with enemy_check


        Vector3 ExitObject = ExitCollider.gameObject.transform.position;
        Vector3 ObjectCenter = gameObject.transform.position;

        Collider2D[] check_colliders = new Collider2D[5];

        ContactFilter2D collider_filter = new ContactFilter2D();

        collider_filter = collider_filter.NoFilter();

        gameObject.GetComponent<Collider2D>().OverlapCollider(collider_filter, check_colliders);

        if (gameObject.name == "CrawlerLegs")
        {
            Debug.Log(check_colliders[1].gameObject.name);
        }

        if (check_colliders == null)
        {
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

    // Called during WalkState animation in order to move forward

    public void SkipMove()
    {
            transform.Translate(new Vector3(move_dist * move_dir * 8, 0f, 0f));
    }
}

// Time.deltaTime