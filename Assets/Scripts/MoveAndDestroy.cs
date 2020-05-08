using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndDestroy : MonoBehaviour
{
    public void CustomDestroy(GameObject objectToDestroy)
    {
        objectToDestroy.transform.position = transform.position;
        Destroy(objectToDestroy, 2f);
    }
}
