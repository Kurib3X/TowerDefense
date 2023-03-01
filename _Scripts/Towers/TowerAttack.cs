using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TowerAttack : TowerCharacteristics
{
    #region Variables
    [Header("Tower Attack")]
	[SerializeField] private Transform headGO;
	[SerializeField] private Transform muzzlePosition;
    [SerializeField] private GameObject projectile;
    [SerializeField] private int attackDamage;
    [SerializeField] private float attackCoolDown;
	[SerializeField] private GameObject fireParticle;

	[SerializeField] List<Transform> targets = new List<Transform>();

	private Transform _target;
	private float _closestEnemyFromBase = 1000;
	private float _lastFireTime = 0;

	#endregion
	
	#region Properties
	#endregion
	
	#region Built in Methods

	public override void Update(){
		base.Update();
		if (_target == null){
			SetTarget();
		}
	}

	private void OnTriggerEnter(Collider other){
		if(other.gameObject.layer != LayerMask.NameToLayer("Enemy")) return;

		targets.Add(other.transform);

		SetTarget();
	}

	private void OnTriggerStay(Collider other){
		if (other.gameObject.layer != LayerMask.NameToLayer("Enemy")) return;
		if (_target == null){
			SetTarget();
		}

		//Quand ennemi mort
	}

	private void OnTriggerExit(Collider other){
		if(other.gameObject.layer != LayerMask.NameToLayer("Enemy")) return;

		targets.Remove(other.transform);

		if (other.transform == _target){
			SetTarget();
		}
	}
	#endregion
	
	#region Custom Methods
	private void SetTarget(){
		CleanTargetList();
		if (targets.Count == 0){
			UnsetTarget();
			return;
		}

		_closestEnemyFromBase = 10000;

		foreach (Transform target in targets){
			Enemy currentEnemy = target.GetComponent<Enemy>();

			float distanceToBase = currentEnemy.GetRemainingDistance();
			if (distanceToBase < _closestEnemyFromBase){
				_closestEnemyFromBase = distanceToBase;
				_target = target;
			}
		}

		if (headGO){
			StartCoroutine(HeadFollow());
		}
	}

	private void UnsetTarget(){
		_target = null;
	}

	private void CleanTargetList(){
		for (int i = 0; i < targets.Count; i++){
			if (targets[i] == null){
				targets.RemoveAt(i);
			}
		}
	}

	IEnumerator HeadFollow(){
		while (_target){
			headGO.LookAt(_target);
			Fire();
			yield return new WaitForEndOfFrame();
		}
		yield return null;
	}

	private void Fire(){
		if (!projectile) return;

		if (Time.time >= _lastFireTime + attackCoolDown){
			StartCoroutine(FireParticle());
			_lastFireTime = Time.time;
			GameObject _projectile = Instantiate(projectile, muzzlePosition.position, Quaternion.identity);
			_projectile.GetComponent<Projectile>().Target = _target.GetComponent<Enemy>().TargetZone;
			_projectile.GetComponent<Projectile>().Damage = attackDamage;
		}
	}

	IEnumerator FireParticle(){
		fireParticle.SetActive(true);
		yield return new WaitForEndOfFrame();
		fireParticle.SetActive(false);
	}
	#endregion
}
