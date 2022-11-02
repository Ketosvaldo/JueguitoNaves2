using UnityEngine;

public class ER_AnimationEvent : MonoBehaviour
{
    ER_PlayerController playerController;
    Animator anim;

    void Start()
    {
        playerController = FindObjectOfType<ER_PlayerController>();
        anim = GetComponent<Animator>();
    }

    void ResetShooting()
    {
        playerController.canShoot = true;
        anim.Play("Idle");
    }
}
