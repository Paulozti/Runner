using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform startYPosition;
    [SerializeField] private Transform jumpYPosition;
    [SerializeField] private GameObject lowRunningSprite;
    [SerializeField] private GameObject runningSprite;
    [SerializeField] private GameObject jumpSprite;

    [SerializeField] private bool canJump = true;
    [SerializeField] private bool canCrouch = true;

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.DownArrow) & canCrouch)
        {
            runningSprite.SetActive(false);
            lowRunningSprite.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && canJump)
        {
            StartCoroutine(Jump());
        }
        else
        {
            if (canJump)
            {
                lowRunningSprite.SetActive(false);
                runningSprite.SetActive(true);
            }
                
        }
#endif

    }



    private IEnumerator Jump()
    {
        canCrouch = false;
        canJump = false;
        runningSprite.SetActive(false);
        lowRunningSprite.SetActive(false);
        jumpSprite.SetActive(true);
        LeanTween.move(this.gameObject, jumpYPosition, 0.5f);
        yield return new WaitForSeconds(0.5f);
        LeanTween.move(this.gameObject, startYPosition, 0.5f);
        yield return new WaitForSeconds(0.5f);
        jumpSprite.SetActive(false);
        runningSprite.SetActive(true);
        canJump = true;
        canCrouch = true;
    }
}
