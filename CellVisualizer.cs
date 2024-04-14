using UnityEngine;
using oompe.lib;


namespace game 
{
    public class CellVisualizer : MonoBehaviour
    {
        private Population population;
        private GameObject visualizerRoot;

        public void Initialize(Population population, GameObject root)
        {
            this.population = population;
            this.visualizerRoot = root;

            if (population == null)
                Debug.LogError("Population is null!");

            Visualize();
        }

        public void Visualize()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            for (int x = 0; x < population.Width; x++)
            {
                for (int y = 0; y < population.Height; y++)
                {
                    CellAliveOrDead state = population.GetCellAliveOrDead(x, y);

                    float cellSize = 1f;
                    Rectangle cellRectangle = new Rectangle(visualizerRoot, x * cellSize, y * cellSize, cellSize, cellSize);

                    cellRectangle.SetColor(state == CellAliveOrDead.Alive ? Color.green : Color.magenta);

                    cellRectangle.Draw();
                }
            }
        }

        
    }
}
