using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanoiController : MonoBehaviour
{
    public GameObject firstDisc;
    public GameObject secondDisc;
    public GameObject thirdDisc;
    public GameObject forthDisc;

    public GameObject leftStick;
    public GameObject rightStick;
    public GameObject middleStick;

    public Transform leftSelector;
    public Transform rightSelector;
    public Transform middleSelector;

    private Stack<GameObject> rightStack;
    private Stack<GameObject> leftStack;

    private void Start()
    {
        SetGame();
    }
    private void SetGame()
    {
        Stack<GameObject> middleStack = new Stack<GameObject>();

        Vector2 discPosition = new Vector2(middleStick.transform.position.x, middleStick.transform.position.y);
        //push items
        middleStack.Push(firstDisc);
        middleStack.Push(secondDisc);
        middleStack.Push(thirdDisc);
        middleStack.Push(forthDisc);
        middleStack.Push(forthDisc);

        foreach(GameObject disc in middleStack)
        {
            disc.transform.position = discPosition;
            discPosition.y -= 0.04f;

        }
    }

    private void MoveDisc()
    {

    }
    private void StartGame()
    {

    }


}
