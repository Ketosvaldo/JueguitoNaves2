using UnityEngine;
public class PlayerAnimations : MonoBehaviour
{
    Animator anim;
    PlayerController player;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        player = GetComponent<PlayerController>();
    }

    void Update()
    {
        if ((player.horizontal != 0 || player.vertical != 0) && !player.isAttacking)
            anim.Play("Walk");
        else if (player.isAttacking)
        {
            if (player.isPunch)
            {
                switch (player.punchCombo)
                {
                    case 1: anim.Play("Punch1"); break;
                    case 2: anim.Play("Punch2"); break;
                    case 3: anim.Play("Punch3"); break;
                }
            }
        }
        else
            anim.Play("Idle");
    }
}
