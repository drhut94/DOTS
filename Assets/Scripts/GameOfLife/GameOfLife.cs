using System.Collections.Generic;
using UnityEngine;

namespace GameOfLife
{
    public class GameOfLife : MonoBehaviour
    {
        public int width = 10;
        public int height = 10;
        public int depth = 10;
        public float interval = 1f;
        public GameObject cellPrefab;

        private int[,,] board;
        private Dictionary<Vector3, GameObject> cellMap;

        void Start() {
            board = new int[width, height, depth];
            cellMap = new Dictionary<Vector3, GameObject>();
            InitializeBoard();
            InvokeRepeating("UpdateBoard", interval, interval);
        }

        void InitializeBoard() {
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    for (int z = 0; z < depth; z++) {
                        board[x, y, z] = Random.Range(0, 2);
                    }
                }
            }
            RenderBoard();
        }

        void RenderBoard() {
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    for (int z = 0; z < depth; z++) {
                        
                        GameObject cell;
                        Vector3 position = new Vector3(x, y, z);

                        if (cellMap.ContainsKey(position)) {
                            cell = cellMap[position];
                        } 
                        else {
                            cell = Instantiate(cellPrefab);
                            cell.transform.localScale = Vector3.one * 0.9f;
                            cellMap.Add(position, cell);
                            cell.transform.position = position;
                        }
                        
                        bool alive = board[x, y, z] == 1;
                        cell.gameObject.SetActive(alive);
                    }
                }
            }
        }

        void UpdateBoard() {
            int[,,] newBoard = new int[width, height, depth];

            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    for (int z = 0; z < depth; z++) {
                        
                        int count = CountNeighbors(x, y, z);

                        if (board[x, y, z] == 1) {
                            if (count < 2 || count > 3) {
                                newBoard[x, y, z] = 0;
                            } 
                            else {
                                newBoard[x, y, z] = 1;
                            }
                        } else {
                            if (count == 3) {
                                newBoard[x, y, z] = 1;
                            } 
                            else {
                                newBoard[x, y, z] = 0;
                            }
                        }
                    }
                }
            }

            board = newBoard;
            RenderBoard();
        }
        
        int CountNeighbors(int x, int y, int z) {
            int count = 0;

            for (int i = -1; i <= 1; i++) {
                for (int j = -1; j <= 1; j++) {
                    for (int k = -1; k <= 1; k++) {
                        int neighborX = x + i;
                        int neighborY = y + j;
                        int neighborZ = z + k;

                        if (i == 0 && j == 0 && k == 0) {
                            continue;
                        }

                        if (neighborX < 0 || neighborX >= width || 
                            neighborY < 0 || neighborY >= height || 
                            neighborZ < 0 || neighborZ >= depth) {
                            continue;
                        }

                        if (board[neighborX, neighborY, neighborZ] == 1) {
                            count++;
                        }
                    }
                }
            }

            return count;
        }
    
    }
}