using Unity;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
public class BedButtonManager : MonoBehaviour
{
    [SerializeField] Canvas bedMenu;
    [SerializeField] private FBPlayer player;
    [SerializeField] private NightManager nightManager;
    [SerializeField] UIInteraction uiInteraction;

    public void BedCancel()
    {
        
        bedMenu.gameObject.SetActive(false);
        uiInteraction.otherUiActive = false;
        player.FreezePlayer(false);
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    public void SleepTillNight()
        {
        
        nightManager.SetNight(true);
        uiInteraction.otherUiActive = false;
        bedMenu.gameObject.SetActive(false);
        player.FreezePlayer(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void throughTheNight()
    {
        nightManager.SetDay(true);
        uiInteraction.otherUiActive = false;
        bedMenu.gameObject.SetActive(false);
        player.FreezePlayer(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Zurück()
    {
        bedMenu.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        player.FreezePlayer(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
