using UnityEngine;
using System.Collections;

public class ConnectionGizmos : MonoBehaviour
{
    public Color color = Color.cyan;
    public bool draw = true;

    void OnDrawGizmos()
    {
        if (draw)
        {
            Gizmos.color = color;
            Gizmos.DrawSphere(transform.position, 0.1f);
        }
    }
}
