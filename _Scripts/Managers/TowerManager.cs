using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerManager : MonoBehaviour
{
    #region Variables
	[SerializeField] private GameObject canvasTower;
	[SerializeField] private GameObject towerMachineGunTemplate;

	private GameObject _canvas;
    #endregion
	
	#region Properties
	#endregion
	
	#region Built in Methods
	void Update(){
		if (Input.GetMouseButtonDown(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)){
				if (_canvas){
					StartCoroutine(DestroyCanvas());
				}
                if (hit.transform.tag == "UpgradeDetect"){
					_canvas = Instantiate(canvasTower, hit.transform.position, Quaternion.Euler(90, 0, 0));
					_canvas.transform.GetChild(0).gameObject.GetComponent<Button>().onClick.AddListener(() => hit.transform.GetComponent<TowerCharacteristics>().LevelUp());
					_canvas.transform.GetChild(1).gameObject.GetComponent<Button>().onClick.AddListener(() => hit.transform.GetComponent<TowerCharacteristics>().Sell());
				}
            }
        }
	}
	#endregion
	
	#region Custom Methods
    public void InstantiateMachineGun(){
        Instantiate(towerMachineGunTemplate, Vector3.zero, Quaternion.identity);
    }

	public void Upgrade(){
		print("Test");
	}

	IEnumerator DestroyCanvas(){
		GameObject canvasToDestroy = _canvas;
		yield return new WaitForSeconds(.1f);
		Destroy(canvasToDestroy);
	}
	#endregion
}
