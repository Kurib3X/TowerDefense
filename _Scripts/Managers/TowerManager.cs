using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    #region Variables
	[SerializeField] private GameObject towerMachineGunTemplate;
    #endregion
	
	#region Properties
	#endregion
	
	#region Built in Methods
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
	#endregion
	
	#region Custom Methods
    public void InstantiateMachineGun(){
        Instantiate(towerMachineGunTemplate, Vector3.zero, Quaternion.identity);
    }
	#endregion
}
