using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int position;

    public GameObject activeRobot;

    [SerializeField]
    private GameObject[] robots;
    [SerializeField]
    private Game game;

    void Start()
    {
        GetComponent<BoxCollider>().enabled = false;

        foreach (GameObject robot in robots)
        {
            robot.SetActive(false);
        }

        if (activeRobot == null)
        {
            StartCoroutine("AliveTimer");
            StartCoroutine("DeathTimer");
        }
    }

    public void DisableRobot()
    {
        foreach (GameObject robot in robots)
        {
            robot.SetActive(false);
        }
        GetComponent<BoxCollider>().enabled = false;
        activeRobot = null;
        StopAllCoroutines();
    }

    // When hit by bullet
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.collider.gameObject);
        activeRobot.GetComponent<Animator>().Play("Die");
        game.AddHit();
        GetComponent<BoxCollider>().enabled = false;
        activeRobot = null;
        StartCoroutine("AliveTimer");
        StartCoroutine("DeathTimer");
    }

    public void ActivateRobot()
    {
        activeRobot = robots[Random.Range(0, 3)];
        activeRobot.SetActive(true);
        activeRobot.GetComponent<Animator>().Play("Rise");
        GetComponent<BoxCollider>().enabled = true;
    }

    public void ActivateRobot(RobotTypes type)
    {
        StopAllCoroutines();
        activeRobot = robots[(int)type];
        activeRobot.SetActive(true);
        activeRobot.GetComponent<Animator>().Play("Rise", 0, 1);
        GetComponent<BoxCollider>().enabled = true;
    }

    IEnumerator AliveTimer()
    {
        yield return new WaitForSeconds(Random.Range(2, 6));
        ActivateRobot();
    }

    IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(Random.Range(10, 14));
        if (activeRobot == null)
        {
            yield break;
        }
        activeRobot.GetComponent<Animator>().Play("Die");
        GetComponent<BoxCollider>().enabled = false;
        activeRobot = null;
        StartCoroutine("AliveTimer");
    }

    public void RefreshTimers()
    {
        StopAllCoroutines();
        StartCoroutine("AliveTimer");
        StartCoroutine("DeathTimer");
    }

    public void ResetDeathTimer()
    {
        StartCoroutine("DeathTimer");
    }
}