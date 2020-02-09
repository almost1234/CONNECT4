using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerMove : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Databasesystem listData;
    private string checkName;
    private string computerColor;
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

    private List<int[]> rightReverseSideCheck = new List<int[]>()
        {
        new int[] {0,0},
        new int[] {0,1},
        new int[] {0,2},
        new int[] {0,3},
        new int[] {1,0},
        new int[] {2,0}

        };
    private List<int[]> leftReverseSideCheck = new List<int[]>()
        {
        new int[] {0,3},
        new int[] {0,4},
        new int[] {0,5},
        new int[] {0,6},
        new int[] {1,6},
        new int[] {2,6},

        };

    List<int[]> moveList = new List<int[]>();
    
    void Start()
    {
        checkName = listData.playerName;
        computerColor = "yellow";
        
    }

    Dictionary<string, int> conversion = new Dictionary<string, int>()
    {
        {"red",0 },
        {"yellow",1 },
        {"base", 2 },
        {"nothing",3 }

    };

    // Update is called once per frame
    void Update()
    {
        
    }

    public void computerMoves()
    {
        Debug.Log("Computer will start finding moves-----------------------------------");
        int counter = 0;

        //horizontal checker
        Debug.Log("HORIZONTAL CHECK--------------------------------");
        for (int row = 0; row != 6; row++)
        {
            for (int column = 0; column != 7; column++)
            {
                if (listData.checkerData[row][column] == "nothing" || listData.checkerData[row][column] == "base")
                {
                    Debug.Log("Base/Nothing Founc -----------------------------");
                    if (listData.checkerData[row][column] == "base") //Checking for base (Or possible move);
                    {
                        
                        int possibleChecker = 3 - counter;
                        int confirmedChecker = 0;
                        int addChecker = 0;
                        Debug.Log("Base Detected--------------------" + limitChecker(0, false, possibleChecker, true, row, column).ToString());
                        if (limitChecker(0, false, possibleChecker, true, row, column) == 1) //check if winning condition is within list range 
                        {
                            Debug.Log("Entering the counter check");
                            for (int i = 1; i < 1 + possibleChecker; i++)
                            {
                                if (listData.checkerData[row][column + i] == "nothing" || listData.checkerData[row][column + i] == "base")
                                {
                                    confirmedChecker = confirmedChecker + 1;
                                }

                                else if (listData.checkerData[row][column + i] == checkName)
                                {
                                    confirmedChecker = confirmedChecker + 1;
                                    addChecker = addChecker + 1;
                                }
                            }

                            if (possibleChecker == confirmedChecker)
                            {
                                moveList.Add(new int[] { counter + addChecker, column, conversion[checkName] });
                                Debug.Log("Column GET : " + column.ToString() + "----------------------------------------------");
                            }
                        }
                    }
                    checkName = listData.checkerData[row][column];
                    counter = 0;
                }

                else
                {
                    if (checkName == listData.checkerData[row][column])
                    {

                        counter = counter + 1;
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
        //reverse
        Debug.Log("HORIZONTAL REVERSE ---------------------");
        for (int row = 5; row != -1; row--)
        {
            for (int column = 6; column != -1; column--)
            {
                if (listData.checkerData[row][column] == "nothing" || listData.checkerData[row][column] == "base")
                {
                    if (listData.checkerData[row][column] == "base") //Checking for base (Or possible move);
                    {
                        int possibleChecker = 3 - counter;
                        int confirmedChecker = 0;
                        int addChecker = 0;
                        Debug.Log("Base Detected--------------------" + limitChecker(0, false, possibleChecker, false, row, column).ToString());
                        if (limitChecker(0, false, possibleChecker, false, row, column) != 0) //check if winning condition is within list range 
                        {
                            Debug.Log("Entering the counter check");
                            for (int i = 1; i < 1 + possibleChecker; i++)
                            {
                                if (listData.checkerData[row][column - i] == "nothing" || listData.checkerData[row][column - i] == "base")
                                {
                                    confirmedChecker = confirmedChecker + 1;
                                }

                                else if (listData.checkerData[row][column - i] == checkName)
                                {
                                    confirmedChecker = confirmedChecker + 1;
                                    addChecker = addChecker + 1;
                                }
                            }

                            if (possibleChecker == confirmedChecker)
                            {
                                moveList.Add(new int[] { counter + addChecker, column, conversion[checkName] });
                                Debug.Log("Column GET : " + column.ToString() + "----------------------------------------------");
                            }
                        }
                    }
                    checkName = listData.checkerData[row][column];
                    counter = 0;
                }


                else
                {
                    if (checkName == listData.checkerData[row][column])
                    {

                        counter = counter + 1;
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
        for (int column = 0; column != 7; column++)
        {
            for (int row = 0; row != 6; row++)
            {
                if (listData.checkerData[row][column] == "nothing" || listData.checkerData[row][column] == "base")
                {
                    if (listData.checkerData[row][column] == "base") //Checking for base (Or possible move);
                    {
                        int possibleChecker = 3 - counter;
                        int confirmedChecker = 0;
                        int addChecker = 0;

                        if (limitChecker(possibleChecker, true, 0, true, row, column) == 1) //check if winning condition is within list range 
                        {
                            for (int i = 1; i < 1 + possibleChecker; i++)
                            {
                                if (listData.checkerData[row + i][column] == "nothing" || listData.checkerData[row + i][column] == "base")
                                {
                                    confirmedChecker = confirmedChecker + 1;
                                }

                                else if (listData.checkerData[row + i][column] == checkName)
                                {
                                    confirmedChecker = confirmedChecker + 1;
                                    addChecker = addChecker + 1;
                                }
                            }

                            if (possibleChecker == confirmedChecker)
                            {
                                moveList.Add(new int[] { counter + addChecker , column, conversion[checkName] });
                            }
                        }
                    }
                    checkName = listData.checkerData[row][column];
                    counter = 0;
                }

                else
                {
                    if (checkName == listData.checkerData[row][column])
                    {
                        counter = counter + 1;
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

        //vertical reverse
        for (int column = 6; column != -1; column--)
        {
            for (int row = 5; row != 0; row--)
            {
                if (listData.checkerData[row][column] == "nothing" || listData.checkerData[row][column] == "base")
                {
                    if (listData.checkerData[row][column] == "base") //Checking for base (Or possible move);
                    {
                        int possibleChecker = 3 - counter;
                        int confirmedChecker = 0;
                        int addChecker = 0;

                        if (limitChecker(possibleChecker , false, 0, true, row, column) == 1) //check if winning condition is within list range 
                        {
                            for (int i = 1; i < 1 + possibleChecker; i++)
                            {
                                if (listData.checkerData[row - i][column] == "nothing" || listData.checkerData[row - i][column] == "base")
                                {
                                    confirmedChecker = confirmedChecker + 1;
                                }

                                else if (listData.checkerData[row - i][column] == checkName)
                                {
                                    confirmedChecker = confirmedChecker + 1;
                                    addChecker = addChecker + 1;
                                }
                            }

                            if (possibleChecker == confirmedChecker)
                            {
                                moveList.Add(new int[] { counter + addChecker, column, conversion[checkName] });
                            }
                        }
                    }
                    checkName = listData.checkerData[row][column];
                    counter = 0;
                }

                else
                {
                    if (checkName == listData.checkerData[row][column])
                    {
                        counter = counter + 1;
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

            while ((row > -1) && (column > -1))
            {
                if (listData.checkerData[row][column] == "nothing" || listData.checkerData[row][column] == "base")
                {
                    if (listData.checkerData[row][column] == "base") //Checking for base (Or possible move);
                    {
                        int possibleChecker = 3 - counter;
                        int confirmedChecker = 0;
                        int addChecker = 0;

                        if (limitChecker(possibleChecker, false, possibleChecker, false, row, column) == 1) //check if winning condition is within list range 
                        {
                            for (int i = 1; i < 1 + possibleChecker; i++)
                            {
                                if (listData.checkerData[row - i][column - i] == "nothing" || listData.checkerData[row - i][column - i] == "base")
                                {
                                    confirmedChecker = confirmedChecker + 1;
                                }

                                else if (listData.checkerData[row - i][column - i] == checkName)
                                {
                                    confirmedChecker = confirmedChecker + 1;
                                    addChecker = addChecker + 1;
                                }
                            }

                            if (possibleChecker == confirmedChecker)
                            {
                                moveList.Add(new int[] { counter + addChecker, column, conversion[checkName] });
                            }
                        }
                    }
                    checkName = listData.checkerData[row][column];
                    counter = 0;
                }

                else
                {
                    if (checkName == listData.checkerData[row][column])
                    {
                        counter = counter + 1;

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

        //right to left reverse diagonal checker
        foreach (int[] coordinates in rightReverseSideCheck)
        {
            int row = coordinates[0];
            int column = coordinates[1];

            while ((row < 6 ) && (column < 7))
            {
                if (listData.checkerData[row][column] == "nothing" || listData.checkerData[row][column] == "base")
                {
                    if (listData.checkerData[row][column] == "base") //Checking for base (Or possible move);
                    {
                        int possibleChecker = 3 - counter;
                        int confirmedChecker = 0;
                        int addChecker = 0;

                        if (limitChecker(possibleChecker, true, possibleChecker, true, row, column) == 1) //check if winning condition is within list range 
                        {
                            for (int i = 1; i < 1 + possibleChecker; i++)
                            {
                                if (listData.checkerData[row + i][column + i] == "nothing" || listData.checkerData[row + i][column + i] == "base")
                                {
                                    confirmedChecker = confirmedChecker + 1;
                                }

                                else if (listData.checkerData[row + i][column + i] == checkName)
                                {
                                    confirmedChecker = confirmedChecker + 1;
                                    addChecker = addChecker + 1;
                                }
                            }

                            if (possibleChecker == confirmedChecker)
                            {
                                moveList.Add(new int[] { counter + addChecker, column, conversion[checkName] });
                            }
                        }
                    }
                    checkName = listData.checkerData[row][column];
                    counter = 0;
                }

                else
                {
                    if (checkName == listData.checkerData[row][column])
                    {
                        counter = counter + 1;

                    }

                    else
                    {
                        checkName = listData.checkerData[row][column];
                        counter = 1;
                    }
                }
                row = row + 1;
                column = column + 1;
            }
            counter = 0;

        }
        counter = 0;

        //left to right diagonal
        foreach (int[] coordinates in leftSideCheck)
        {
            int row = coordinates[0];
            int column = coordinates[1];

            while ((row > -1) && (column < 6))
            {
                if (listData.checkerData[row][column] == "nothing" || listData.checkerData[row][column] == "base")
                {
                    if (listData.checkerData[row][column] == "base") //Checking for base (Or possible move);
                    {
                        int possibleChecker = 3 - counter;
                        int confirmedChecker = 0;
                        int addChecker = 0;

                        if (limitChecker(possibleChecker , false, possibleChecker, true, row, column) == 1) //check if winning condition is within list range 
                        {
                            
                            
                            for (int i = 1; i < 1 + possibleChecker; i++)
                            {
                                
                                if (listData.checkerData[row - i][column + i] == "nothing" || listData.checkerData[row - i][column + i] == "base")
                                {
                                    confirmedChecker = confirmedChecker + 1;
                                }

                                else if (listData.checkerData[row - i][column + i] == checkName)
                                {
                                    confirmedChecker = confirmedChecker + 1;
                                    addChecker = addChecker + 1;
                                }
                                
                            }

                            if (possibleChecker == confirmedChecker)
                            {
                                moveList.Add(new int[] { counter + addChecker, column, conversion[checkName] });
                            }
                        }
                    }
                    checkName = listData.checkerData[row][column];
                    counter = 0;
                }

                else
                {
                    if (checkName == listData.checkerData[row][column])
                    {
                        counter = counter + 1;

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
        

        //left to right reverse diagonal
        foreach (int[] coordinates in leftReverseSideCheck)
        {
            int row = coordinates[0];
            int column = coordinates[1];
            
            while ((row < 6) && (column > -1))
            {
                
                if (listData.checkerData[row][column] == "nothing" || listData.checkerData[row][column] == "base")
                {
                    if (listData.checkerData[row][column] == "base") //Checking for base (Or possible move);
                    {
                        int possibleChecker = 3 - counter;
                        int confirmedChecker = 0;
                        int addChecker = 0;

                        if (limitChecker(possibleChecker, true, possibleChecker, false, row, column) == 1) //check if winning condition is within list range 
                        {
                            
                            
                            for (int i = 1; i < 1 + possibleChecker; i++)
                            {
                                
                                if (listData.checkerData[row + i][column - i] == "nothing" || listData.checkerData[row + i][column - i] == "base")
                                {
                                    confirmedChecker = confirmedChecker + 1;
                                }

                                else if (listData.checkerData[row + i][column - i] == checkName)
                                {
                                    confirmedChecker = confirmedChecker + 1;
                                    addChecker = addChecker + 1;
                                }
                            }

                            if (possibleChecker == confirmedChecker)
                            {
                                moveList.Add(new int[] { counter + addChecker, column, conversion[checkName] });
                            }
                        }
                    }
                    checkName = listData.checkerData[row][column];
                    counter = 0;
                }

                else
                {
                    if (checkName == listData.checkerData[row][column])
                    {
                        counter = counter + 1;

                    }

                    else
                    {
                        checkName = listData.checkerData[row][column];
                        counter = 1;
                    }
                }
                row = row + 1;
                column = column - 1;
            }
            counter = 0;
        }
        counter = 0;
        movePicker();
    }

    public void movePicker() 
    {
        List<int[]> compiledMove = new List<int[]>();
        foreach (int[] data in moveList) 
        {
            if (data[2] != 3) 
            {
                compiledMove.Add(data);
            }
        }
        Debug.Log("Move compiled, choosing the move");
        for (int i = 3; i != -1; i--) 
        {
            List<int[]> highestCounter = new List<int[]>();
            foreach (int[] data in compiledMove) 
            {
                if (data[0] == i) 
                {
                    highestCounter.Add(data);
                    Debug.Log("Column   " + data[1].ToString());
                }
                
            }
            if (highestCounter.Count > 0)
            {
                Debug.Log("Move Chosen, time to update         count:" + highestCounter.Count.ToString() + "counter found:" + i.ToString());

                while (highestCounter.Count > 0)
                {
                    int randomPosition = Random.Range(0, highestCounter.Count);
                    int choosenColumn = highestCounter[randomPosition][1];
                    Debug.Log("Position Chosen -- " + choosenColumn);
                    if (listData.checkerData[0][choosenColumn] == "nothing" || listData.checkerData[0][choosenColumn] == "base")
                    {
                        Debug.Log("Move Chosen, time to update");
                        listData.UpdateChecker(choosenColumn);
                        return;
                    }
                    else
                    {
                        highestCounter.Remove(highestCounter[randomPosition]);
                    }
                }
            }
        }
        moveList.Clear();
    }
    public static int limitChecker(int rowNum, bool rowOp, int columnNum, bool columnOp, int rowCord, int columnCord) 
    {
        //to check for rowNum
        if (rowOp == true)
        {
            Debug.Log("ROW NUMBER" + (rowNum + rowCord).ToString());
            if (rowNum + rowCord >= 6)
            {
                
                return 0;
            }
        }

        else 
        {
            Debug.Log("ROW NUMBER" + (rowCord - rowNum).ToString());
            if (rowCord - rowNum <= -1)
            {
                
                return 0;
            }
        }

        //to check for columnNum
        if (columnOp == true)
        {
            Debug.Log("COLUMN NUMBER" + (columnNum + columnCord).ToString());
            if (columnNum + columnCord >= 7)
            {
                
                return 0;
            }
        }

        else 
        {
            Debug.Log("COLUMN NUMBER" + (columnCord - columnNum).ToString());
            if (columnCord - columnNum  <= -1)
            {
                
                return 0;
            }
        }

        return 1;
        
    }
}
