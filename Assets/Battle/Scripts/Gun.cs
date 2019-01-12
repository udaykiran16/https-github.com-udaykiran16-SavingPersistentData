
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private GameObject _gunModel;
    [SerializeField]
    private Game game;

    private int maxRightRotation = 130;
    private int minRightRotation = 0;
    private int maxUpRotation = -60;
    private int minUpRotation = 0;
    private float cooldown = 0.5f;
    private float cooldownTimer = 1;

    // Update is called once per frame
    void Update()
    {
        if (game.IsGamePaused())
        {
            return;
        }

        float xPosPercent = Input.mousePosition.x / Screen.width;
        float yPosPercent = Input.mousePosition.y / Screen.height;
        float xVal = Mathf.Clamp(xPosPercent * maxRightRotation, minRightRotation, maxRightRotation) - 65;
        float yVal = Mathf.Clamp(yPosPercent * maxUpRotation, maxUpRotation, minUpRotation) + 10;

        transform.eulerAngles = new Vector3(yVal, xVal, 0);
        cooldownTimer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && cooldownTimer >= cooldown)
        {
            _animator.Play("Fire");
            GameObject bullet = Instantiate(_bullet);
            bullet.GetComponent<Rigidbody>().AddForce(_gunModel.transform.forward * 700);
            cooldownTimer = 0;
            game.AddShot();
            game.bullets.Add(bullet);
        }
    }
}
