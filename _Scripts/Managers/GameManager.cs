using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private int wallet = 10;
    [SerializeField] private int originBaseLife = 100;
    [SerializeField] private GameObject enemySpawn;

    private int _currentBaseLife;
    private bool _wavesEnded = false;
    private int _enemyAliveNumber = 0;

    public static GameManager instance;
    private UIManager _UI;
	#endregion
	
	#region Properties
    public int Wallet => wallet;
	#endregion
	
	#region Built in Methods

    void Awake(){
        if (instance != null){
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    void Start()
    {
        _UI = UIManager.instance;
        _UI.UpdateMoney(wallet);
        _UI.UpdateLife(originBaseLife);

        Time.timeScale = 1;
        _currentBaseLife = originBaseLife;
    }
	#endregion
	
	#region Custom Methods
    public void AddMoney(int money){
        wallet += money;
        _UI.UpdateMoney(wallet);
    }

    public bool RemoveMoney(int money){
        if ((wallet - money) >= 0){
            wallet -= money;
            _UI.UpdateMoney(wallet);
            return true;
        }
        else{
            return false;
        }
    }

    public void AddLife(int life){
        _currentBaseLife += life;
        if (_currentBaseLife > originBaseLife){
            _currentBaseLife = originBaseLife;
        }
        _UI.UpdateLife(_currentBaseLife);
    }

    public void RemoveLife(int life){
        _currentBaseLife -= life;
        if (_currentBaseLife <= 0){
            _currentBaseLife = 0;
            GameOver();
        }
        _UI.UpdateLife(_currentBaseLife);
    }

    public void GameOver(){
        for (int i = 0; i < enemySpawn.transform.childCount; i++){
            Destroy(enemySpawn.transform.GetChild(i).gameObject);
        }
        _UI.GameOver();
        Time.timeScale = 0;
    }

    public void AddEnemyAlive(){
        _enemyAliveNumber++;
    }

    public void RemoveEnemyAlive(){
        _enemyAliveNumber--;
        if (_wavesEnded && _enemyAliveNumber == 0){
            _UI.Win();
        }
    }

    public void WavesEnded(){
        _wavesEnded = true;
    }
	#endregion
}
