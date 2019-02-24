using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace SkiChallenge.Utils
{
    public class SkiCalc
    {
        private static int [,] resortMap; // To store matrix related to the map. 
        private static int row; // Row count
        private static int column; // Column count
        private static int [,] path; //To store the path of each coordinate. 
        private static int [,] drop; // To store the drop value. 

        public SkiCalc()
        {
        }

    

        public void LoadDataFromFile(string FilePath)
        {
            StreamReader challengeFile = new StreamReader(FilePath);

            String lineTxt;

            if ((lineTxt = challengeFile.ReadLine()) != null)
            {
                String[] lineSplitted = lineTxt.Split(" ");

                row = Convert.ToInt32(lineSplitted[0]);
                column = Convert.ToInt32(lineSplitted[1]);

                resortMap = new int[row, column];
                path = new int[row, column];
                drop = new int[row, column];
            }

            int i = 0;

            while ((lineTxt = challengeFile.ReadLine()) != null)
            {
                int j = 0;
                String[] lineSplitted = lineTxt.Split(" ");
                foreach (var aux in lineSplitted)
                {
                    resortMap[i, j++] = Convert.ToInt32(aux);
                }
                i++;
            }
        }



        private int[] DfsSingleBox(int i, int j)
        {
            int[] pathAndDrop = { 0, i, j }; //First path value, x and y values
            int[] curPathAndDrop = new int[2];


            // search up
            if (j > 0 && resortMap[i, j] > resortMap[i, j - 1])
            {
                curPathAndDrop = DfsSingleBox(i, j - 1);

                if (curPathAndDrop[0] > pathAndDrop[0]) // if the current path value is larger
                                                        // update the path length
                    pathAndDrop = curPathAndDrop;
            }


            // search down 
            if (j < (column - 1) && resortMap[i, j] > resortMap[i, j + 1])
            {
                curPathAndDrop = DfsSingleBox(i, j + 1);
                if (curPathAndDrop[0] > pathAndDrop[0])
                    pathAndDrop = curPathAndDrop;
            }


            // search left 
            if (i > 0 && resortMap[i, j] > resortMap[i - 1, j])
            {
                curPathAndDrop = DfsSingleBox(i - 1, j);
                if (curPathAndDrop[0] > pathAndDrop[0])
                    pathAndDrop = curPathAndDrop;
            }


            // search right 
            if (i < (row - 1) && resortMap[i, j] > resortMap[i + 1, j])
            {
                curPathAndDrop = DfsSingleBox(i + 1, j);
                if (curPathAndDrop[0] > pathAndDrop[0])
                    pathAndDrop = curPathAndDrop;
            }

            pathAndDrop[0]++; // Path length ++

            return pathAndDrop;


        }



        private static List<int> DfsForMaxPath(int x, int y)
        {
            List<int> list = new List<int>();
            List<int> curPathList = new List<int>();

            // search from the up direction
            if (y > 0 && resortMap[x, y] > resortMap[x, y - 1])
            {
                curPathList = DfsForMaxPath(x, y - 1);
                if (curPathList.Count > list.Count)
                    list = curPathList;
            }

            // search from the down direction
            if (y < (column - 1) && resortMap[x, y] > resortMap[x, y + 1])
            {
                curPathList = DfsForMaxPath(x, y + 1);
                if (curPathList.Count > list.Count)
                    list = curPathList;
            }

            // search from the left direction
            if (x > 0 && resortMap[x, y] > resortMap[x - 1, y])
            {
                curPathList = DfsForMaxPath(x - 1, y);
                if (curPathList.Count > list.Count)
                    list = curPathList;
            }

            // search from the right direction
            if (x < (row - 1) && resortMap[x, y] > resortMap[x + 1, y])
            {
                curPathList = DfsForMaxPath(x + 1, y);
                if (curPathList.Count > list.Count)
                    list = curPathList;
            }
            list.Add(y); 
            list.Add(x); 

            return list;
        }

    }
}
