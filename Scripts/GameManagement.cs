using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour
{
    Dices _dices;
    public float
        timeForWait,
        timeForWaitTwo;
    public GameObject
        redDices,
        blueDices,
        background,
        redDiceOne,
        redDiceTwo,
        redDiceThree,
        blueDiceOne,
        blueDiceTwo,
        blueDiceThree;
    public Vector2
        redDicePoint,
        redDicePoint2,
        redDicePoint3,
        blueDicePoint,
        blueDicePoint2,
        blueDicePoint3;
    public bool
        rollDices,
        isMenuStart;
    public int mainDiceResult;
    public int[] resultAllDices;
    public string player;
    public Text playerText;
    public Sprite
        redOne,
        redTwo,
        redThree,
        redFour,
        redFive,
        redSix,
        blueOne,
        blueTwo,
        blueThree,
        blueFour,
        blueFive,
        blueSix;

    void Start()
    {
        _dices = FindObjectOfType(typeof(Dices)) as Dices;
        resultAllDices = new int[4];
        if (!isMenuStart)
        {
            background.SetActive(false);
            player = "Player One";
        }
    }

    void Update()
    {
        if (!isMenuStart)
        {
            if (Input.GetKeyDown("1"))
            {
                if (player == "Player One")
                    RollRedDicesOne();
                else
                    RollBlueDicesOne();
            }
            else if (Input.GetKeyDown("2"))
            {
                if (player == "Player One")
                    RollRedDicesTwo();
                else
                    RollBlueDicesTwo();
            }
            else if (Input.GetKeyDown("3"))
            {
                if (player == "Player One")
                    RollRedDicesThree();
                else
                    RollBlueDicesThree();
            }
            else if (Input.GetKeyDown("4"))
            {
                if (player == "Player One")
                    StartCoroutine(RollAllRedDices());
                else
                    StartCoroutine(RollAllBlueDices());
            }
            playerText.text = player.ToString();
        }
    }

    public void RollRedDicesOne() //DADO VERMELHO 1
    {
        if (!rollDices)
        {
            background.SetActive(true);
            Instantiate(redDices, redDicePoint, Quaternion.identity);
            player = "Player Two";
            Invoke("RedDiceOneResult", 1.3f);
            rollDices = true;
        }
    }

    public void RollRedDicesTwo() // DADO VERMELHO 2
    {
        if (!rollDices)
        {
            background.SetActive(true);
            Instantiate(redDices, redDicePoint, Quaternion.identity);
            player = "Player Two";
            Invoke("RedDiceTwoResult", 1.3f);
            rollDices = true;
        }
    }

    public void RollRedDicesThree() //DADO VERMELHO 3
    {
        if (!rollDices)
        {
            background.SetActive(true);
            Instantiate(redDices, redDicePoint, Quaternion.identity);
            player = "Player Two";
            Invoke("RedDiceThreeResult", 1.3f);
            rollDices = true;
        }
    }

    public IEnumerator RollAllRedDices() //TODOS OS DADOS VERMELHOS
    {
        if (!rollDices)
        {
            rollDices = true;
            StartCoroutine(RedDiceAllResult());
            yield return new WaitForSeconds(timeForWait);
            background.SetActive(true);
            Instantiate(redDices, redDicePoint, Quaternion.identity);
            yield return new WaitForSeconds(timeForWait);
            Instantiate(redDices, redDicePoint2, Quaternion.identity);
            yield return new WaitForSeconds(timeForWait);
            Instantiate(redDices, redDicePoint3, Quaternion.identity);
            player = "Player Two";
        }
    }

    public void RollBlueDicesOne() //DADO AZUL 1
    {
        if (!rollDices)
        {
            background.SetActive(true);
            Instantiate(blueDices, blueDicePoint, Quaternion.identity);
            player = "Player One";
            Invoke("BlueDiceOneResult", 1.3f);
            rollDices = true;
        }
    }

    public void RollBlueDicesTwo() //DADO AUL 2
    {
        if (!rollDices)
        {
            background.SetActive(true);
            Instantiate(blueDices, blueDicePoint, Quaternion.identity);
            player = "Player One";
            Invoke("BlueDiceTwoResult", 1.3f);
            rollDices = true;
        }
    }

    public void RollBlueDicesThree() // DADO AZUL 3
    {
        if (!rollDices)
        {
            background.SetActive(true);
            Instantiate(blueDices, blueDicePoint, Quaternion.identity);
            player = "Player One";
            Invoke("BlueDiceThreeResult", 1.3f);
            rollDices = true;
        }
    }

    public IEnumerator RollAllBlueDices() // TODOS OS DADOS AZUIS
    {
        if (!rollDices)
        {
            rollDices = true;
            StartCoroutine(BlueDiceAllResult());
            yield return new WaitForSeconds(timeForWait);
            background.SetActive(true);
            Instantiate(blueDices, blueDicePoint, Quaternion.identity);
            yield return new WaitForSeconds(timeForWait);
            Instantiate(blueDices, blueDicePoint2, Quaternion.identity);
            yield return new WaitForSeconds(timeForWait);
            Instantiate(blueDices, blueDicePoint3, Quaternion.identity);
            player = "Player One";
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game Screem");
    }
    public void MenuStart()
    {
        SceneManager.LoadScene("Menu Start");
    }

    void RedDiceOneResult()
    {
        if (mainDiceResult == 1)
            redDiceOne.GetComponent<SpriteRenderer>().sprite = redOne;
        else if (mainDiceResult == 2)
            redDiceOne.GetComponent<SpriteRenderer>().sprite = redTwo;
        else if (mainDiceResult == 3)
            redDiceOne.GetComponent<SpriteRenderer>().sprite = redThree;
        else if (mainDiceResult == 4)
            redDiceOne.GetComponent<SpriteRenderer>().sprite = redFour;
        else if (mainDiceResult == 5)
            redDiceOne.GetComponent<SpriteRenderer>().sprite = redFive;
        else if (mainDiceResult == 6)
            redDiceOne.GetComponent<SpriteRenderer>().sprite = redSix;
        mainDiceResult = 0;
        StartCoroutine(DesactiveBackground());
    }
    void RedDiceTwoResult()
    {
        if (mainDiceResult == 1)
            redDiceTwo.GetComponent<SpriteRenderer>().sprite = redOne;
        else if (mainDiceResult == 2)
            redDiceTwo.GetComponent<SpriteRenderer>().sprite = redTwo;
        else if (mainDiceResult == 3)
            redDiceTwo.GetComponent<SpriteRenderer>().sprite = redThree;
        else if (mainDiceResult == 4)
            redDiceTwo.GetComponent<SpriteRenderer>().sprite = redFour;
        else if (mainDiceResult == 5)
            redDiceTwo.GetComponent<SpriteRenderer>().sprite = redFive;
        else if (mainDiceResult == 6)
            redDiceTwo.GetComponent<SpriteRenderer>().sprite = redSix;
        mainDiceResult = 0;
        StartCoroutine(DesactiveBackground());
    }
    void RedDiceThreeResult()
    {
        if (mainDiceResult == 1)
            redDiceThree.GetComponent<SpriteRenderer>().sprite = redOne;
        else if (mainDiceResult == 2)
            redDiceThree.GetComponent<SpriteRenderer>().sprite = redTwo;
        else if (mainDiceResult == 3)
            redDiceThree.GetComponent<SpriteRenderer>().sprite = redThree;
        else if (mainDiceResult == 4)
            redDiceThree.GetComponent<SpriteRenderer>().sprite = redFour;
        else if (mainDiceResult == 5)
            redDiceThree.GetComponent<SpriteRenderer>().sprite = redFive;
        else if (mainDiceResult == 6)
            redDiceThree.GetComponent<SpriteRenderer>().sprite = redSix;
        mainDiceResult = 0;
        StartCoroutine(DesactiveBackground());
    }
    IEnumerator RedDiceAllResult()
    {
        for (int i = 0; i != 4; i++)
        {
            yield return new WaitForSeconds(timeForWaitTwo);
            resultAllDices[i] = mainDiceResult;

        }
        if (resultAllDices[1] == 1)
            redDiceOne.GetComponent<SpriteRenderer>().sprite = redOne;
        else if (resultAllDices[1] == 2)
            redDiceOne.GetComponent<SpriteRenderer>().sprite = redTwo;
        else if (resultAllDices[1] == 3)
            redDiceOne.GetComponent<SpriteRenderer>().sprite = redThree;
        else if (resultAllDices[1] == 4)
            redDiceOne.GetComponent<SpriteRenderer>().sprite = redFour;
        else if (resultAllDices[1] == 5)
            redDiceOne.GetComponent<SpriteRenderer>().sprite = redFive;
        else if (resultAllDices[1] == 6)
            redDiceOne.GetComponent<SpriteRenderer>().sprite = redSix;

        if (resultAllDices[2] == 1)
            redDiceTwo.GetComponent<SpriteRenderer>().sprite = redOne;
        else if (resultAllDices[2] == 2)
            redDiceTwo.GetComponent<SpriteRenderer>().sprite = redTwo;
        else if (resultAllDices[2] == 3)
            redDiceTwo.GetComponent<SpriteRenderer>().sprite = redThree;
        else if (resultAllDices[2] == 4)
            redDiceTwo.GetComponent<SpriteRenderer>().sprite = redFour;
        else if (resultAllDices[2] == 5)
            redDiceTwo.GetComponent<SpriteRenderer>().sprite = redFive;
        else if (resultAllDices[2] == 6)
            redDiceTwo.GetComponent<SpriteRenderer>().sprite = redSix;


        if (resultAllDices[3] == 1)
            redDiceThree.GetComponent<SpriteRenderer>().sprite = redOne;
        else if (resultAllDices[3] == 2)
            redDiceThree.GetComponent<SpriteRenderer>().sprite = redTwo;
        else if (resultAllDices[3] == 3)
            redDiceThree.GetComponent<SpriteRenderer>().sprite = redThree;
        else if (resultAllDices[3] == 4)
            redDiceThree.GetComponent<SpriteRenderer>().sprite = redFour;
        else if (resultAllDices[3] == 5)
            redDiceThree.GetComponent<SpriteRenderer>().sprite = redFive;
        else if (resultAllDices[3] == 6)
            redDiceThree.GetComponent<SpriteRenderer>().sprite = redSix;
        mainDiceResult = 0;
        StartCoroutine(DesactiveBackground());
    }

    void BlueDiceOneResult()
    {
        if (mainDiceResult == 1)
            blueDiceOne.GetComponent<SpriteRenderer>().sprite = blueOne;
        else if (mainDiceResult == 2)
            blueDiceOne.GetComponent<SpriteRenderer>().sprite = blueTwo;
        else if (mainDiceResult == 3)
            blueDiceOne.GetComponent<SpriteRenderer>().sprite = blueThree;
        else if (mainDiceResult == 4)
            blueDiceOne.GetComponent<SpriteRenderer>().sprite = blueFour;
        else if (mainDiceResult == 5)
            blueDiceOne.GetComponent<SpriteRenderer>().sprite = blueFive;
        else if (mainDiceResult == 6)
            blueDiceOne.GetComponent<SpriteRenderer>().sprite = blueSix;
        mainDiceResult = 0;
        StartCoroutine(DesactiveBackground());
    }
    void BlueDiceTwoResult()
    {
        if (mainDiceResult == 1)
            blueDiceTwo.GetComponent<SpriteRenderer>().sprite = blueOne;
        else if (mainDiceResult == 2)
            blueDiceTwo.GetComponent<SpriteRenderer>().sprite = blueTwo;
        else if (mainDiceResult == 3)
            blueDiceTwo.GetComponent<SpriteRenderer>().sprite = blueThree;
        else if (mainDiceResult == 4)
            blueDiceTwo.GetComponent<SpriteRenderer>().sprite = blueFour;
        else if (mainDiceResult == 5)
            blueDiceTwo.GetComponent<SpriteRenderer>().sprite = blueFive;
        else if (mainDiceResult == 6)
            blueDiceTwo.GetComponent<SpriteRenderer>().sprite = blueSix;
        mainDiceResult = 0;
        StartCoroutine(DesactiveBackground());
    }
    void BlueDiceThreeResult()
    {
        if (mainDiceResult == 1)
            blueDiceThree.GetComponent<SpriteRenderer>().sprite = blueOne;
        else if (mainDiceResult == 2)
            blueDiceThree.GetComponent<SpriteRenderer>().sprite = blueTwo;
        else if (mainDiceResult == 3)
            blueDiceThree.GetComponent<SpriteRenderer>().sprite = blueThree;
        else if (mainDiceResult == 4)
            blueDiceThree.GetComponent<SpriteRenderer>().sprite = blueFour;
        else if (mainDiceResult == 5)
            blueDiceThree.GetComponent<SpriteRenderer>().sprite = blueFive;
        else if (mainDiceResult == 6)
            blueDiceThree.GetComponent<SpriteRenderer>().sprite = blueSix;
        mainDiceResult = 0;
        StartCoroutine(DesactiveBackground());
    }
    IEnumerator BlueDiceAllResult()
    {
        {
            for (int i = 0; i != 4; i++)
            {
                yield return new WaitForSeconds(timeForWaitTwo);
                resultAllDices[i] = mainDiceResult;

            }
            if (resultAllDices[1] == 1)
                blueDiceOne.GetComponent<SpriteRenderer>().sprite = blueOne;
            else if (resultAllDices[1] == 2)
                blueDiceOne.GetComponent<SpriteRenderer>().sprite = blueTwo;
            else if (resultAllDices[1] == 3)
                blueDiceOne.GetComponent<SpriteRenderer>().sprite = blueThree;
            else if (resultAllDices[1] == 4)
                blueDiceOne.GetComponent<SpriteRenderer>().sprite = blueFour;
            else if (resultAllDices[1] == 5)
                blueDiceOne.GetComponent<SpriteRenderer>().sprite = blueFive;
            else if (resultAllDices[1] == 6)
                blueDiceOne.GetComponent<SpriteRenderer>().sprite = blueSix;

            if (resultAllDices[2] == 1)
                blueDiceTwo.GetComponent<SpriteRenderer>().sprite = blueOne;
            else if (resultAllDices[2] == 2)
                blueDiceTwo.GetComponent<SpriteRenderer>().sprite = blueTwo;
            else if (resultAllDices[2] == 3)
                blueDiceTwo.GetComponent<SpriteRenderer>().sprite = blueThree;
            else if (resultAllDices[2] == 4)
                blueDiceTwo.GetComponent<SpriteRenderer>().sprite = blueFour;
            else if (resultAllDices[2] == 5)
                blueDiceTwo.GetComponent<SpriteRenderer>().sprite = blueFive;
            else if (resultAllDices[2] == 6)
                blueDiceTwo.GetComponent<SpriteRenderer>().sprite = blueSix;


            if (resultAllDices[3] == 1)
                blueDiceThree.GetComponent<SpriteRenderer>().sprite = blueOne;
            else if (resultAllDices[3] == 2)
                blueDiceThree.GetComponent<SpriteRenderer>().sprite = blueTwo;
            else if (resultAllDices[3] == 3)
                blueDiceThree.GetComponent<SpriteRenderer>().sprite = blueThree;
            else if (resultAllDices[3] == 4)
                blueDiceThree.GetComponent<SpriteRenderer>().sprite = blueFour;
            else if (resultAllDices[3] == 5)
                blueDiceThree.GetComponent<SpriteRenderer>().sprite = blueFive;
            else if (resultAllDices[3] == 6)
                blueDiceThree.GetComponent<SpriteRenderer>().sprite = blueSix;
            mainDiceResult = 0;
            StartCoroutine(DesactiveBackground());
        }
    }
    IEnumerator DesactiveBackground()
    {
        yield return new WaitForSeconds(2f);
        background.SetActive(false);
        rollDices = false;
    }
}
