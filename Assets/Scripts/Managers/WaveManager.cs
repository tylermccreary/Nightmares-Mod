using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveManager : MonoBehaviour
{
		private static int wave;
		private static int deathCount;
		private static int enemyCount;
		private static int spawnAmount;
		private static bool doneSpawning = false;
		private static bool nukeForWave = false;
		private const int ENEMIES_WARNING = 30;
		public GameObject nuke;
		public Transform[] spawnPoints;
		public PlayerHealth playerHealth;
		Text text;

		void Awake ()
		{
				text = GetComponent <Text> ();
				wave = 1;
				spawnAmount = 0;
				enemyCount = 5;
				deathCount = 0;
		}
	
		void Update ()
		{
				text.text = "Wave: " + wave;
				if (spawnAmount >= enemyCount) {
						doneSpawning = true;
				}
				if (deathCount >= enemyCount) {
						nextWave ();
				}
				checkNuke ();
		}

		void checkNuke ()
		{
				if (nukeForWave == false && (spawnAmount - deathCount) >= ENEMIES_WARNING) {
						Debug.Log ("hello");
						nukeForWave = true;
						int spawnPointIndex = Random.Range (0, spawnPoints.Length);
						Instantiate (nuke, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
				}
		}

		public static int getWave ()
		{
				return wave;
		}

		private void nextWave ()
		{
				wave += 1;
				deathCount = 0;
				enemyCount = enemyCount + 5;
				spawnAmount = 0;
				doneSpawning = false;
				nukeForWave = false;
		}

		public static void countDeath ()
		{
				deathCount += 1;
		}

		public static void countSpawn ()
		{
				spawnAmount += 1;
		}

		public static int getSpawnAmount ()
		{
				return spawnAmount;
		}

		public static int getEnemyCount ()
		{
				return enemyCount;
		}

		public static bool endOfSpawning ()
		{
				return doneSpawning;
		}
}

