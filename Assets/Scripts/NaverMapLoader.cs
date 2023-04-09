using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NaverMapLoader : MonoBehaviour
{
    public RawImage mapImage;
    private string baseUrl = "https://naveropenapi.apigw.ntruss.com/map-static/v2/raster?";
    private string clientId = "dzstyznkwx";
    private string clientSecret = "E42omnDMVF3tVFAGiAVXMcW1Obyq2LBQY012cn4q";
    public float latitude = 37.3591614f;
    public float longitude = 127.1054221f;
    public int width = 800;
    public int height = 600;
    public string format = "png";
    public float zoomSpeed = 0.5f;
    public float panSpeed = 1.0f;

    private float initialPinchDistance;

    public int minZoomLevel = 10;
    public int maxZoomLevel = 20;

    // zoomLevel 이 클수록 확대
    public float zoomLevel = 15;
    private Vector3 _lastMousePosition;
    private bool _isPinching;
    public bool isCity = false;

    private Vector2 _initialTouchPosition;


    private Vector2 _initialMapPosition;

    public static NaverMapLoader Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        StartLoadingMapImage();
    }

    private void Update()
    {
        if(!isCity)
        {
            return;
        }

        // 핀치 제스처 시뮬레이션
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightMeta))
        {
            if (!_isPinching)
            {
                _isPinching = true;
                HandleTouchInput(TouchPhase.Began);
            }

            float scrollDelta = Input.mouseScrollDelta.y;
            if (scrollDelta != 0)
            {
                HandleTouchInput(TouchPhase.Moved, scrollDelta: scrollDelta);
            }
        }
        else
        {
            if (_isPinching)
            {
                _isPinching = false;
                HandleTouchInput(TouchPhase.Ended);
            }
        }

        // 드래그 제스처 시뮬레이션
        if (Input.GetMouseButtonDown(0))
        {
            _lastMousePosition = Input.mousePosition;
            _initialMapPosition = mapImage.rectTransform.anchoredPosition;
            HandleTouchInput(TouchPhase.Began);
        }
        else if (Input.GetMouseButton(0) && !_isPinching)
        {

            _initialMapPosition = mapImage.rectTransform.anchoredPosition;
            Vector3 delta = Input.mousePosition - _lastMousePosition;
            HandleTouchInput(TouchPhase.Moved, delta: delta);
            _lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            HandleTouchInput(TouchPhase.Ended);
        }
    }

    private void HandleTouchInput(TouchPhase touchPhase, float scrollDelta = 0, Vector3 delta = default(Vector3))
    {

        if (touchPhase == TouchPhase.Began)
        {
            if (_isPinching)
            {
                // zoomLevel = zoomLevel;
            }
            else
            {
                _initialMapPosition = mapImage.rectTransform.anchoredPosition;
                _initialTouchPosition = delta;
            }
        }
        else if (touchPhase == TouchPhase.Moved)
        {
            if (_isPinching)
            {
                // 핀치 제스처 처리
                float newZoomLevel = zoomLevel + scrollDelta * zoomSpeed;
                newZoomLevel = Mathf.Clamp(newZoomLevel, minZoomLevel, maxZoomLevel);
                zoomLevel = (int)newZoomLevel;
                StartCoroutine(LoadMapImage());
                StartLoadingMapImage();
            }
            else
            {
                // 드래그 제스처 처리
                UpdateMapPosition(delta);
                

            }
        }
        else if (touchPhase == TouchPhase.Ended)
        {
            if (_isPinching)
            {
                // 핀치 제스처 종료 처리
                StartLoadingMapImage();
            }
            else
            {
                // 드래그 제스처 종료 처리
            }
        }
    }

    private IEnumerator LoadMapImage()
    {
        // 이쪽 변경
        string url = $"{baseUrl}w={width}&h={height}&center={longitude},{latitude}&level={zoomLevel}";

        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(url))
        {
            www.SetRequestHeader("X-NCP-APIGW-API-KEY-ID", clientId);
            www.SetRequestHeader("X-NCP-APIGW-API-KEY", clientSecret);

            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(www);
                mapImage.texture = texture;
            }
        }
    }

    public void StartLoadingMapImage()
    {
        StartCoroutine(LoadMapImage());
    }

    private void UpdateMapZoomLevel()
    {

        StartLoadingMapImage();
    }

    private void UpdateMapPosition(Vector2 deltaPosition)
    {

        Vector2 newPosition = _initialMapPosition + new Vector2(deltaPosition.x, deltaPosition.y) * panSpeed;
        mapImage.rectTransform.anchoredPosition = newPosition;

        // StartLoadingMapImage();
    }

    private void UpdateCenterCoordinates(Vector2 deltaPosition)
    {
        float latitudeDelta = deltaPosition.y * (180 / Mathf.Pow(2, zoomLevel) * mapImage.rectTransform.rect.height / 256);
        float longitudeDelta = deltaPosition.x * (360 / Mathf.Pow(2, zoomLevel) * mapImage.rectTransform.rect.width / 256);
        latitude -= latitudeDelta;
        longitude -= longitudeDelta;
    }

}

