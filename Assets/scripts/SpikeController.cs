using UnityEngine;

public class SpikeController : MonoBehaviour
{
    private Collider2D spikeCollider;

    void Start()
    {
        spikeCollider = GetComponent<Collider2D>();
    }

    public void ActivateCollider()
    {
        spikeCollider.enabled = true;
    }

    public void DeactivateCollider()
    {
        spikeCollider.enabled = false;
    }
}
