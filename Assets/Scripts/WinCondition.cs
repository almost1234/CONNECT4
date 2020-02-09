using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField]
    private Databasesystem listData;
    private string checkName;
    private bool winBool;
    private List<int[]> rightSideCheck = new List<int[]>()
        {
        new int[] {5,3},
        new int[] {5,4},
        new int[] {5,5},
        new int[] {5,6},
        new int[] {4,6},
        new int[] {3,6}

        };
    private List<int[]> leftSideCheck = new List<int[]>()
        {
        new int[] {3,0},
        new int[] {4,0},
        new int[] {5,0},
        new int[] {5,1},
        new int[] {5,2},
        new int[] {5,3},

        };
    void Start()
    {
        checkName = "lul";
        winBool = false;

    }

    // Update is called once per frame
    public void WinCheck() 
    {
        int counter = 0;

        //horizontal checker
        for (int row = 0; row != 6; row++) 
        {
            for (int column = 0; column != 7; column++) 
            {
                if (listData.checkerData[row][column] == "nothing" || listData.checkerData[row][column] == "base")
                {
                    counter = 0;
                }

                else 
                {
                    if (checkName == listData.checkerData[row][column])
                    {

                        counter = counter + 1;

                        if (counter == 4 && checkName != "nothing" && checkName != "base")
                        {

                            Debug.Log(checkName + " wins");
                            return;

                        }
                    }

                    else 
                    {
                        checkName = listData.checkerData[row][column];
                        counter = 1;
                    }
                }  
            }
            counter = 0;
        }
        //vertical checker
        counter = 0;

        for(int column = 0; column != 7; column++)
        {
            for (int row = 0; row != 6; row++)
            {
                if (listData.checkerData[row][column] == "nothing" || listData.checkerData[row][column] == "base")
                {
                    counter = 0;
                }

                else
                {
                    if (checkName == listData.checkerData[row][column])
                    {
                        counter = counter + 1;

                        if (counter == 4 && checkName != "nothing" && checkName != "base")
                        {

                            Debug.Log(checkName + " wins");
                            return;

                        }
                    }

                    else
                    {
                        checkName = listData.checkerData[row][column];
                        counter = 1;
                    }
                }
            }
            counter = 0;
        }
        counter = 0;

        //right to left diagonal checker
        foreach (int[] coordinates in rightSideCheck) 
        {
            int row = coordinates[0];
            int column = coordinates[1];

            while ((row >-1) && (column > -1)) 
            {
                if (listData.checkerData[row][column] == "nothing" || listData.checkerData[row][column] == "base")
                {
                    counter = 0;
                }

                else
                {
                    if (checkName == listData.checkerData[row][column])
                    {
                        counter = counter + 1;

                        if (counter == 4 && checkName != "nothing" && checkName != "base")
                        {

                            Debug.Log(checkName + " wins");
                            return;

                        }
                    }

                    else
                    {
                        checkName = listData.checkerData[row][column];
                        counter = 1;
                    }
                }
                row = row - 1;
                column = column - 1;
            }
            counter = 0;

        }
        counter = 0;

        //left to right diagonal
        foreach (int[] coordinates in leftSideCheck)
        {
            int row = coordinates[0];
            int column = coordinates[1];

            while ((row > -1 ) && (column < 7))
            {
                if (listData.checkerData[row][column] == "nothing")
                {
                    counter = 0;
                }

                else
                {
                    if (checkName == listData.checkerData[row][column])
                    {
                        counter = counter + 1;

                        if (counter == 4 && checkName != "nothing" && checkName != "base")
                        {

                            Debug.Log(checkName + " wins");
                            return;

                        }
                    }

                    else
                    {
                        checkName = listData.checkerData[row][column];
                        counter = 1;
                    }
                }
                row = row - 1;
                column = column + 1;
            }
            counter = 0;
        }
        counter = 0;

        Debug.Log("Finished Checking, no wins");
    }

}// there a lot of repeating function, but it will be cleaned after UI is done
