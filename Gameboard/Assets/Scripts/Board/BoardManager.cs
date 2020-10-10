using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private int width;
    [SerializeField] private int heigth;

    public GameObject elementPrefab;
    public Transform _thisTransform;
    private Element[,] allElements;
    public Sprite[] pool;

    void Start()
    {
        allElements = new Element[width, heigth];

        InitBoard();
    }

    private void InitBoard()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < heigth; j++)
            {
                Vector2 pos = new Vector2(i, j);
                GameObject piece = Instantiate(elementPrefab, pos, Quaternion.identity);
                Element newElement = new Element(piece);

                newElement.piece.transform.parent = _thisTransform;
                newElement.piece.name = "( " + i + "," + j + " )";
                newElement.posX = i;
                newElement.posY = j;

                do
                {
                    newElement.type = Random.Range(0, pool.Length);
                    newElement.spriteRenderer.sprite = pool[newElement.type];
                }while (isItMatch(newElement));

                allElements[i, j] = newElement;
            }
        }
    }

    private bool isItMatch(Element _elem)
    {
        bool isMatch = false;

        if(_elem.posX > 1)
        {
            int i = 1;
            do
            {
                if (allElements[_elem.posX - i, _elem.posY].type == _elem.type)
                    isMatch = true;
                i++;
            } while (isMatch && i < 3);
        }

        if (_elem.posY > 1 && !isMatch)
        {
            int i = 1;
            do
            {
                if (allElements[_elem.posX, _elem.posY - i].type == _elem.type)
                    isMatch = true;
                i++;
            } while (isMatch && i < 3);
        }

        return isMatch;
    }

    //Vector2 tempPos = new Vector2(i, j);
    //int elementsToUse = Random.Range(0, pool.Length);
    //while (CatchMarch(pool[elementsToUse], i, j))
    //{
    //    elementsToUse = Random.Range(0, pool.Length);
    //}

    //GameObject currentElement = Instantiate(pool[elementsToUse], tempPos, Quaternion.identity);
    //currentElement.transform.parent = _thisTransform;
    //currentElement.name = "( " + i + "," + j + " )";
    //allElements[i, j] = currentElement;


}
