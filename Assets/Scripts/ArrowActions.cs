using UnityEngine;
using UnityEngine.EventSystems;

public class ArrowActions : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float rotateSpeed;
    [SerializeField] private Transform objectToRotate;
    [SerializeField] private bool rotateClockwise;

    // floats for max and min angle
    private float maxAngle = 90;
    private float minAngle = 0;

    // bool and flaot for controlling rotation
    private bool bRotate = false;
    private int modifier = 1;

    void Start()
    {
        // Flip the modifier if it is meant to rotate clockwise
        if (rotateClockwise)
        {
            modifier = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check current angle
        float currentAngle = objectToRotate.localRotation.z * Mathf.Rad2Deg * 2;

        // Need to check not only current angle but direction of rotation
        if (bRotate && (currentAngle < maxAngle || rotateClockwise) && (currentAngle > minAngle || !rotateClockwise))
        {
            objectToRotate.Rotate(new Vector3(0,0,rotateSpeed*modifier * Time.deltaTime));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        bRotate = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        bRotate = false;
    }
    
}
