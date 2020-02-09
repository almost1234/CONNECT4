using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Databasesystem : MonoBehaviour
{
    public GameObject checkerPiece;
    public Transform gridBase;
    public string playerName;
    public string player1Name;
    public string player2Name;
    public GameObject buttonUIGroup;
    private Button[] buttonList;

    public List<string[]> checkerData { get; } = new List<string[]>() {
        new string[] {"nothing","nothing","nothing","nothing","nothing","nothing","nothing"},
        new string[] {"nothing","nothing","nothing","nothing","nothing","nothing","nothing"},
        new string[] {"nothing","nothing","nothing","nothing","nothing","nothing","nothing"},
        new string[] {"nothing","nothing","nothing","nothing","nothing","nothing","nothing"},
        new string[] {"nothing","nothing","nothing","nothing","nothing","nothing","nothing"},
        new string[] {"base","base","base","base","base","base","base"}
        };

    private void Start()
    {
        player1Name = "red";
        player2Name = "yellow";
        playerName = player1Name;
        buttonList = buttonUIGroup.GetComponentsInChildren<Button>();
    }



    public void UpdateChecker(int column) 
    {
        for (int i = 5;i != -1;i--) 
        {
            if (checkerData[i][column] == "base")
            {
                Debug.Log("Checker added");
                checkerData[i][column] = playerName;
                if (i-1 >= 0) 
                {
                    checkerData[i - 1][column] = "base";
                    Debug.Log("Base added");
                }

                if (i == 0) 
                {
                    buttonList[column].interactable = false;
                }
                Debug.Log(checkerData[i][column]+"Updated in it");
                GameObject colorChecker = Instantiate(checkerPiece,gridBase);
                colorChecker.transform.position = new Vector3Int(3*(i-2),2, 3 * (column - 3));
                Renderer colorSetter = colorChecker.GetComponent<Renderer>(); 
                if (playerName == "red")
                {
                    colorSetter.material.color = Color.red;
                    playerName = player2Name;
                }

                else 
                {
                    colorSetter.material.color = Color.yellow;
                    playerName =player1Name;
                }
                break;
                
            }

            else 
            {
                Debug.Log("This area is occupied by " + checkerData[i][column]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
