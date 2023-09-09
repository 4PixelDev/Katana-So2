using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    [SerializeField] private Animator CamAnim;

    public void ShakeCamera()
    {
        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            CamAnim.SetTrigger("Shake");
        }
        else if (rand == 1)
        {
            CamAnim.SetTrigger("Shake 2");
        }
    }
}
