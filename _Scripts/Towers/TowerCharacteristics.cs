using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCharacteristics : MonoBehaviour
{
    #region Variables
    [Header("Tower Characteristics")]
    [SerializeField] private int upgradeCost;
    [SerializeField] private int sellingCost;
    [SerializeField] private float attackRange;
    [SerializeField] private GameObject towerLevelUp;

    private GameObject _towerSpawnerGO;
    private int _currentLevel;

    private GameManager _GM;
	#endregion
	
	#region Properties
    public GameObject TowerSpawnerGO{
        get{return _towerSpawnerGO;}
        set{_towerSpawnerGO = value;}

    }
	#endregion
	
	#region Built in Methods
    void Awake()
    {
        _GM = GameManager.instance;
        GetComponent<SphereCollider>().radius = attackRange;
    }

    public virtual void Update(){
        
    }
	#endregion
	
	#region Custom Methods
    public void LevelUp(){
        if (_GM.Wallet - upgradeCost >= 0 && towerLevelUp){
            _GM.RemoveMoney(upgradeCost);
            GameObject towerUp = Instantiate(towerLevelUp, transform.position, Quaternion.identity);
            towerUp.GetComponent<TowerCharacteristics>().TowerSpawnerGO = _towerSpawnerGO;
            Destroy(gameObject);
        }
        else{
            //faire un feedback
        }
    }

    public void Sell(){
        _GM.AddMoney(sellingCost);
        _towerSpawnerGO.GetComponent<TowerSpawner>().IsBusy = false;
        Destroy(gameObject);
    }
	#endregion
}
