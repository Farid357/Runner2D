using UnityEngine;

public sealed class Ground : MonoBehaviour
{

    private void Update()
    {
        if (PlayerMovement.Position.x - transform.position.x >= 16)
            gameObject.SetActive(false);
    }
}
