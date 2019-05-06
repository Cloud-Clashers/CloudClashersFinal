using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using XInputDotNetPure;
using UnityEngine.SceneManagement;

public class ControllerP2 : MonoBehaviour 
{

	bool playerIndexSet = false;
	PlayerIndex playerIndex;
	GamePadState state;
	GamePadState prevState;

	public GameObject P2Shield;
	public GameObject BulletPos;

	public float P2Speed = 600;

	private int pointstoadd = 1;

	public bool dash;
	public bool shield;
	public bool BigShot;


	public Vector2 savedVelocity;

	Rigidbody2D rbody;
	Animator anim;

    public GameObject StunAnim;

    //	Dash Mechanic
    public DashState dashState;
	public float dashTimer;
	public float maxDash = 2f;
	public GameObject DashIcon;
	public GameObject DashIconCharging;

	// Shield Shield
	public P2ShieldState shieldState;
	public float shieldTimer;
	public float maxShield = 2f;
	public GameObject ShieldIcon;
	public GameObject ShieldIconCharging;

	// Shoot Mechanic
	public ShootState shootState;
	public float shootTimer;
	public float maxShoot = 2f;
    public float BulletSpeed = 15f;
	public GameObject BigShotIcon;
	public GameObject BigShotIconCharging;
	public GameObject bulletGameObject;
	public GameObject PlayerBulletGO; //this is our players bullet prefab
	public GameObject bulletPosition01;

	private PlayerBullet playerbulletScript;

	public AudioSource Audio;
	public AudioClip Fireball;

	public float P2savedSpeed;

    public static bool Stun;

    int p2power = PlayerSelectionP2.P2AbilityIndex;

	// Use this for initialization
	void Start () 
	{
        Stun = false;

		rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		playerbulletScript = bulletGameObject.GetComponent<PlayerBullet>();

		playerIndex = PlayerIndex.Two;

		if (p2power == 0) 
		{
			DashIcon.SetActive (true);

		}

		if (p2power == 1) 
		{

			ShieldIcon.SetActive (true);

		}

		if (p2power == 2) 
		{

			BigShotIcon.SetActive (true);

		}


	}

	void FixedUpdate()
	{

		playerIndex = PlayerIndex.Two;

	}

