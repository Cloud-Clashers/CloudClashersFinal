using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using XInputDotNetPure;
using UnityEngine.SceneManagement;

public class ControllerP1 : MonoBehaviour 
{

	bool playerIndexSet = false;
	PlayerIndex playerIndex;
	GamePadState state;
	GamePadState prevState;

	public GameObject P1Shield;

	public float P1Speed = 600;

	private int pointstoadd = 1;

	public Vector2 savedVelocity;

	Rigidbody2D rbody;
	Animator anim;

	public bool dash;
	public bool shield;
	public bool Shoot;

    public GameObject StunAnim;
	public GameObject BulletPos;

	//	Dash Mechanic
	public DashState dashState;
	public float dashTimer;
	public float maxDash = 2f;
	public GameObject DashIcon;
	public GameObject DashIconCharging;

	// Shield Mechanic
	public ShieldState shieldState;
	public float shieldTimer;
	public float maxShield = 2f;
	public GameObject ShieldIcon;
	public GameObject ShieldIconCharging;

	// BigShot Mechanic
	public ShootState shootState;
	public float shootTimer;
	public float maxShoot = 2f;
    public float bulletspeed = 5.0f;
	public GameObject BigShotIcon;
	public GameObject BigShotIconCharging;
	public GameObject bulletGameObject;
	public GameObject PlayerBulletGO; //this is our players bullet prefab
	public GameObject bulletPosition01;

	public AudioSource Audio;
	public AudioClip Fireball;

	private PlayerBullet playerbulletScript;

	public float P1savedSpeed;

    public static bool Stun;

	int p1power = PlayerSelection.P1AbilityIndex;

	// Use this for initialization
	void Start () 
	{
        Stun = false;

		rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		playerbulletScript = bulletGameObject.GetComponent<PlayerBullet>();


		if (p1power == 0) 
		{
			DashIcon.SetActive (true);

		}

		if (p1power == 1) 
		{

			ShieldIcon.SetActive (true);

		}

		if (p1power == 2) 
		{

			BigShotIcon.SetActive (true);

		}


	}

	void FixedUpdate()
	{

		playerIndex = PlayerIndex.One;

	}

	void Update ()
	{

		if (!playerIndexSet || !prevState.IsConnected) 
		{
			for (int k = 0; k < 4; k++) 
			{
				PlayerIndex testPlayerIndex = (PlayerIndex)k;
				GamePadState testState = GamePad.GetState (testPlayerIndex);
				if (testState.IsConnected) 
				{
					Debug.Log (string.Format ("GamePad found {0}", testPlayerIndex));
					playerIndex = testPlayerIndex;
					playerIndexSet = true;
					Debug.Log ("Player One Index is: " + playerIndex);
				}
			}
		}

		prevState = state;
		state = GamePad.GetState (playerIndex);

		playerIndex = PlayerIndex.One;

        if (Stun == true)
        {

            StartCoroutine(Stunned());

        }

		if (playerIndex == PlayerIndex.One) 
		{

            if (SceneManager.GetActiveScene().name == "Game (Four player)" )
            {

                float moveHorizontal = 0;
                float moveVertical = state.ThumbSticks.Left.Y * P1Speed * Time.deltaTime;

                this.transform.Translate(new Vector3(moveHorizontal, moveVertical, 0f));

            }

                if (SceneManager.GetActiveScene().name == "Game" || SceneManager.GetActiveScene().name == "Tutorial")
            {


                float moveHorizontal = state.ThumbSticks.Left.X * P1Speed * Time.deltaTime;
                float moveVertical = state.ThumbSticks.Left.Y * P1Speed * Time.deltaTime;

                this.transform.Translate(new Vector3(moveHorizontal, moveVertical, 0f));


                if (p1power == 0)
                {
                    dash = true;

                }

                if (p1power == 1)
                {
                    shield = true;

                }

                if (p1power == 2)
                {
                    Shoot = true;

                }


                if (dash == true)
                {
                    switch (dashState)
                    {
                        case DashState.Ready:
						var isDashKeyDown = prevState.Buttons.X == ButtonState.Released && state.Buttons.X == ButtonState.Pressed;
                            if (isDashKeyDown)
                            {

                                P1savedSpeed = P1Speed;
                                P1Speed = P1Speed + 400;

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
                                P1Speed = P1savedSpeed;
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
                        case ShieldState.Ready:
						var P1ShieldKeyDown = prevState.Buttons.X == ButtonState.Released && state.Buttons.X == ButtonState.Pressed;
                            if (P1ShieldKeyDown)
                            {
                                P1Shield.SetActive(true);

                                ShieldIcon.SetActive(false);
                                ShieldIconCharging.SetActive(true);


                                shieldState = ShieldState.Shielding;
                            }
                            break;
                        case ShieldState.Shielding:
                            shieldTimer += Time.deltaTime * 3;
                            if (shieldTimer >= maxShield)
                            {
                                shieldTimer = maxShield;

                                P1Shield.SetActive(false);

                                shieldState = ShieldState.Cooldown;
                            }
                            break;
                        case ShieldState.Cooldown:
                            shieldTimer -= Time.deltaTime;
                            if (shieldTimer <= 0)
                            {
                                shieldTimer = 0;

                                FindObjectOfType<AudioManager>().Play("AbilityReady");

                                ShieldIcon.SetActive(true);
                                ShieldIconCharging.SetActive(false);

                                shieldState = ShieldState.Ready;
                            }
                            break;
                    }
                }


                if (Shoot == true)
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

                                bullet01.GetComponent<PlayerBullet>().xspeed = bulletspeed;

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
        P1Speed = 0;
        yield return new WaitForSeconds(1f);
        StunAnim.SetActive(false);
        P1Speed = 600;
        Stun = false;
    }

    public enum DashState 
	{
		Ready,
		Dashing,
		Cooldown
	}

	public enum ShieldState 
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