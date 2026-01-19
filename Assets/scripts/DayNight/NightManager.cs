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

    [SerializeField] private GameObject dayCity;
    [SerializeField] private GameObject nightCity;

    [SerializeField] private GameObject dayAlley;
    [SerializeField] private GameObject nightAlley;
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
            //activate night city image and deactivate day city image
            dayCity.gameObject.SetActive(false);
            nightCity.gameObject.SetActive(true);
            dayWindowLigt1.gameObject.SetActive(false);
            dayWindowLigt2.gameObject.SetActive(false);
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
