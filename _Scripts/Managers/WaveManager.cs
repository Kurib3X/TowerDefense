using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private int nbWaves = 3;
    [SerializeField] private int nbEnemies = 10;
    [SerializeField] private float spawnCoolDown = 1;
    [SerializeField] private float timeBetweenWaves = 5;
    [SerializeField] private Transform enemySpawner;
    [SerializeField] private Transform target;

    [SerializeField] private GameObject enemy;
    
    private int _currentWave;
	#endregion
	
	#region Properties
	#endregion
	
	#region Built in Methods
    void Start()
    {
        StartCoroutine(RunWaves());
    }

    void Update()
    {
        
    }
	#endregion
	
	#region Custom Methods
    IEnumerator RunWaves(){
        _currentWave++;
        if (_currentWave <= nbWaves){
            for (int i = 0; i < nbEnemies; i++){
                GameObject newEnemy = Instantiate(enemy, enemySpawner.position, Quaternion.identity);
                newEnemy.GetComponent<Enemy>().Target = target;
                newEnemy.name = "Enemy : " + i.ToString();
                yield return new WaitForSeconds(spawnCoolDown);
            }
            yield return new WaitForSeconds(timeBetweenWaves);
            StartCoroutine(RunWaves());
        }
        yield return null;
    }
	#endregion
}
