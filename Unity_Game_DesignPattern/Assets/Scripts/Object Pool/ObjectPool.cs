using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 오브젝트 풀 패턴

// 개선 방안
// 정적 또는 싱글톤으로 설정
// 다양한 소스에서 풀링된 오브젝트를 생성해야 하는 경우에는 오브젝트 풀을 정적으로 설정해 보세요.
// 그러면 애플리케이션의 어디에서든 액세스할 수 있으나, 인스펙터 사용은 불가능해요.
// 또는 오브젝트 풀 패턴을 싱글톤으로 설정하면 어디에서든 액세스하여 간편하게 사용할 수 있어요.

// 딕셔너리로 다수의 풀 관리
// 많은 수의 다양한 프리팹을 풀링해야 하는 경우, 개별적인 풀에 저장하고 키 값 페어를 저장하면 쿼리할 풀을 알 수 있어요
// 프리팹의 InstanceID는 고유 키로 작동할 수 있어요.

// 사용되지 않는 게임 오븍젝트를 창의적으로 제거
// 오브젝트 풀을 효과적으로 활용하는 방법 중 하나는 사용되지 않는 오브젝트를 숨기고 풀로 반환한 것 입니다.
// 가능한 기회를 모두 활용해 풀링된 오브젝트(화면 바깥에 있거나 폭발에 의해 숨겨진 오브젝트 등)를 비활성화하세요.

// 오류 확인
// 이미 풀에 있는 오브젝트를 릴리스하지 마세요. 런타임에서 오류가 발생할 수 있어요.

// 최대 크기/제한 추가
// 풀링된 오브젝트가 많으면 메모리를 소모를 해요.
// 풀이 너무 많은 리소스를 사용하지 않도록 특정 한도를 초과하는 오브젝트를 제거해야 할 수 있어요.


public class ObjectPool : MonoBehaviour
{
    [SerializeField] private uint initPoolSize;
    [SerializeField] private PooledObject objectToPool;
    
    // 풀링된 오브젝트를 컬렉션에 저장
    private Stack<PooledObject> stack;
    
    private void Start()
    {
        SetupPool();
    }
    
    // 풀 생성(지연을 인지할 수 없을 때 호출
    private void SetupPool()
    {
        stack = new Stack<PooledObject>();
        PooledObject instance = null;

        for (int i = 0; i < initPoolSize; i++)
        {
            instance = Instantiate(objectToPool);
            instance.Pool = this;
            instance.gameObject.SetActive(false);
            stack.Push(instance);
        }
    }
    
    // 풀에서 첫 번째 액티브 게임 오브젝트를 반환 합니다.
    public PooledObject GetPooledObject()
    {
        //풀이 충분히 크지 않으면 새로운 PooledObjects를 인스턴스화 합니다.
        if (stack.Count == 0)
        {
            PooledObject newInstance = Instantiate(objectToPool);
            newInstance.Pool = this;
            return newInstance;
        }
        
        // 그렇지 않으면 목록에서 다음 항목을 가져옵니다.
        PooledObject nextInstance = stack.Pop();
        nextInstance.gameObject.SetActive(true);
        return nextInstance;
    }
    
    public void ReturnToPool(PooledObject pooledObject)
    {
        stack.Push(pooledObject);
        pooledObject.gameObject.SetActive(false);
    }

}

public class PooledObject : MonoBehaviour
{
    private ObjectPool pool;
    public ObjectPool Pool
    {
        get => pool;
        set => pool = value;
    }

    public void Release()
    {
        pool.ReturnToPool(this);
    }
}

