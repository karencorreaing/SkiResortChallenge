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

    }
}
