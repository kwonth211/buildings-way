using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CityItem : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public Image[] stars;

    public void SetCityData(City city)
    {
        Debug.Log(city.Name);
        nameText.text = city.Name;
        descriptionText.text = city.Feature;

        int starCount = city.Rating;
        Color filledStarColor = new Color32(255, 212, 59, 255); // FFD43B
        Color unfilledStarColor = new Color32(83, 101, 125, 255); // 53657D

        for (int i = 0; i < 5; i++)
        {
            if (i < starCount)
            {
                stars[i].color = filledStarColor;
            }
            else
            {
                stars[i].color = unfilledStarColor;
            }
        }
    }
}
