using UnityEngine;

public class BeerScript : MonoBehaviour, ImInteractible
{
    // Array of beer prefabs to choose from
    [SerializeField] private GameObject[] beerPrefabs;


    [SerializeField] private string prompt;
    public string InteractionPrompt => prompt;

    [SerializeField] private GameObject beerInHand;
    [SerializeField] private GameObject DrinkingPivot;


    //Method to deaktivate one beer of the array
    private void DeaktivateRandomBeer()
    {
        if (!beerInHand.activeSelf)
        {

            if (beerPrefabs.Length == 0)
            {

                int randomIndex = Random.Range(0, beerPrefabs.Length);
                beerPrefabs[randomIndex].SetActive(false);
            }
            else
            {
                return;
            }
        }
    }

  
    public bool Interactor(Interactor interactor)
    {

        // Activate the beer in hand and deaktivate a random beer from the array
        beerInHand.SetActive(true);
        DeaktivateRandomBeer();



        return true;
    }
}
