using System;
using System.Drawing;
using System.Linq;

namespace Forms
{
    [Serializable]
    public class CellData
    {
        public int[] Genome { get; private set; }
        public Color CellColor { get; private set; }

        public CellData() : this(null) { }

        public CellData(int[] genome)
        {
            if (genome != null && genome.Length == 9)
            {
                Genome = (int[])genome.Clone();
            }
            else
            {
                Genome = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            }
            UpdateColor();
        }

        public void SetGenome(int[] newGenome)
        {
            if (newGenome != null && newGenome.Length == 9)
            {
                Genome = (int[])newGenome.Clone();
                UpdateColor();
            }
        }

        private void UpdateColor()
        {
            float rSum = (Genome[0] + Genome[1]) / 2.0f;
            float gSum = (Genome[2] + Genome[3]) / 2.0f;
            float bSum = (Genome[4] + Genome[5] + Genome[6] + Genome[7] + Genome[8]) / 5.0f;

            int red = (int)(rSum * 255);
            int green = (int)(gSum * 255);
            int blue = (int)(bSum * 255);

            if (red == 0 && green == 0 && blue == 0 && Genome.All(g => g == 0))
            {
                CellColor = Color.Black;
            }
            else if (red == 0 && green == 0 && blue == 0)
            {
                CellColor = Color.DimGray;
            }
            else
            {
                CellColor = Color.FromArgb(
                    Math.Max(0, Math.Min(255, red)),
                    Math.Max(0, Math.Min(255, green)),
                    Math.Max(0, Math.Min(255, blue))
                );
            }
        }
    }
}