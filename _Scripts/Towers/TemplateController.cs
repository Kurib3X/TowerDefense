using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplateController : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject tower;
    [SerializeField] private int cost;

    private int _layerMaskGround = 1<<6;
    private int _layerMaskSpawner = 1<<7;

    private GameManager _GM;
	#endregion
	
	#region Properties
	#endregion
	
	#region Built in Methods
    void Start()
    {
        _GM = GameManager.instance;
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, _layerMaskGround)){
            transform.position = hit.point;
        }

        if (Physics.Raycast(ray, out hit, 100, _layerMaskSpawner)){
            transform.position = hit.transform.position;
            if (Input.GetMouseButton(0)){
                TowerSpawner ts = hit.collider.gameObject.GetComponent<TowerSpawner>();
                if (!ts.IsBusy){
                    if (_GM.RemoveMoney(cost)){
                        ts.IsBusy = true;
                        Instantiate(tower, hit.transform.GetChild(0).transform.position, Quaternion.identity);
                        Destroy(gameObject);
                    }
                }
            }
        }

        if (Input.GetMouseButton(1)){
            Destroy(gameObject);
        }
    }
	#endregion
	
	#region Custom Methods
	#endregion
}
