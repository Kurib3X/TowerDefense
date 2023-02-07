using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCharacteristics : MonoBehaviour
{
    #region Variables
    [Header("Tower Characteristics")]
    [SerializeField] private float cost;
    [SerializeField] private float sellingCost;
    [SerializeField] private float attackRange;

    private int _currentLevel;
	#endregion
	
	#region Properties
	#endregion
	
	#region Built in Methods
    void Awake()
    {
        GetComponent<SphereCollider>().radius = attackRange;
    }

    void Update()
    {
        
    }
	#endregion
	
	#region Custom Methods
    void LevelUp(){

    }
	#endregion
}
