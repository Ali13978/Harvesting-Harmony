using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageTransition : MonoBehaviour
{
    public bool isTransitionStarted;
    [SerializeField] Animator anim;

    private void Update()
    {
        anim.SetBool("isTransitionStarted", isTransitionStarted);
    }

    public void StartTransition()
    {
        isTransitionStarted = true;
    }
}
