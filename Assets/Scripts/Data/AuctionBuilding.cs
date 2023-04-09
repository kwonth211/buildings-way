
// 경매 건물 클래스: 건물 위치, 건물 좌표, 건물 층수, 건물 면적, 건물 가격 등 건물 관련 정보를 포함합니다.
using UnityEngine;

public class AuctionBuilding
{
    public string Location { get; set; }
    public Vector2 Coordinates { get; set; }
    public int Floors { get; set; }
    public float Area { get; set; }
    public float Price { get; set; }
}
