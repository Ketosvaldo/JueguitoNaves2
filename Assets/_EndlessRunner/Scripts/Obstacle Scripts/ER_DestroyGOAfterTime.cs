using UnityEngine;

public class ER_DestroyGOAfterTime : MonoBehaviour
{
    public float timer = 3f;

    private void Start()
    {
        Destroy(gameObject, timer);
    }
}
