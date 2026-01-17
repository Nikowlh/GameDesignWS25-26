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

    [SerializeField] private GameObject dayCity;
    [SerializeField] private GameObject nightCity;
    public void Start()
    {
        skybox.gameObject.SetActive(false);
        stehlampe.enabled = false;
        Tischlampe.enabled = false;
        RenderSettings.skybox = daySkyboxMaterial;
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
        }
        else
        {
            stehlampe.enabled = false;
            Tischlampe.enabled = false;
            skybox.gameObject.SetActive(false);
        }
    }
}
