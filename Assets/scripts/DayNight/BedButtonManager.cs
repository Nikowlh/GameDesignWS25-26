using UnityEngine;
using UnityEngine.UI;
public class BedButtonManager : MonoBehaviour
{
    [SerializeField] Canvas bedMenu;
    [SerializeField] private FBPlayer player;
    [SerializeField] private NightManager nightManager;
    public void BedCancel()
    {
        
        bedMenu.gameObject.SetActive(false);
       
        player.FreezePlayer(false);
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    public void SleepTillNight()
        {
        
        nightManager.SetNight(true);
        
        bedMenu.gameObject.SetActive(false);
        player.FreezePlayer(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
