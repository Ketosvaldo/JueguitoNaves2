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
        if ((player.horizontal != 0 || player.vertical != 0) && !player.isAttacking && !player.isHitting)
            anim.Play("Walk");
        else if (player.isAttacking)
        {
            if (player.punchCombo == 1)
            {
                if (player.kickCombo == 1)
                    anim.Play("Kick1");
                else if (player.kickCombo == 2)
                    anim.Play("Kick2");
                else
                    anim.Play("Punch1");
            }
            else if (player.punchCombo == 2)
            {
                if (player.kickCombo == 1)
                    anim.Play("Kick1");
                else if (player.kickCombo == 2)
                    anim.Play("Kick2");
                else
                    anim.Play("Punch2");
            }
            else if (player.punchCombo == 3)
                anim.Play("Punch3");
            else if (player.kickCombo == 1)
                anim.Play("Kick1");
            else if (player.kickCombo == 2)
                anim.Play("Kick2");
        }
        else if (player.isHitting)
        {
            if (player.isDeath)
                anim.Play("Death");
            else
                anim.Play("Hit1");
        }
        else
            anim.Play("Idle");
    }
}
