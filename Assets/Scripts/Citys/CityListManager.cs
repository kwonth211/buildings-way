using UnityEngine;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class CityListManager : MonoBehaviour
{
    public GameObject cityItemPrefab;
    public TextAsset jsonFile; // JSON 파일을 불러오기 위한 변수

    private void Start()
    {
        LoadCities();
    }

    public void LoadCities()
    {
        List<City> cities = GetCities();

        foreach (City city in cities)
        {
            GameObject cityItemInstance = Instantiate(cityItemPrefab, transform);
            CityItem cityItem = cityItemInstance.GetComponent<CityItem>();
            cityItem.SetCityData(city);
        }
    }

    private List<City> GetCities()
    {
        string jsonString = jsonFile.text;

        List<City> cities = JsonConvert.DeserializeObject<List<City>>(jsonString);

        return cities;
    }


}