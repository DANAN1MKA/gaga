using UnityEngine;

public class Element
{
    public GameObject piece;
    public SpriteRenderer spriteRenderer;

    public Element(GameObject _element)
    {
        piece = _element;
        spriteRenderer = piece.GetComponent<SpriteRenderer>();
    }

    public int type { get; set;} //определяет тип элемента: 1 - топор
                                 //                         2 - меч
                                 //                         3 - лук
                                 //                         4 - зелье итд.

    //позиция элемента на доске
    public int posX { get; set; }
    public int posY { get; set; }
}