	void Update () 
	{


		if (!playerIndexSet || !prevState.IsConnected)
		{
			for (int k = 0; k < 4; ++k)
			{
				PlayerIndex testPlayerIndex = (PlayerIndex)k;
				GamePadState testState = GamePad.GetState(testPlayerIndex);
				if (testState.IsConnected)
				{
					Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
					playerIndex = testPlayerIndex;
					playerIndexSet = true;
					Debug.Log ("Player two Index is: " + playerIndex);
				}
			}
		}

		prevState = state;
		state = GamePad.GetState (playerIndex);

        if (Stun == true)
        {

            StartCoroutine(Stunned());

        }

        if (playerIndex == PlayerIndex.Two) 
		{

            if (SceneManager.GetActiveScene().name == "Game (Four player)")
            {

                float moveHorizontal = 0;
                float moveVertical = state.ThumbSticks.Left.Y * P2Speed * Time.deltaTime;

                this.transform.Translate(new Vector3(moveHorizontal, moveVertical, 0f));

            }

            if (SceneManager.GetActiveScene().name == "Game")
            {
                float moveHorizontal = state.ThumbSticks.Left.X * P2Speed * Time.deltaTime;
                float moveVertical = state.ThumbSticks.Left.Y * P2Speed * Time.deltaTime;

                this.transform.Translate(new Vector3(moveHorizontal, moveVertical, 0f));

                if (p2power == 0)
                {

                    dash = true;

                }

                if (p2power == 1)
                {

                    shield = true;

                }

                if (p2power == 2)
                {

                    BigShot = true;

                }


                if (dash == true)
                {

                    switch (dashState)
                    {
                        case DashState.Ready:
						var isDashKeyDown = prevState.Buttons.X == ButtonState.Released && state.Buttons.X == ButtonState.Pressed;
                            if (isDashKeyDown)
                            {
                                P2savedSpeed = P2Speed;
                                P2Speed = P2Speed + 400;

                                DashIcon.SetActive(false);
                                DashIconCharging.SetActive(true);

                                dashState = DashState.Dashing;
                            }
                            break;
                        case DashState.Dashing:
                            dashTimer += Time.deltaTime * 3;
                            if (dashTimer >= maxDash)
                            {
                                dashTimer = maxDash;
                                P2Speed = P2savedSpeed;
                                dashState = DashState.Cooldown;
                            }
                            break;
                        case DashState.Cooldown:
                            dashTimer -= Time.deltaTime;
                            if (dashTimer <= 0)
                            {
                                dashTimer = 0;

                                FindObjectOfType<AudioManager>().Play("AbilityReady");

                                DashIcon.SetActive(true);
                                DashIconCharging.SetActive(false);

                                dashState = DashState.Ready;
                            }
                            break;
                    }

                }

                if (shield == true)
                {
                    switch (shieldState)
                    {
                        case P2ShieldState.Ready:
						var P2ShieldKeyDown = prevState.Buttons.X == ButtonState.Released && state.Buttons.X == ButtonState.Pressed;
                            if (P2ShieldKeyDown)
                            {
                                P2Shield.SetActive(true);

                                ShieldIcon.SetActive(false);
                                ShieldIconCharging.SetActive(true);

                                shieldState = P2ShieldState.Shielding;
                            }
                            break;
                        case P2ShieldState.Shielding:
                            shieldTimer += Time.deltaTime * 3;
                            if (shieldTimer >= maxShield)
                            {
                                shieldTimer = maxShield;

                                P2Shield.SetActive(false);

                                shieldState = P2ShieldState.Cooldown;
                            }
                            break;
                        case P2ShieldState.Cooldown:
                            shieldTimer -= Time.deltaTime;
                            if (shieldTimer <= 0)
                            {
                                shieldTimer = 0;

                                FindObjectOfType<AudioManager>().Play("AbilityReady");

                                ShieldIcon.SetActive(true);
                                ShieldIconCharging.SetActive(false);

                                shieldState = P2ShieldState.Ready;
                            }
                            break;
                    }
                }

                if (BigShot == true)
                {
                    switch (shootState)
                    {
                        case ShootState.Ready:
						var P1CloneKeyDown = prevState.Buttons.X == ButtonState.Released && state.Buttons.X == ButtonState.Pressed;
                            if (P1CloneKeyDown)
                            {

                                BigShotIcon.SetActive(false);
                                BigShotIconCharging.SetActive(true);

                                Audio.PlayOneShot(Fireball);

                                //instantiate the first bullet
							GameObject bullet01 = (GameObject)Instantiate(PlayerBulletGO, BulletPos.transform.position, Quaternion.identity);
                                //bullet01.transform.position = bulletPosition01.transform.position; //set the bullet initial postion

                                bullet01.GetComponent<PlayerBullet>().xspeed = -15.0f;

                                shootState = ShootState.Shooting;
                            }
                            break;
                        case ShootState.Shooting:
                            shootTimer += Time.deltaTime * 3;
                            if (shootTimer >= maxShoot)
                            {
                                shootTimer = maxShoot;

                                shootState = ShootState.Cooldown;
                            }
                            break;
                        case ShootState.Cooldown:
                            shootTimer -= Time.deltaTime;
                            if (shootTimer <= 0)
                            {
                                shootTimer = 0;

                                FindObjectOfType<AudioManager>().Play("AbilityReady");

                                BigShotIcon.SetActive(true);
                                BigShotIconCharging.SetActive(false);

                                
                                shootState = ShootState.Ready;
                            }
                            break;
                    }
                }

            }
	
		}

	}

    private IEnumerator Stunned()
    {
        StunAnim.SetActive(true);
        P2Speed = 0;
        yield return new WaitForSeconds(1f);
        StunAnim.SetActive(false);
        P2Speed = 600;
        Stun = false;
    }

    public enum DashState 
	{
		Ready,
		Dashing,
		Cooldown
	}

	public enum P2ShieldState 
	{
		Ready,
		Shielding,
		Cooldown
	}

	public enum ShootState 
	{
		Ready,
		Shooting,
		Cooldown
	}

}