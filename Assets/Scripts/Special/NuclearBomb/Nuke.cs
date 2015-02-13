using UnityEngine;
using System.Collections;

public class Nuke : MonoBehaviour
{
	
		GameObject player;
		private LayerMask shootable = 9;
		private GameObject enemy;
		private const int NUKE_DAMAGE = 300;

		void Awake ()
		{
				player = GameObject.FindGameObjectWithTag ("Player");
		}

		void OnTriggerEnter (Collider other)
		{
				if (other.gameObject == player) {
						Object[] allEnemies = FindObjectsOfType (typeof(GameObject));
						foreach (Object thisObject in allEnemies) {
								enemy = (GameObject)thisObject;
								if (enemy.layer == shootable) {
										MonoBehaviour[] enemyScripts = enemy.gameObject.GetComponents<MonoBehaviour> ();

										foreach (MonoBehaviour mb in enemyScripts) {
												if (mb is EnemyHealth) {
														EnemyHealth eAttack = (EnemyHealth)mb;
														eAttack.TakeDamage (NUKE_DAMAGE, enemy.transform.position);
												}
										}
								}
						}
						ScoreManager.score += 200;
						Destroy (gameObject);
				}
		}
}
