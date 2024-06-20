using UnityEngine;

// 개방폐쇄의 원칙 (Open Close Principle)
// 새로운 다각형이 필요할 때마다 Shape에서 상속하는 새 클래스를 정의하면 되요.
// 각각의 서브 클래스 셰이프는 CalculateArea 메서드를 오버라이드하여 올바른 영역을 반환해요.

// 이 디자인을 사용하면 디버깅하기도 더 쉬워요.
// 새로운 셰이프로 오류가 발생하더라도 AreaCalculator를 재검토할 필요가 없어요.
// 기존 코드가 변경 없이 유지되므로, 새 코드에만 잘못된 로직이 있는지 조사하면 되요.

// Unity에서 새로운 클래스를 만들 때 인터페이스와 추상화를 활용해보세요.
// 이렇게 하면 나중에 확장하기 까다로운 switch문 또는 if문을 로직에 넣지 않아도 되요.
// OCP에 맞춰 클래스르 설정하는 데 익숙해지면 장기적으로 새로운 코드를 더 간편하게 추가할 수 있게 되요.

public abstract class Shape
{
    public abstract float CalculateArea();
}

public class Rectangle : Shape
{
    public float width;
    public float height;
    
    public override float CalculateArea()
    {
        return width * height;
    }
}

public class Circle : Shape
{
    public float radius;
    
    public override float CalculateArea()
    {
        return radius * radius * Mathf.PI;
    }
}

public class AreaCalculator
{
    public float GetArea(Shape shape)
    {
        return shape.CalculateArea();
    }
}