


using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketLAUNCH : MonoBehaviour
{
   
    
    
    [SerializeField] float mainThrust = 550f;
    [SerializeField] float rotateThrust = 50f;
    new Rigidbody rigidbody;
    // Start is called before the first frame update

    void Start()
    {
        rigidbody = GameObject.Find("Rocket").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {


        float rotateThrustframe = rotateThrust * Time.deltaTime;




        Thrust();
        Rotate();

         
    }

    void Thrust()
    {
        float mainThrustframe = mainThrust * Time.deltaTime;


        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody.AddRelativeForce(Vector3.up * mainThrustframe);

        }


    }

    void Rotate()
    {

        float rotateThrustframe = rotateThrust * Time.deltaTime;
        rigidbody.freezeRotation = true;


        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotateThrustframe);

        }





        else if (Input.GetKey(KeyCode.D))
        {

            transform.Rotate(-Vector3.forward * rotateThrustframe);


        }

        rigidbody.freezeRotation = false;

    }



  void OnCollisionEnter(Collision collision)
    {

        switch (collision.gameObject.tag)
        {

            case "Friendly":
                {
                    
                        break;
                        }

            case "Endpoint":
                {
                    SceneManager.LoadScene(1);
                    break;
                }
            
            default:
                SceneManager.LoadScene(0);
                break;
        };



      
             
     
        }





































}





    



        





