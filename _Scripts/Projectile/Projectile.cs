using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    #region Variables
    [SerializeField] private float speed = 10;

    private Transform _target;
    private int _damage;
	#endregion
	
	#region Properties
    public Transform Target{
        get => _target;
        set => _target = value;
    }
    public int Damage{
        get => _damage;
        set => _damage = value;
    }
	#endregion
	
	#region Built in Methods
    void Start()
    {
        StartCoroutine(LerpPosition(_target.position, 1 / speed));
    }

    void Update()
    {
        
    }
	#endregion
	
	#region Custom Methods
    IEnumerator LerpPosition(Vector3 targetPosition, float duration){
        float time = 0;
        Vector3 startPosition = transform.position;
        
        while(time < duration){
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
	#endregion
}
