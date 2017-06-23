using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Example
{
	public class ScoreBoard : MonoBehaviour 
	{
        public int currentScore = 0;
        private int highScore;
        public Text textScore;
        public Text textHighScore;

        private void Start()
        {
            highScore = PlayerPrefs.GetInt("highscore", 0);
            textHighScore.text = highScore.ToString();
        }

        private void Update()
        {
            if (currentScore > highScore)
            {
                highScore = currentScore;
                textHighScore.text = highScore.ToString();

                PlayerPrefs.SetInt("highscore", highScore);
            }
        }

        public void addScore(int score)
        {
            currentScore += score;
            textScore.text = currentScore.ToString();
        }
		
	}

}
