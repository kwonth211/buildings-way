
// 경매 건물 클래스: 건물 위치, 건물 좌표, 건물 층수, 건물 면적, 건물 가격 등 건물 관련 정보를 포함합니다.
using UnityEngine;

public class AuctionBuilding
{
    // 사건 번호
    public int CaseNumber { get; set; }
    // 물건 번호
    public int ItemNumber { get; set; }
    // 건물 이름
    public string Name { get; set; }
    // 건물 설명
    public string Description { get; set; }
    // 건물 주소
    public string Address { get; set; }
    // 건물 좌표
    public Vector2 Coordinates { get; set; }
    // 건물 층수
    public int Floors { get; set; }

    // 건물 면적
    public float Area { get; set; }
    // 건물 가격
    public float Price { get; set; }
    // 경매 날짜
    public string AuctionDate { get; set; }
    // 시작 가격
    public float StartPrice { get; set; }

    // 최저 가격
    public float MinPrice { get; set; }

    // 낙찰가 예측
    public float PredictedPrice { get; set; }


}
