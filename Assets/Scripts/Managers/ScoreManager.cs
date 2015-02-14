using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
		private static int score;
		private static int scoreMultiplier;
		Text text;

		void Awake ()
		{
				text = GetComponent <Text> ();
				score = 0;
				scoreMultiplier = 1;
		}

		void Update ()
		{
				scoreMultiplier = WaveManager.getWave ();
				text.text = "Score: " + score;
		}

		public static void addToScore (int amount)
		{
				score = score + (amount * scoreMultiplier);
		}
}
