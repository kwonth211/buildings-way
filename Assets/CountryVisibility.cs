using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryVisibility : MonoBehaviour
{

    void Start()
    {
    }

    void Update()
    {
        bool isCountry = !NaverMapLoader.Instance.isCity;

        if (isCountry)
        {
            gameObject.SetActive(true);

        }
        else
        {


            gameObject.SetActive(false);
        }
    }
}