using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    bool isCorrect = false;
    int currentCards = 0;
    GameObject[] cards = new GameObject[2];

    private void Awake()
    {
        instance = this;
    }

    public void AddCard(GameObject card)
    {
        currentCards++;
    
        cards[currentCards - 1] = card;


        if (currentCards == 2)
        {
            currentCards = 0;
            CompareCards();
        }
    }

    private void CompareCards()
    {
        if (cards[0].GetComponent<MouseDetected>().front.material == cards[1].GetComponent<MouseDetected>().front.material)
        {
            isCorrect = true;
        }
        Debug.Log(isCorrect);

        if (isCorrect)
        {
            Destroy(cards[0].GetComponent<MouseDetected>());
            Destroy(cards[1].GetComponent<MouseDetected>());
        }
        else
        {
            cards[0].transform.rotation = Quaternion.LookRotation(-cards[0].transform.forward);
            cards[1].transform.rotation = Quaternion.LookRotation(-cards[1].transform.forward);
        }
    }

}
