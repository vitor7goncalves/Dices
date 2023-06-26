using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class RollDices : MonoBehaviour
{
    GameManagement _gameManagement;
    public float actualPosition;       
    float 
        timeForTheMove,
        veloc;
    int diceResult,
        actualRotation;

    void Start()
    {
        _gameManagement = FindObjectOfType(typeof(GameManagement)) as GameManagement;
        this.gameObject.GetComponent<AudioSource>().Play();
        timeForTheMove = 1.2f;
        diceResult = Random.Range(1, 7);
        actualRotation = Random.Range(1, 360);
        _gameManagement.mainDiceResult = diceResult;
        veloc = Random.Range((float)5f, (float)17f);
        DiceResult();
    }

    void Update()
    {
        timeForTheMove -= Time.deltaTime;
        if (veloc > 1f)
            veloc -= Time.deltaTime;   //Condicional que desacelera o dado
 
        if (timeForTheMove > 0f)
        {
            transform.position = new Vector2(actualPosition -= veloc * Time.deltaTime, transform.position.y);
            transform.rotation = Quaternion.Euler(0, 0, actualRotation);
        }   
        else
        {
            StartCoroutine(DestroyDice());
        }
            
    }

    void DiceResult()
    {
        if (diceResult == 1)
            this.gameObject.GetComponent<Animator>().SetTrigger("1");
        else if (diceResult == 2)
            this.gameObject.GetComponent<Animator>().SetTrigger("2");
        else if (diceResult == 3)
            this.gameObject.GetComponent<Animator>().SetTrigger("3");
        else if (diceResult == 4)
            this.gameObject.GetComponent<Animator>().SetTrigger("4");
        else if (diceResult == 5)
            this.gameObject.GetComponent<Animator>().SetTrigger("5");
        else if (diceResult == 6)
            this.gameObject.GetComponent<Animator>().SetTrigger("6");
        else
        {
            diceResult = Random.Range(1, 7);
            DiceResult();
        }
    }

    IEnumerator DestroyDice()
    {
        yield return new WaitForSeconds(1.3f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Limit"))
        {
            veloc *= -1;
            actualRotation = Random.Range(1, 360);
        } 
    }
}
