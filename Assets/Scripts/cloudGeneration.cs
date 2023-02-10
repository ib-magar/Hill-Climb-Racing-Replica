using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class cloudGeneration : MonoBehaviour
{

    [SerializeField] GameObject _cloudPrefab;
    [SerializeField] float radius;
    [SerializeField] int cloudsAmount;
    [SerializeField] float _updateTime;
    [SerializeField] LayerMask _cloudMask;
    [SerializeField] Transform parent;
    private Transform _carPosition;
    [SerializeField] Vector3 _offset;

    
    private void Start()
    {
        _carPosition = transform;
        StartCoroutine(checkClouds());
    }

    IEnumerator checkClouds()
    {
        while(true)
        {
            Vector3 position = _carPosition.position + _offset;
            Collider2D[] _clouds = Physics2D.OverlapCircleAll(position, radius, _cloudMask);
            if(_clouds.Length<cloudsAmount)
            {
                int remainingCloudsAmount=cloudsAmount-_clouds.Length;
                for(int i=0;i<remainingCloudsAmount;i++)
                {
                    Instantiate(_cloudPrefab,position+ Random.insideUnitSphere * radius, Quaternion.identity, parent);
                }
            }
            yield return new WaitForSeconds(_updateTime);
        }
    }
  
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position+_offset, radius);
    }

}
