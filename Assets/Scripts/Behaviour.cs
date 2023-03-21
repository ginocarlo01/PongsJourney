using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Behaviour : MonoBehaviour
{
    public float speed = 10;

    public Vector3 velocity;

    public CharacterController controller;

    public bool jumping;

    RaycastHit[] hits;

    Vector3[] directions;

    public float wallMaxDistance = 5;

    public bool isGrounded;

    public LayerMask GroundMask;

    public Transform GroundCheck;

    public float jumpForce;

    public float gravityModifier;

    public float gravity;

    public Camera cam;

    public Transform Right, Left, Zero, rotCamDir;

    public float rotVelocity;

    public bool wallRun;

    public static Behaviour instance;

    public int coins;

    public bool canMove = false;

    public Transform cp1, cp2;

    private void Awake()
    {
        instance = this;
    }



    void Start()
    {

        directions = new Vector3[]{Vector3.left,  Vector3.right};

        controller = GetComponent<CharacterController>();

       

        if (PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "_cp2") == 1)
        {

            transform.position = cp1.position;

        }

        if (PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "_cp2") == 2)
        {

            transform.position = cp2.position;

        }
        

    }


    void Update()
    {
        if (canMove)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumping = true;
            }

            velocity.x = Input.GetAxis("Horizontal") * speed;
            velocity.z = Input.GetAxis("Vertical") * speed;

            hits = new RaycastHit[directions.Length];

            for (int i = 0; i < directions.Length; i++)
            {
                Vector3 dir = transform.TransformDirection(directions[i]);

                Physics.Raycast(transform.position, dir, out hits[i], wallMaxDistance);

                if (hits[i].collider != null)
                {
                    Debug.DrawRay(transform.position, dir * hits[i].distance, Color.green);

                    if (i == 0)
                    {
                        rotCamDir = Right;
                        break;
                    }
                    if (i == 1)
                    {
                        rotCamDir = Left;
                        break;
                    }
                }
                else
                {
                    Debug.DrawRay(transform.position, dir * wallMaxDistance, Color.red);
                    rotCamDir = Zero;
                }
            }

            isGrounded = Physics.OverlapSphere(GroundCheck.position, .3f, GroundMask).Length > 0;

            if (isGrounded)
            {
                gravity = 0;
                rotCamDir = Zero;
            }
            else
            {
                gravity = Physics.gravity.y;
            }

            velocity += gravity * gravityModifier * Time.deltaTime * Vector3.up;

            //jump
            if (isGrounded && Input.GetKeyDown(KeyCode.Space) && SceneManager.GetActiveScene().name != "Phase 5" || wallRun && Input.GetKeyDown(KeyCode.Space))
            {
                
                audioManager.instance.playSFX(1);
                velocity = new Vector3(velocity.x, jumpForce, velocity.z);
            }

            if (SceneManager.GetActiveScene().name == "Phase 5")
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    audioManager.instance.playSFX(1);
                    velocity = new Vector3(velocity.x, jumpForce, velocity.z);
                }
            }

            controller.Move(velocity * Time.deltaTime);

            if (!isGrounded && rotCamDir != Zero)
            {
                wallRun = true;
            }
            else
            {
                wallRun = false;
            }

            if (wallRun)
            {
                gravityModifier = .1f;
            }
            else
            {
                gravityModifier = 1;
            }


           //changeRot(rotCamDir);
        }
        
        
        

    }

    void changeRot(Transform rot)
    {
        cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, rot.rotation, Time.deltaTime * rotVelocity);
    }

    public void GetCoin()
    {
        coins++;
    }



    }