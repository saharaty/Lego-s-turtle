using UnityEngine;

public class GeckoAnimationController : MonoBehaviour
{
    public Animator animator;

    public void PlayWalk()
    {
        animator.SetTrigger("Walk");
    }

    public void PlayIdle()
    {
        animator.SetTrigger("Idle");
    }
}
