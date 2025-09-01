using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Forms
{
    [Serializable]
    public class Universe
    {
        public Dictionary<(int, int), CellData> cells = new Dictionary<(int, int), CellData>();
        public int Generation { get; set; } = 0;

        public int MinX { get; private set; } = 0;
        public int MinY { get; private set; } = 0;
        public int MaxX { get; private set; } = 10;
        public int MaxY { get; private set; } = 10;

        private Random random = new Random();

        public bool GetCellState(int x, int y) => cells.ContainsKey((x, y));

        public void SetCellState(int x, int y, bool isAlive, int[] initialGenome = null)
        {
            ExpandBounds(x, y);
            var position = (x, y);

            if (isAlive)
            {
                if (!cells.ContainsKey(position))
                {
                    cells[position] = new CellData(initialGenome);
                }
            }
            else
            {
                cells.Remove(position);
            }
        }

        public void Step()
        {
            var boardForMovement = new Dictionary<(int, int), CellData>(cells);
            var movementRecord = new Dictionary<CellData, ((int, int) finalPos, int turnIndex)>();
            int turnIndex = 0;
            var cellsToProcessMovement = cells.ToList();

            for (int i = cellsToProcessMovement.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                var temp = cellsToProcessMovement[i];
                cellsToProcessMovement[i] = cellsToProcessMovement[j];
                cellsToProcessMovement[j] = temp;
            }

            foreach (var cellEntry in cellsToProcessMovement)
            {
                turnIndex++;
                var originalPosition = cellEntry.Key;
                var cell = cellEntry.Value;

                if (!boardForMovement.TryGetValue(originalPosition, out var currentCellOnBoard) || !ReferenceEquals(currentCellOnBoard, cell))
                {
                    var foundEntry = boardForMovement.FirstOrDefault(kvp => ReferenceEquals(kvp.Value, cell));
                    if (foundEntry.Value != null)
                    {
                        movementRecord[cell] = (foundEntry.Key, turnIndex);
                    }
                    continue;
                }


                List<(int, int)> attractiveEmptySpots = new List<(int, int)>();

                for (int dx = -1; dx <= 1; dx++)
                {
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        if (dx == 0 && dy == 0) continue;
                        var potentialSpot = (originalPosition.Item1 + dx, originalPosition.Item2 + dy);

                        if (!boardForMovement.ContainsKey(potentialSpot))
                        {
                            int emptySpotNeighborCount = 0;
                            for (int ndx = -1; ndx <= 1; ndx++)
                            {
                                for (int ndy = -1; ndy <= 1; ndy++)
                                {
                                    if (ndx == 0 && ndy == 0) continue;
                                    if (boardForMovement.ContainsKey((potentialSpot.Item1 + ndx, potentialSpot.Item2 + ndy)))
                                    {
                                        emptySpotNeighborCount++;
                                    }
                                }
                            }

                            if (emptySpotNeighborCount >= 0 && emptySpotNeighborCount < cell.Genome.Length && cell.Genome[emptySpotNeighborCount] == 1)
                            {
                                attractiveEmptySpots.Add(potentialSpot);
                            }
                        }
                    }
                }

                (int, int) finalPositionForThisCell = originalPosition;
                if (attractiveEmptySpots.Any())
                {
                    var chosenSpot = attractiveEmptySpots[random.Next(attractiveEmptySpots.Count)];
                    boardForMovement.Remove(originalPosition);
                    boardForMovement[chosenSpot] = cell;
                    finalPositionForThisCell = chosenSpot;
                }
                movementRecord[cell] = (finalPositionForThisCell, turnIndex);
            }

            var nextGenerationCells = new Dictionary<(int, int), CellData>();
            var cellsToConsiderForBirthDeath = new HashSet<(int, int)>();

            if (!boardForMovement.Any())
            {
                cells = nextGenerationCells;
                Generation++;
                MinX = 0; MinY = 0; MaxX = 10; MaxY = 10;
                return;
            }

            foreach (var cellPos in boardForMovement.Keys)
            {
                for (int dx = -1; dx <= 1; dx++)
                {
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        cellsToConsiderForBirthDeath.Add((cellPos.Item1 + dx, cellPos.Item2 + dy));
                    }
                }
            }

            foreach (var pos in cellsToConsiderForBirthDeath)
            {
                int count = 0;
                for (int dx = -1; dx <= 1; dx++)
                {
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        if (dx == 0 && dy == 0) continue;
                        if (boardForMovement.ContainsKey((pos.Item1 + dx, pos.Item2 + dy)))
                        {
                            count++;
                        }
                    }
                }

                bool isCurrentlyAlive = boardForMovement.ContainsKey(pos);

                if (isCurrentlyAlive)
                {
                    if (count == 2 || count == 3)
                    {
                        nextGenerationCells[pos] = boardForMovement[pos];
                    }
                }
                else
                {
                    if (count == 3)
                    {
                        CellData parentWithLastAction = null;
                        int maxTurn = -1;

                        for (int dx = -1; dx <= 1; dx++)
                        {
                            for (int dy = -1; dy <= 1; dy++)
                            {
                                if (dx == 0 && dy == 0) continue;
                                var neighborPos = (pos.Item1 + dx, pos.Item2 + dy);
                                if (boardForMovement.TryGetValue(neighborPos, out var neighborCell))
                                {
                                    if (movementRecord.TryGetValue(neighborCell, out var record))
                                    {
                                        if (record.turnIndex > maxTurn)
                                        {
                                            maxTurn = record.turnIndex;
                                            parentWithLastAction = neighborCell;
                                        }
                                    }
                                }
                            }
                        }

                        if (parentWithLastAction != null)
                        {
                            nextGenerationCells[pos] = new CellData(parentWithLastAction.Genome);
                        }
                        else
                        {
                            List<CellData> parents = new List<CellData>();
                            for (int dx = -1; dx <= 1; dx++)
                            {
                                for (int dy = -1; dy <= 1; dy++)
                                {
                                    if (dx == 0 && dy == 0) continue;
                                    if (boardForMovement.TryGetValue((pos.Item1 + dx, pos.Item2 + dy), out var p))
                                    {
                                        parents.Add(p);
                                    }
                                }
                            }
                            if (parents.Any())
                            {
                                nextGenerationCells[pos] = new CellData(parents[random.Next(parents.Count)].Genome);
                            }
                            else
                            {
                                nextGenerationCells[pos] = new CellData();
                            }
                        }
                    }
                }
            }

            cells = nextGenerationCells;
            Generation++;

            if (cells.Any())
            {
                MinX = cells.Keys.Min(c => c.Item1);
                MinY = cells.Keys.Min(c => c.Item2);
                MaxX = cells.Keys.Max(c => c.Item1);
                MaxY = cells.Keys.Max(c => c.Item2);
            }
            else
            {
                MinX = 0; MinY = 0; MaxX = 10; MaxY = 10;
            }
        }

        private void ExpandBounds(int x, int y)
        {
            MinX = Math.Min(MinX, x);
            MinY = Math.Min(MinY, y);
            MaxX = Math.Max(MaxX, x);
            MaxY = Math.Max(MaxY, y);
        }

        public void SaveBinary(string filePath)
        {
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, this);
                }
            }
            catch (SerializationException ex)
            {
                MessageBox.Show("Ошибка серилизации: " + ex.Message, "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения: " + ex.Message, "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadBinary(string filePath)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Файл не найден: " + filePath, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Universe loadedUniverseData = null;
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    loadedUniverseData = (Universe)formatter.Deserialize(fs);
                }

                if (loadedUniverseData != null)
                {
                    this.cells = loadedUniverseData.cells ?? new Dictionary<(int, int), CellData>();
                    this.Generation = loadedUniverseData.Generation;
                    this.MinX = loadedUniverseData.MinX;
                    this.MinY = loadedUniverseData.MinY;
                    this.MaxX = loadedUniverseData.MaxX;
                    this.MaxY = loadedUniverseData.MaxY;
                }
            }
            catch (SerializationException ex)
            {
                MessageBox.Show("Ошибка десериализации: " + ex.Message + "\nФайл может быть поврежденным, либо неподходящим.", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.cells.Clear();
                this.Generation = 0;
                this.MinX = 0; this.MinY = 0; this.MaxX = 10; this.MaxY = 10;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки: " + ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}