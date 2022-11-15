using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public enum HouseType
{
    FLAT,
    TERRACED,
    SEMIDETACHED,
    DETACHED
}

public class Suburb : MonoBehaviour
{
    public HouseType houseType;

    public float minHousePrice;
    public float maxHousePrice;
    public float housePrice = 0;

    [SerializeField] private SpriteRenderer sprite;

    [SerializeField] private Slider yearSlider;

    void Start()
    {
        /*switch (houseType)
        {
            case HouseType.FLAT:
                housePrice = 1;
                break;
            case HouseType.TERRACED:
                housePrice = 2;
                break;
            case HouseType.SEMIDETACHED:
                housePrice = 3;
                break;
            case HouseType.DETACHED:
                housePrice = 4;
                break;
            default:
                Debug.LogWarning("Incorrect house type");
                break;
        }*/

        sprite = this.GetComponent<SpriteRenderer>();
        yearSlider.onValueChanged.AddListener(delegate { OnYearChange(); });

        // HOUSE PRICES
        List<float> housePrices = new List<float>();
        for (int cityIndex = 0; cityIndex < DataManager.instance.salariesPerCity.Count; cityIndex++)
        {
            for (int yearIndex = 2010; yearIndex <= 2020; yearIndex++)
            {
                float[] salaryPerHouseTypes;
                if (DataManager.instance.salariesPerCity[cityIndex].TryGetValue(yearIndex, out salaryPerHouseTypes))
                {
                    for (int houseTypeIndex = 0; houseTypeIndex < salaryPerHouseTypes.Length; houseTypeIndex++)
                    {
                        housePrices.Add(salaryPerHouseTypes[houseTypeIndex]);
                    }
                }
            }
        }

        // MIN HOUSE PRICE
        minHousePrice = housePrices[0];
        for (int i = 0; i < housePrices.Count; i++)
        {
            if (housePrices[i] < minHousePrice)
            {
                minHousePrice = housePrices[i];
            }
        }

        // MAX HOUSE PRICE
        maxHousePrice = housePrices[0];
        for (int i = 0; i < housePrices.Count; i++)
        {
            if (housePrices[i] > maxHousePrice)
            {
                maxHousePrice = housePrices[i];
            }
        }

        SetHousePrice(2010);
    }

    public void SetColourByPrice()
    {
        float colourValue = ((housePrice - minHousePrice) / (maxHousePrice - minHousePrice));
        sprite.color = new Color(colourValue, 1 - colourValue, 0);
    }

    public void SetHousePrice(int year)
    {
        float[] salaryPerHouseTypes;
        if (DataManager.instance.salariesPerCity[this.GetComponentInParent<City>().cityIndex].TryGetValue(year, out salaryPerHouseTypes))
        {
            housePrice = salaryPerHouseTypes[(int)houseType];
        }

        SetColourByPrice();
    }

    private void OnYearChange()
    {
        SetHousePrice((int)yearSlider.value);
    }

    void Update()
    {
        
    }
}
