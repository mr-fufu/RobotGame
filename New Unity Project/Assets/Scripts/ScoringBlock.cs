using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringBlock : MonoBehaviour {

    public bool enemy_check;

    public GameObject score_counter;

    private void OnTriggerEnter2D(Collider2D cross_robot)
    {
        if (!enemy_check && cross_robot.gameObject.tag == "BOT_Enemy")
        {
            Debug.Log("BotCrossed");
            Destroy(cross_robot.gameObject);
            score_counter.GetComponent<ScoreCounter>().player_score_value -= 1;
        }
        else if (enemy_check && cross_robot.gameObject.tag == "BOT_Player")
        {
            Destroy(cross_robot.gameObject);
            score_counter.GetComponent<ScoreCounter>().enemy_score_value -= 1;
        }
    }
}
