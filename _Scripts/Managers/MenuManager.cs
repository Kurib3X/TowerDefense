using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    #region Variables
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
    public void RestartCurrentScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
	#endregion
}
