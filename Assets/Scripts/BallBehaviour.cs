using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    [SerializeField] public GameObject arrowArm;


    private AudioSource audioSource;
    public Rigidbody2D rb; 
    private Transform originalTransform;

    private void Start()
    {
        originalTransform = transform;
        rb = GetComponent<Rigidbody2D>();   
        audioSource = GetComponent<AudioSource>();     
    }

    public void EnablePhysics()
    {
        rb.simulated = true;
        arrowArm.SetActive(false);
    }

    public void DisablePhysics()
    {
        rb.simulated = false;
    }

    public void ResetObject()
    {
        DisablePhysics();
        arrowArm.SetActive(true);
        transform.position = originalTransform.position;
        transform.rotation = originalTransform.rotation;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.PlayOneShot(audioSource.clip);
    }
}
