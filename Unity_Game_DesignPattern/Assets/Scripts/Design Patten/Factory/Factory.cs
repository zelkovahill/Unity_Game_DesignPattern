using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Factory 패턴
// 장점 : 많은 제품을 설정할 때 가장 유용해요.
// 애플리케이션에서 제품 유형을 새로 정의하더라도 기존 유형이 변경되지 않으며, 이전 코드를 수정할 필요가 없어요.
// 각 제품의 내부 로직을 제품 자체 클래스 내부에 두면 공장 코드를 비교적 짧게 유지할 수 있어요.
// 각 공장은 제품별로 Initialize를 호출하는 방법만 알고 기본적인 세부 사항은 알지 못해요.

// 단점 : 다수의 클래스와 서브 클래스를 만들어야 해요.
// 다른 패턴과 마찬가지로 이로 인해 약간의 오버헤드가 발생하며, 이는 매우 다양한 제품이 필요하지 않다면 없어도 되는 오버헤드예요.

// 개선 방안
// 딕셔너리를 사용하여 제품검색 
// 제품을 키 값 페어로 딕셔너리에 저장하는 것이 좋아요.
// 고유한 문자열 식별자(이름 또는 ID 등)를 키로 사용하고 유형을 값으로 사용하세요.
// 그러면 제품 또는 제품의 공장을 더 편리하게 검색할 수 있어요.

// 공장(또는 공장 관리자)을 정적 클래스로 설정
// 이렇게  하면 사용은 더 쉽지만 추가 설징이 필요해요.
// 정적 클래스는 인스펙터에 표시되지 않으므로 제품의 컬렉션도 정적으로 만들어야 해요.

// 오브젝트 풀 패턴과 결합
// 공장이 반드시 새로운 오브젝트를 인스턴스화하거나 만들어야 하는 것은 아니예요.
// 계층 구조에 있는 기존의 오브젝트를 검색할 수도 있어요.
// 많은 오브젝트를 한 번에 인스턴스화하는 경우 (예: 무기에서 발사되는 발사체), 오브젝트 풀링 패턴을 활용하여 메모리 관리를 더 최적화 하세요.

// 공장은 필요한 모든 게임플레이 요소를 생성할 수 있어요.
// 하지만 공장의 목적이 제품생성에만 한정되지 않는 경우가 많아요.
// 팩토리 패턴을 다른 더 큰 작업(예 : 게임 레벨의 일부인 다이얼로그 상자의 UI 요소 설정)의 일부로 사용할 수 있어요.

namespace DesignPattern
{

public interface IProduct
{
    public string ProductName { get; set; }
    public void Initialize();
}

public abstract class Factory : MonoBehaviour
{
    public abstract IProduct GetProduct(Vector3 position);
    
    // 모든 공장이 공유하는 메서드
}


public class ProductA : MonoBehaviour, IProduct
{
    [SerializeField] private string productName = "Product A";
    public string ProductName {get => productName; set => productName = value; }
    
    private ParticleSystem particleSystem;

    public void Initialize()
    {
        // 이 제품에 대한 모든 고유 로직
        gameObject.name = productName;
        particleSystem = GetComponentInChildren<ParticleSystem>();
        particleSystem?.Stop();
        particleSystem?.Play();
    }
}

public class ConcreteFactoryA : Factory
{
    [SerializeField] private ProductA productPrefab;


    public override IProduct GetProduct(Vector3 position)
    {
        // 프리팹 인스턴스를 생성하고 제품 컴포넌트 가져오기
        GameObject instance = Instantiate(productPrefab.gameObject,position,Quaternion.identity);
        ProductA newProduct = instance.GetComponent<ProductA>();
        
        // 각 제품에 자체 로직 포함
        newProduct.Initialize();

        return newProduct;
    }
}
}