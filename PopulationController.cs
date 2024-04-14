using UnityEngine;
using game;

public class PopulationController : MonoBehaviour
{
    public float evolutionInterval = 1.0f;
    public int targetGeneration = 1; 

    private Population population;
    private CellVisualizer visualizer;
    private int currentGeneration = 1;

    private void Start()
    {
        population = FindObjectOfType<Population>();

        if (population == null)
            Debug.LogError("Population is null!");
        else
            Debug.Log("Population found!");

        visualizer = GetComponent<CellVisualizer>();

        if (visualizer == null)
            Debug.LogError("Visualizer is null!");
        else
            Debug.Log("Visualizer found!");

        if (visualizer != null)
            visualizer.Initialize(population, this.gameObject);

        else
            Debug.LogError("Visualizer is null!");


        InvokeRepeating(nameof(EvolvePopulation), 0, evolutionInterval);
    }

    private void EvolvePopulation()
    {
        if (currentGeneration <= targetGeneration)
        {
            if (population != null)
                population.Evolve();
            else
                Debug.LogError("Population is null!");

            if (visualizer != null)
                visualizer.Visualize();
            else
                Debug.LogError("Visualizer is null!");

            currentGeneration++;
        }
    }
}
