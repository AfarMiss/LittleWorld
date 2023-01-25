using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.MapUtility
{
    public class AreaUtility
    {

        public int PlantAreaNum(char[][] grid)
        {
            int result = 0;
            int row = grid.Length;
            int col = grid[0].Length;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        result++;
                        dfs(grid, i, j);
                    }
                }
            }
            return result;
        }

        private void dfs(char[][] grid, int r, int c)
        {
            // 判断 base case
            // 如果坐标 (r, c) 超出了网格范围，直接返回
            if (!inArea(grid, r, c))
            {
                return;
            }
            // 如果这个格子不是岛屿，直接返回
            if (grid[r][c] != '1')
            {
                return;
            }
            grid[r][c] = '2'; // 将格子标记为「已遍历过」

            // 访问上、下、左、右四个相邻结点
            dfs(grid, r - 1, c);
            dfs(grid, r + 1, c);
            dfs(grid, r, c - 1);
            dfs(grid, r, c + 1);
        }

        // 判断坐标 (r, c) 是否在网格中
        private bool inArea(char[][] grid, int r, int c)
        {
            return 0 <= r && r < grid.Length
                    && 0 <= c && c < grid[0].Length;
        }

    }
}
