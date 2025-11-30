using UnityEngine;
using UnityEngine.InputSystem;

public class DrinkingBeer : MonoBehaviour
{
    [SerializeField] private GameObject beerInHand;
    // new input system action for drinking
    [SerializeField] private InputAction drinkAction;

    private void OnEnable()
    {
        drinkAction.performed += OnDrink;
        drinkAction.Enable();
    }
public void OnDisable()
    {
        drinkAction.performed -= OnDrink;
        drinkAction.Disable();
    }
    private void OnDrink(InputAction.CallbackContext context)
    {
        DrinkBeer();
    }

    public void DrinkBeer()
    {
        if (beerInHand.activeSelf)
        {
            // Logic for drinking the beer
            Debug.Log("Drinking the beer...");
            beerInHand.SetActive(false);
        }
        else
        {
            Debug.Log("No beer in hand to drink.");
        }
    }
    private void OnDestroy()
    {
        drinkAction.performed -= OnDrink;
        drinkAction.Disable();
    }

}
