using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    [SerializeField] public GameObject arrowArm;

    public Rigidbody2D rb; 
    private Transform originalTransform;

    private void Start()
    {
        originalTransform = transform;
        rb = GetComponent<Rigidbody2D>();        
    }

    public void EnablePhysics()
    {
        rb.simulated = true;
        arrowArm.SetActive(false);
    }

    public void DisablePhysics()
    {
        rb.simulated = false;
        arrowArm.SetActive(true);
    }

    public void ResetObject()
    {
        DisablePhysics();
        transform.position = originalTransform.position;
        transform.rotation = originalTransform.rotation;
    }
}
