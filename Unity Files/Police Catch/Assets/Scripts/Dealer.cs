using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine;

public class Dealer : MonoBehaviour
{
    public AudioClip bzzzt;
    public AudioClip scream;
    AudioSource audioSource;

    GameObject player;
    NavMeshAgent agent;
    public Animator animator;

    public Text pressToCatch;

    public float clickCountdown;
    public float catchRange;
    public float range = 30;
    public int health = 4;
    float multiplier = 0.2f;
    int effect;

    public float totalClicks = 0;
    float requiredClicks = 10;

    bool isDowned;
    public bool isCaught;
    public bool done;
    public bool isTazed;
    public GameObject dealerImage;

    bool playSound;
    bool soundPlayed;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        dealerImage.SetActive(false);
    }

    void Update()
    {

        player = GameObject.FindGameObjectWithTag("Player");

        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (!isTazed & !isDowned)
        {
            Vector3 runTo = transform.position + ((transform.position - player.transform.position) * multiplier);
            if (distance <= range & !isTazed)
            {
                if (soundPlayed == false)
                {
                    Debug.Log("play sound");
                    soundPlayed = true;
                    audioSource.PlayOneShot(scream, 0.7F);
                }
                agent.SetDestination(runTo);
                animator.SetBool("Walking", true);
                animator.SetBool("Tazed", false);
            }
            else
            {
                animator.SetBool("Walking", false);
                soundPlayed = false;
            }
        }

        if (distance <= catchRange & isDowned || distance <= catchRange & isTazed)
        {
            animator.SetBool("Tazed", true);
            pressToCatch.text = ("Press Q repeatedly to catch Dealer");
            if (Input.GetButtonDown("Q"))
            { totalClicks += 1; }
        }
        else { pressToCatch.text = (""); animator.SetBool("Tazed", false); }

        if (totalClicks >= 0) { totalClicks -= 1 * (Time.deltaTime * clickCountdown); }
        if (totalClicks >= requiredClicks) { Caught(); }
    }
    public void Tazed()
    {
        audioSource.PlayOneShot(bzzzt, 0.7F);

        isTazed = true;
        StartCoroutine(TazeEffect());
        GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<CatchBar>().StartBar();
    }

    void Caught()
    {
        isCaught = true;
        pressToCatch.text = ("");
        totalClicks = 0;
        gameObject.SetActive(false);
        dealerImage.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<CatchBar>().StopBar();
    }

    public IEnumerator TazeEffect()
    {
        yield return new WaitForSeconds(5);
        isTazed = false;
        GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<CatchBar>().StopBar();
    }
    public void GetRidOff()
    {
        Destroy(gameObject);
    }
}