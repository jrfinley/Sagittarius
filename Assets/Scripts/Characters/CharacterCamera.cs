using UnityEngine;
using System.Collections;

public class CharacterCamera : MonoBehaviour
{
    public GameObject lookTarget;

    public int yOffset;

    public float moveSpeed;

    private void FixedUpdate()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        Vector3 moveTarget = lookTarget.transform.position;
        moveTarget.y += yOffset;

        transform.position = Vector3.Lerp(transform.position, moveTarget, moveSpeed * 0.01f);
    }
}
