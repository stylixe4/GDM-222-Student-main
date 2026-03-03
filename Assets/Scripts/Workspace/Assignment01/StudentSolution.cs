using System.Collections;
using System.Collections.Generic;
using System.Text;
using AssignmentSystem.Services;
using UnityEngine;
using Debug = AssignmentSystem.Services.AssignmentDebugConsole;

namespace Assignment01
{
    public class StudentSolution : MonoBehaviour, IAssignment
    {

        #region Lecture

        public void LCT01_SyntaxArray()
        {
            throw new System.NotImplementedException();
        }

        public void LCT02_ArrayInitialize()
        {
            throw new System.NotImplementedException();
        }

        public void LCT03_SyntaxLoop()
        {
            throw new System.NotImplementedException();
        }

        public void LCT04_LoopAndArray(string[] ironManSuitNames)
        {
            throw new System.NotImplementedException();
        }

        public void LCT05_Syntax2DArray()
        {
            throw new System.NotImplementedException();
        }

        public void LCT06_SizeOf2DArray(int[,] my2DArray)
        {
            throw new System.NotImplementedException();
        }

        public void LCT07_SyntaxNestedLoop(int columns, int rows)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region Assignment

        public void AS01_RandomItemDrop(GameObject[] items)
        {
            int index = UnityEngine.Random.Range(0, items.Length);
            Debug.Log($"Got item: {items[index].name}");
        }

        public void AS02_NestedLoopForCreate2DMap(GameObject[] floorTiles, int columns, int rows)
        {
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < columns; x++)
                {
                    int rand = UnityEngine.Random.Range(0, floorTiles.Length);
                    GameObject go = Instantiate(floorTiles[rand], new Vector3(x, y, 0), Quaternion.identity);
                    go.name = $"[{x}:{y}]";
                }
            }
        }

        public void AS03_NestedLoopForMakingWallAround(GameObject wall, int columns, int rows)
        {
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < columns; x++)
                {
                    if (x == 0 || x == columns - 1 || y == 0 || y == rows - 1)
                    {
                        GameObject go = Instantiate(wall, new Vector3(x, y, 0), Quaternion.identity);
                        go.name = $"[{x}:{y}]";
                    }
                }
            }
        }

        public void AS04_AttackEnemy(int[] enemyHP, int damage, int target)
        {
            enemyHP[0] = Mathf.Max(0, enemyHP[0] - damage);
            Debug.Log($"FirstEnemy hp :{enemyHP[0]}");

            enemyHP[enemyHP.Length - 1] = Mathf.Max(0, enemyHP[enemyHP.Length - 1] - damage);
            Debug.Log($"LastEnemy hp :{enemyHP[enemyHP.Length - 1]}");

            enemyHP[target] = Mathf.Max(0, enemyHP[target] - damage);
            Debug.Log($"TargetEnemy {target} hp :{enemyHP[target]}");
        }

        public void AS05_DynamicIterationLoop(int n)
        {
            for (int i = 0; i < n; i++) Debug.Log(i.ToString());
        }

        public void AS06_WhileLoopAndArray(string[] ironManSuitNames)
        {
            int i = 0;
            while (i < ironManSuitNames.Length)
            {
                Debug.Log(ironManSuitNames[i]);
                i++;
            }
            Debug.Log("===");
            i = 0;
            while (i < ironManSuitNames.Length)
            {
                Debug.Log(ironManSuitNames[i]);
                i += 2;
            }
        }

        public void AS07_HealTargetAtIndex(int[] heroHPs, int heal, int targetIndex)
        {
            heroHPs[0] += heal;
            Debug.Log($"FirstHero hp :{heroHPs[0]}");
            heroHPs[heroHPs.Length - 1] += heal;
            Debug.Log($"LastHero hp :{heroHPs[heroHPs.Length - 1]}");
            heroHPs[targetIndex] += heal;
            Debug.Log($"TargetHero {targetIndex} hp :{heroHPs[targetIndex]}");
        }

        public void AS08_RandomPickingDialogue(string[] dialogues)
        {
            int index = UnityEngine.Random.Range(0, dialogues.Length);
            Debug.Log(dialogues[index]);
        }

        public void AS09_MultiplicationTable(int n)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= 12; i++)
            {
                sb.Append($"{n}x{i}={n * i}");
                if (i < 12) sb.Append("\n");
            }
            Debug.Log(sb.ToString());
        }

        public void AS10_FindSummationFromZeroToNUsingWhileLoop(int n)
        {
            int sum = 0;
            int i = 0;
            while (i <= n)
            {
                sum += i;
                i++;
            }
            Debug.Log($"¼ÅÃÇÁ¢Í§ n ¨Ò¡ 0 ¶Ö§ {n} ¤×Í {sum}");
        }
        public void AS11_SpawnEnemies(int[] enemyHPs, GameObject enemyPrefab)
        {
            for (int i = 0; i < enemyHPs.Length; i++)
            {
                Debug.Log($"new enemy at position x = {i + 1}");
            }
        }

        public IEnumerator AS12_CountTime(float CountTime)
        {
            float timer = 0;
            while (timer < CountTime)
            {
                timer += Time.deltaTime;
                yield return null;
            }
            Debug.Log($"End timer : {timer}");
        }

        public void AS13_SumOfNumbersInRow(int[,] matrix, int row)
        {
            int sum = 0;
            for (int c = 0; c < matrix.GetLength(1); c++) sum += matrix[row, c];
            Debug.Log(sum.ToString());
        }

        public void AS14_SumOfNumbersInColumn(int[,] matrix, int column)
        {
            int sum = 0;
            for (int r = 0; r < matrix.GetLength(0); r++) sum += matrix[r, column];
            Debug.Log(sum.ToString());
        }

        public void AS15_MakeTheTriangle(int size)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= size; i++)
            {
                for (int j = 0; j < i; j++) sb.Append("*");
                if (i < size) sb.Append("\n");
            }
            Debug.Log(sb.ToString());
        }

        public void AS16_MultiplicationTableOf_2_3_and_4()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= 12; i++)
            {
                sb.Append($"2 x {i} = {2 * i}\t3 x {i} = {3 * i}\t4 x {i} = {4 * i}");
                if (i < 12) sb.Append("\n");
            }
            Debug.Log(sb.ToString());
        }
        #endregion

        #region Extra assignment

        public void EX_01_TicTacToeGame_TurnPlay(string[,] board, string playerTurn, int row, int column)
        {
            throw new System.NotImplementedException();
        }

        private void PrintBoard(string[,] board)
        {
            StringBuilder sb = new();
            for (int i = 0; i < 3; i++)
            {
                sb.AppendLine("-------------");
                sb.AppendLine("| " + board[i, 0] + " | " + board[i, 1] + " | " + board[i, 2] + " |");
            }
            sb.AppendLine("-------------");
            Debug.Log(sb.ToString());
        }
        #endregion
    }

}
