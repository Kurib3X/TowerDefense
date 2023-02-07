using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private int wallet = 10;
    [SerializeField] private int originBaseLife = 100;

    private int _currentBaseLife;

    public static GameManager instance;
    private UIManager _UI;
	#endregion
	
	#region Properties
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

        _currentBaseLife = originBaseLife;
    }

    void Update()
    {
        
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

    private void GameOver(){
        print("Perdu");
    }
	#endregion
}
