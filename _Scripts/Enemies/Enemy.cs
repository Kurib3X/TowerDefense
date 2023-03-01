using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Variables
    [SerializeField] private Transform _targetZone;
    [SerializeField] private int moneyDrop;
    [SerializeField] private int maxHealth;

    private Transform _target;
    private int _currentLife;
    private UnityEngine.AI.NavMeshAgent _agent;

    private GameManager _GM;
	#endregion
	
	#region Properties
    public Transform Target{
        get{return _target;}
        set{_target = value;}
    }

    public Transform TargetZone{
        get{return _targetZone;}
        set {_targetZone = value;}
    }
	#endregion
	
	#region Built in Methods
    void Start()
    {
        _GM = GameManager.instance;
        _agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        _currentLife = maxHealth;
    }

    void Update()
    {
        _agent.SetDestination(_target.position);
    }
    
    private void OnTriggerEnter(Collider other){
        if (other.gameObject.layer == LayerMask.NameToLayer("Base")){
            _GM.RemoveLife(1);
            Death();
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Projectile")){
            TakeDamage(other.gameObject.GetComponent<Projectile>().Damage);
        }
    }
    #endregion
	
	#region Custom Methods
    public float GetRemainingDistance()
    {
        float distance = 0;
        Vector3[] corners = _agent.path.corners;

        if (corners.Length > 2)
        {
            for (int i = 1; i < corners.Length; i++)
            {
                    Vector2 previous = new Vector2(corners[i - 1].x, corners[i - 1].z);
                    Vector2 current = new Vector2(corners[i].x, corners[i].z);

                    distance += Vector2.Distance(previous, current);
            }
        }
        else 
        {
            distance = _agent.remainingDistance;
        }

        return distance;
    }

    public void TakeDamage(int amount){
        _currentLife -= amount;
        if (_currentLife <= 0){
            Death();
            EarnMoney();
        }
    }

    private void Death(){
        _GM.RemoveEnemyAlive();
        GetComponent<BoxCollider>().enabled = false;
        Destroy(gameObject);
    }

    private void EarnMoney(){
        _GM.AddMoney(moneyDrop);
    }
	#endregion
}
