using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;



// UnityEngine.Pool
// Unity 2021 부터는 자체 API를 지원해요.
// 오브젝트 풀 패턴을 가지는 오브젝트를 추적하기 위한 스택 기반 ObjectPool을 제공해요.
// 필요에 따라 CollectionPool(List,HashSet,Dictionary)도 사용할 수 있어요.

public class RevisedGun : MonoBehaviour
{
   [SerializeField] private RevisedProjectile projectilePrefab;
   
   // Unity 2021 이상 버전에서 사용 가능한 스택 기반 ObjectPool
   private IObjectPool<RevisedProjectile> objectPool;
   
   // 이미 풀에 있는 기존 항목을 반환하려 할 때 예외를 반환
   [SerializeField] private bool collectionCheck = true;
   
   // 풀의 용량과 최대 크기를 제어하는 추가 옵션
   [SerializeField] private int defaultCapacity = 20;
   [SerializeField] private int maxSize = 100;

   private void Awake()
   {
      objectPool = new ObjectPool<RevisedProjectile>
      (CreateProjectile, OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject, collectionCheck, defaultCapacity,
         maxSize);

   }
   
   // 오브젝트 풀을 채울 항목을 만들 때 호출됨
   private RevisedProjectile CreateProjectile()
   {
      RevisedProjectile projectileInstance = Instantiate(projectilePrefab);
      projectileInstance.ObjectPool = objectPool;
      return projectileInstance;
   }
   
   // 오브젝트 풀로 항목을 반환할 때 호출됨
   private void OnReleaseToPool(RevisedProjectile pooledObject) 
   {
      pooledObject.gameObject.SetActive(false);
   }
   
   // 오브젝트 풀에서 다음 항목을 검색할 때 호출됨
   private void OnGetFromPool(RevisedProjectile pooledObject) 
   {
      pooledObject.gameObject.SetActive(true);
   }
   
   // 풀링된 항목의 최대 개수를 초과할 때 호출됨(풀링된 오브젝트 파괴)
   private void OnDestroyPooledObject(RevisedProjectile pooledObject) 
   {
      Destroy(pooledObject.gameObject);
   }
   private void FixedUpdate()
   {
      
   }

   
   
   
}


public class RevisedProjectile : MonoBehaviour
{
   private IObjectPool<RevisedProjectile> objectPool;
   
   // 발사체에 ObjectPool에 대한 레퍼런스를 제공하는 공용 프로퍼티
   public IObjectPool<RevisedProjectile> ObjectPool
   {
      set => objectPool = value;
   }
}
