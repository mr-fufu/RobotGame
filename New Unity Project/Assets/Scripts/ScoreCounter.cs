using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {

    public Text Player_Scoring;
    public Text Enemy_Scoring;

    public int player_score_value;
    public int enemy_score_value;

	// Use this for initialization
	void Start () {
        player_score_value = 10;
        enemy_score_value = 10;
	}
	
	// Update is called once per frame
	void Update () {
        Player_Scoring.text = "" + player_score_value;
        Enemy_Scoring.text = "" + enemy_score_value;
	}
}
