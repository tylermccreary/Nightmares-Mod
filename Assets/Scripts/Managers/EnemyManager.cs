using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 1f;
    public Transform[] spawnPoints;
	public float spawnTurn;

    void Start ()
    {
        InvokeRepeating ("Spawn", spawnTurn, spawnTime);
    }


    void Spawn ()
    {
        if(playerHealth.currentHealth <= 0f || WaveManager.endOfSpawning())
        {
            return;
        }
		
		WaveManager.countSpawn ();
        int spawnPointIndex = Random.Range (0, spawnPoints.Length);

        Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
