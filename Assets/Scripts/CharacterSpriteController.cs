using UnityEngine;

public class CharacterSpriteController : MonoBehaviour
{
    [SerializeField] private GameObject defaultPose;
    [SerializeField] private GameObject postShotPose;

    public void ToggleSprite()
    {
        if (defaultPose.activeInHierarchy)
        {
               defaultPose.SetActive(false);
               postShotPose.SetActive(true);
        }
        else
        {
            defaultPose.SetActive(true);
            postShotPose.SetActive(false);
        }
    }

    public void ResetToDefault()
    {
        defaultPose.SetActive(true);
        postShotPose.SetActive(false);
    }
}
