using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private TMP_Text money;
    [SerializeField] private TMP_Text life;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject win;

    public static UIManager instance;
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
	#endregion
	
	#region Custom Methods
    public void UpdateMoney(int moneyToUpdate){
        money.text = moneyToUpdate.ToString() + "€";
    }

    public void UpdateLife(int lifeToUpdate){
        life.text = "Life : " + lifeToUpdate.ToString();
    }

    public void GameOver(){
        gameOver.SetActive(true);
    }

    public void Win(){
        win.SetActive(true);
    }
	#endregion
}
