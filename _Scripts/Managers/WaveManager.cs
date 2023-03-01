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

    private GameManager _GM;
    
    private int _currentWave;
	#endregion
	
	#region Properties
	#endregion
	
	#region Built in Methods
    void Start()
    {
        _GM = GameManager.instance;
        StartCoroutine(RunWaves());
    }
	#endregion
	
	#region Custom Methods
    IEnumerator RunWaves(){
        _currentWave++;
        if (_currentWave <= nbWaves){
            for (int i = 0; i < nbEnemies; i++){
                GameObject newEnemy = Instantiate(enemy, enemySpawner.position, Quaternion.identity);
                newEnemy.transform.parent = enemySpawner.transform;
                newEnemy.GetComponent<Enemy>().Target = target;
                newEnemy.name = "Enemy : " + i.ToString();
                _GM.AddEnemyAlive();
                yield return new WaitForSeconds(spawnCoolDown);
            }
            if (_currentWave == nbWaves){
                _GM.WavesEnded();
            }
            else{
                yield return new WaitForSeconds(timeBetweenWaves);
                StartCoroutine(RunWaves());
            }
        }
    }
	#endregion
}
