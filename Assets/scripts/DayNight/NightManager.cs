using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class NightManager : MonoBehaviour
{
 
    
    public bool isNight = false;
    public GameObject skybox;
    [SerializeField] private Light stehlampe;
    [SerializeField] private Light Tischlampe;
    [SerializeField] private Material nightSkyboxMaterial;
    [SerializeField] private Material daySkyboxMaterial;

    [SerializeField] private GameObject dayWindowLigt1;
    [SerializeField] private GameObject dayWindowLigt2;
    [SerializeField] private GameObject dayWindowLigt3;
    [SerializeField] private GameObject dayWindowLigt4;

    [SerializeField] private GameObject dayCity;
    [SerializeField] private GameObject nightCity;

    [SerializeField] private GameObject dayAlley;
    [SerializeField] private GameObject nightAlley;

    [SerializeField] private GameObject dayPark;
    [SerializeField] private GameObject nightPark;

    [SerializeField] private GameObject dayParkbank;
    [SerializeField] private GameObject nightParkbank;

    [SerializeField] private GameObject dayBar;
    [SerializeField] private GameObject nightBar;

    [SerializeField] private GameObject endBildschirm;


    public void Start()
    {
        skybox.gameObject.SetActive(false);
        stehlampe.enabled = false;
        Tischlampe.enabled = false;
        RenderSettings.skybox = daySkyboxMaterial;
        dayCity.gameObject.SetActive(true);
        nightCity.gameObject.SetActive(false);
        dayWindowLigt1.gameObject.SetActive(true);
        dayWindowLigt2.gameObject.SetActive(true);
        dayPark.gameObject.SetActive(true);
        nightPark.gameObject.SetActive(false);
        dayAlley.gameObject.SetActive(true);
        nightAlley.gameObject.SetActive(false);
        dayParkbank.gameObject.SetActive(true);
        nightParkbank.gameObject.SetActive(false);
        dayWindowLigt3.gameObject.SetActive(true);
        dayWindowLigt4.gameObject.SetActive(true);
        dayBar.gameObject.SetActive(true);
        nightBar.gameObject.SetActive(false);

    }
    public void SetNight(bool night)
    {
     skybox.gameObject.SetActive(true);
        isNight = night;
        if (isNight)
        {
            stehlampe.enabled = true;
            Tischlampe.enabled = true;
            RenderSettings.skybox = nightSkyboxMaterial;
            //activate night and day
            dayCity.gameObject.SetActive(false);
            nightCity.gameObject.SetActive(true);
            dayWindowLigt1.gameObject.SetActive(false);
            dayWindowLigt2.gameObject.SetActive(false);
            dayWindowLigt3.gameObject.SetActive(true);
            dayWindowLigt4.gameObject.SetActive(false);
            dayAlley.gameObject.SetActive(false);
            nightAlley.gameObject.SetActive(true);
            dayPark.gameObject.SetActive(false);
            nightPark.gameObject.SetActive(true);
            dayParkbank.gameObject.SetActive(false);
            nightParkbank.gameObject.SetActive(true);
            dayBar.gameObject.SetActive(false);
            nightBar.gameObject.SetActive(true);

        }
        else
        {
            stehlampe.enabled = false;
            Tischlampe.enabled = false;
            skybox.gameObject.SetActive(false);
            dayCity.gameObject.SetActive(true);
            nightCity.gameObject.SetActive(false);
            dayWindowLigt1.gameObject.SetActive(true);
            dayWindowLigt2.gameObject.SetActive(true);
            dayWindowLigt3.gameObject.SetActive(true);
            dayWindowLigt4.gameObject.SetActive(true);
            dayAlley.gameObject.SetActive(true);
            nightAlley.gameObject.SetActive(false);
            dayPark.gameObject.SetActive(true);
            nightPark.gameObject.SetActive(false);
            dayParkbank.gameObject.SetActive(true);
            nightParkbank.gameObject.SetActive(false);
            dayBar.gameObject.SetActive(true);
            dayBar.gameObject.SetActive(false);


        }
    }
    public void SetDay(bool day)
    {
        isNight = !day;
        if (!isNight)
        {
            stehlampe.enabled = false;
            Tischlampe.enabled = false;
            skybox.gameObject.SetActive(false);
            RenderSettings.skybox = daySkyboxMaterial;
            dayCity.gameObject.SetActive(true);
            nightCity.gameObject.SetActive(false);
            endBildschirm.gameObject.SetActive(true);

        }
        else
        {
            stehlampe.enabled = true;
            Tischlampe.enabled = true;
            skybox.gameObject.SetActive(true);
            RenderSettings.skybox = nightSkyboxMaterial;
            dayCity.gameObject.SetActive(false);
            nightCity.gameObject.SetActive(true);

        }
    }
}
