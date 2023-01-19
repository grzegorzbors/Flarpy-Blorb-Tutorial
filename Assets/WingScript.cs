using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingScript : MonoBehaviour
{
    void ChangeLayer(int n) {
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = n;
    }
}
