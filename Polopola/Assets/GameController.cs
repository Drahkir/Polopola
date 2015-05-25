using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GUIText scoreText;
    public static int currentScore;

	// Use this for initialization
	void Start ()
	{
	    currentScore = 0;
        UpdateScore();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void UpdateScore()
    {
        scoreText.text = "Score: " + currentScore;
    }
}
