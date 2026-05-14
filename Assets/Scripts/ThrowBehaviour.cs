using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ThrowBehaviour : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [Header("Object References")]
    [SerializeField] private GameObject chargeBar;
    [SerializeField] private Image chargeBarFill;

    [Header("Throw Variables")]
    [SerializeField] private float chargeRate;
    [SerializeField] private float forceToApply;

    private bool bChargeShot;
    private float curCharge = 0;

    void Start()
    {
        chargeBar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(bChargeShot)
        {
            curCharge = Mathf.Clamp(curCharge + chargeRate * Time.deltaTime,0.0f, 1.0f);
            chargeBarFill.fillAmount = curCharge;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        chargeBar.SetActive(true);
        bChargeShot = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        bChargeShot = false;
        chargeBar.SetActive(false);
        ShootBall();
    }

    private void ShootBall()
    {
        //Activate physics and apply force
        BallBehaviour ball = FindAnyObjectByType<BallBehaviour>();
        ball.rb.AddForce(ball.arrowArm.transform.right*curCharge*forceToApply, ForceMode2D.Impulse);
        ball.EnablePhysics();

        //Reset charge bar 
        curCharge = 0;
        chargeBarFill.fillAmount = 0;
    }
}
