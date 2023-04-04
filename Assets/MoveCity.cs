using UnityEngine;
using UnityEngine.EventSystems;

public class MoveCity : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        NaverMapLoader.Instance.latitude = 37.5665f; // 새로운 위도 값
        NaverMapLoader.Instance.longitude = 126.9780f; // 새로운 경도 값
        NaverMapLoader.Instance.zoomLevel = 14;
        NaverMapLoader.Instance.StartLoadingMapImage();
    }
}

