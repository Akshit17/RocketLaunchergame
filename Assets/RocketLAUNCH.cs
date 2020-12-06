


using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketLAUNCH : MonoBehaviour
{
   
    
    
    [SerializeField] float mainThrust = 650f;
    [SerializeField] float rotateThrust = 50f;
    new Rigidbody rigidbody;
    AudioSource thrustaudio;

    enum State { Alive , Dying , Ascending};
    State state;
   
    // Start is called before the first frame update

    void Start()
    {
        rigidbody = GameObject.Find("Rocket").GetComponent<Rigidbody>();
        thrustaudio = GetComponent<AudioSource>();
        state = State.Alive ; 
    }

    // Update is called once per frame
    void Update()
    {


        float rotateThrustframe = rotateThrust * Time.deltaTime;


        if (state == State.Alive)
        {
            Thrust();
            Rotate();
        }
         
    }

    void Thrust()
    {
        float mainThrustframe = mainThrust * Time.deltaTime;


        if (Input.GetKey(KeyCode.Space))
        {
          
            rigidbody.AddRelativeForce(Vector3.up * mainThrustframe);


          


         if (!thrustaudio.isPlaying)
            {
            
                thrustaudio.Play();
          
            }


        }

        else
        {
           Invoke("StoppingSound" , 0.05f);

        }
    }

    private void StoppingSound()
    {
        thrustaudio.Stop();
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
                    state = State.Ascending;
                   Invoke("NextLevelLoad", 0.5f);
                    break;
                }

            default:
                state = State.Dying;
                Invoke("LoadFirstLevel", 0.5f);
                break;

        };



      
             
     
        }

   void NextLevelLoad()
    {
        SceneManager.LoadScene(1);
    }

     void LoadFirstLevel()
    {
        SceneManager.LoadScene(0);
    }
}





    



        





