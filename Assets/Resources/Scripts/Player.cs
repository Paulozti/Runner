using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform startYPosition;
    [SerializeField] private Transform jumpYPosition;
    [SerializeField] private Transform diePosition;
    [SerializeField] private GameObject lowRunningSprite;
    [SerializeField] private GameObject runningSprite;
    [SerializeField] private GameObject jumpSprite;
    [SerializeField] private GameObject deadSprite;

    private AudioSource backgroundSound;
    private AudioSource jumpSound;

    [SerializeField] private bool canJump = true;
    [SerializeField] private bool canCrouch = true;
    [SerializeField] private bool animatingDeath = false;
    public bool isDead = false;

    private bool holdingButton = false;

    private void Start()
    {
        jumpSound = jumpSprite.GetComponent<AudioSource>();
        backgroundSound = GetComponent<AudioSource>();
        backgroundSound.loop = true;
        backgroundSound.clip = (AudioClip)Resources.Load("DinoRun");
        canJump = true;
        canCrouch = true;
        animatingDeath = false;
        isDead = false;
        GameManager.isPlaying = true;
    }
    void Update()
    {
        if (!isDead)
        {
            if (GameManager.isPlaying)
                Move();
        }
        else
            Die();
    }

    private void Move()
    {
        if (holdingButton)
            return;
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
    }

    public void JumpButton()
    {
        if (canJump && GameManager.isPlaying)
        {
            StartCoroutine(Jump());
        }
    }

    public void CrouchButtonPress()
    {
        if(canCrouch && GameManager.isPlaying)
        {
            runningSprite.SetActive(false);
            lowRunningSprite.SetActive(true);
            holdingButton = true;
        }
    }
    public void CrouchButtonRelease()
    {
        runningSprite.SetActive(true);
        lowRunningSprite.SetActive(false);
        holdingButton = false;
    }
    private void Die()
    {
        if (!animatingDeath)
        {
            backgroundSound.Stop();
            backgroundSound.clip = (AudioClip)Resources.Load("Death");
            backgroundSound.loop = false;
            backgroundSound.Play();
            GameManager.isPlaying = false;
            StopAllCoroutines();
            LeanTween.cancelAll();
            animatingDeath = true;
            StartCoroutine(DieAnimation());
        }
    }

    private IEnumerator Jump()
    {
        canCrouch = false;
        canJump = false;
        runningSprite.SetActive(false);
        lowRunningSprite.SetActive(false);
        jumpSprite.SetActive(true);

        jumpSound.clip = (AudioClip)Resources.Load("JumpUp");
        jumpSound.Play();

        LeanTween.move(this.gameObject, jumpYPosition, 0.5f);
        yield return new WaitForSeconds(0.5f);
        LeanTween.move(this.gameObject, startYPosition, 0.5f);
        yield return new WaitForSeconds(0.5f);

        jumpSprite.SetActive(false);
        runningSprite.SetActive(true);
        canJump = true;
        canCrouch = true;
    }

    private IEnumerator DieAnimation()
    {
        canCrouch = false;
        canJump = false;
        runningSprite.SetActive(false);
        lowRunningSprite.SetActive(false);
        jumpSprite.SetActive(false);
        deadSprite.SetActive(true);
        LeanTween.move(this.gameObject, jumpYPosition.position, 0.5f);
        yield return new WaitForSeconds(0.5f);
        LeanTween.move(this.gameObject, diePosition, 1.5f);
        yield return new WaitForSeconds(1.5f);

        GameManager.callGameOver = true;
    }
}
