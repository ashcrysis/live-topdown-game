using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sliderHandler : MonoBehaviour
{
    private List<Vector2> positions = new List<Vector2>(3);
    private RectTransform pos;
    public ItemControlelr itemHandler;
    void Start()
    {   
        positions.Add(new Vector2(-366,-162));
        positions.Add(new Vector2(-266,-162));
        positions.Add(new Vector2(-166,-162));

        pos = gameObject.GetComponent<RectTransform>();
        }
        void Update()
        {
            pos.localPosition = positions[itemHandler.itemIndexAux];
        }

}
