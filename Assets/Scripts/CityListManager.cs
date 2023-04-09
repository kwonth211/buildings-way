using UnityEngine;
using System.Collections.Generic;

public class CityListManager : MonoBehaviour
{
    public GameObject cityItemPrefab;

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
        List<City> cities = new List<City>
        {
            new City {
                Name= "서울 (Seoul)",
                Feature= "수요 많고 인프라 좋음, 안정적인 투자 선택",
                Rating= 5
            },
            new City {
                Name= "경기 (Gyeonggi)",
                Feature= "수도권 근교 위치, 교통과 인프라가 발달, 부동산 투자에 적합",
                Rating= 4
            },
            new City {
                Name= "부산 (Busan)",
                Feature= "해변가 부동산 인기, 도심도 적극 추천",
                Rating= 4
            },
            new City {
                Name= "인천 (Incheon)",
                Feature= "외국인과 기업 관심 집중, 신도시 활발한 발전",
                Rating= 4
            },
            new City {
                Name= "대구 (Daegu)",
                Feature= "중소규모 아파트, 도심 재개발 가능성",
                Rating= 3
            },
            new City {
                Name= "광주 (Gwangju)",
                Feature= "문화시설과 대학가 인근, 산업단지 발전 가능성",
                Rating= 3
            },
            new City {
                Name="대전 (Daejeon)",
                Feature= "연구기관과 대학들 밀집, 관광과 레저 명소도 다양함",
                Rating= 3
            }
        };


        return cities;
    }
}
