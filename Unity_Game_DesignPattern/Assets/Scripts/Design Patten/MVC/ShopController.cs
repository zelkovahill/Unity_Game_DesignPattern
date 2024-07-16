using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DesignPattern
{

public class ShopController : MonoBehaviour
{
    public ShopView shipView;
    public Item currentItem;
    
    // 상점 초기화 메서드
    public void InitializeShop()
    {
        // 데이터베이스나 다른 소스에서 아이템 데이터를 로드
        currentItem = new Item { Name = "검", Price = 100 };
        
        // 현재 아이템으로 UI 업데이트
        shipView.UpdateUI(currentItem);
    }
    
    // 아이템 구매 버튼 클릭 시 호출되는 메서드
    public void BuyItem()
    {
        // // 플레이어의 통화량을 확인
        // int playerCurrency = GetPlayerCurrency();   // 플레이어의 통화량을 가져오는 메서드
        //
        // if (playerCurrency >= currentItem.Price)
        // {
        //     // 아이템 가격을 플레이어의 통화량에서 차감
        //     playerCurrency -= currentItem.Price;
        //     UpdatePlayerCurrency(playerCurrncy);    // 플레이어의 통화량을 업데이트하는 메서드
        //     
        //     // 아이템을 플레이어의 인벤토리에 추가
        //     AddItemToInventory(currentItem);
        //     
        //     print("아이템을 구매했습니다.");
        // }
        // else
        // {
        //     print("통화량이 부족합니다.");
        // }
    }
}
}