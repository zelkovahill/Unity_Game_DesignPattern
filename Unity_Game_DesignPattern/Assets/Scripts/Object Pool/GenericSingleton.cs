using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// 싱글톤 패턴 (Singleton Pattern)

// 싱글톤은 여러 측면에서 SOLID 원칙을 위반해요.
// 많은 개발자들이 다음과 같은 여러 이유로 싱글톤에 호의적이지 않아요.

// 싱글톤에는 글로벌 액세스가 필요해요.
// 싱글톤은 글로벌 인스턴스로 사용하므로 많은 종속성을 숨길 수 있으며, 이에 따라 훨씬 해결하기 어려운 버그를 유발해요.

// 싱글톤은 테스트를 어렵게 만들어요.
// 유닛 테스트는 반드시 서로 독립적으로 수행해야 해요.
// 싱글톤은 씬 전반에서 많은 게임 오브젝트의 상태를 변경할 수 있으므로 테스팅에 방해가 될 수 있어요.

// 싱글톤은 결합도가 높아지게 만들어요.
// 결합도가 높으면 리팩터링하기가 어려워요.
// 컴포넌트 하나를 변경하면 연결된 컴포넌트에 영향을 줄 수 있으므로 코드가 지저분해질 수 있어요.


// 장점
// 싱글톤은 비교적 빨리 배울 수 있어요.
// 코어 패턴 자체가 다소 직관적이예요.

// 싱글톤은 사용자 친화적이에요.
// 다른 컴포넌트에서 싱글톤을 사용하려 할 때, 공용 및 정적 인스턴스만 참조하면 되요.
// 싱글톤 인스턴스는 필요할 때 씬의 오브젝트에서도 항상 사용할 수 있어요.

// 싱글톤은 성능을 보장해요.
// 정적 싱글톤 인스턴스에 항상 글로벌 액세스가 가능하므로, 속도가 느린 경향이 있는 GetComponent 또는 Find 연산의 결과를 캐시하지 않도 되요.

public class GenericSingleton<T> : MonoBehaviour where T : Component
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));
                if (instance == null)
                {
                    SetupInstance();
                }
            }

            return instance;
        }
    }

    public virtual void Awake()
    {
        RemoveDuplicates();
    }

    private static void SetupInstance()
    {
        instance = (T)FindObjectOfType(typeof(T));

        if (instance == null)
        {
            GameObject gameObj = new GameObject();
            gameObj.name = typeof(T).Name;
            instance = gameObj.AddComponent<T>();
            DontDestroyOnLoad(gameObj);
        }
    }

    private void RemoveDuplicates()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
}

public class GameManager : GenericSingleton<GameManager>
{
    
}
