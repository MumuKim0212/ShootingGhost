using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private int isUp;
    void FixedUpdate()
    {
        UpDown();
    }
    private void UpDown()
    {
        if (isUp == 1)
        {
            transform.DOMoveY(-0.3f, 1.5f);
            if (transform.position.y >= -0.31f)
                isUp = 0;
        }
        else
        {
            transform.DOMoveY(-0.4f, 1.5f);
            if (transform.position.y <= -0.38f)
                isUp = 1;
        }

    }
}
