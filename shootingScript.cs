using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class shootingScript : MonoBehaviour
{

    public float damage = 10f;

    private AudioSource gunShot;
    //how far the bullet travels to be recognized
    public float range = 100f;

    //ammo in the gun's magazine
    public int maxAmmo = 20;

    //max health
    public int maxHealth = 100;

    //holds current health
    public Transform remainHealthText;
    public int currhealth;

    //holds the current ammo in the mag
    public Transform remainText;
    private int currentAmmo;

    //sets the reload time for the weapon(2 seconds)
    public float reloadTime = 2f;

    //sets a boolean for reloading
    private bool isReloading = false;

    //gets the particle system for the muzzle flash. 
    public ParticleSystem muzzleFlash;

    //creates animator object
    public Animator animator;

    public Camera fpsCam;
    
    void Start()
    {
        //sets gun's ammo to max when starting the game. 
        if(currentAmmo == -1)
        {
            currentAmmo = maxAmmo;
            remainText.GetComponent<Text>().text = maxAmmo.ToString();
        }   
        gunShot = GetComponent<AudioSource>();

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Quit")){
            Cursor.lockState = CursorLockMode.None;
            NextScene();
        }
        //Source: Brackeyes
        //YouTube video
        //calls reloading function
        if(isReloading)
        {
            return;
        }
        //when person clicks the mouse button to shoot, call the shioot function. 
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            gunShot.Play();
        }

        //Source: Brackeyes
        //YouTube Video
        //if bullets get low, call the reload function. 
        if(currentAmmo<=0)
        {
            StartCoroutine(Reload());
            return;
        }

        if(Input.GetButtonDown("Jump"))
        {
            StartCoroutine(Reload());
            return;
        }

        
    }

    void Shoot()
    {
        //play muzzleflash particles
        muzzleFlash.Play();

        //decrement bullets by 1 when shooting
        currentAmmo--;
        remainText.GetComponent<Text>().text = currentAmmo.ToString();
        //variable to hold the object that the bullet hits
        RaycastHit hit;

        //Source: Brackeyes
        // Youtube Video
        //Testing purposes only
        //if the bullet hits something print out the the object it hit
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
        }


    }

    //reload function
    IEnumerator Reload()
    {
        //set reloading boolean
        isReloading = true;

        //print it is reloading
        //testing purposes
        Debug.Log("Reloading");

        //start the reloading function
        animator.SetBool("reloading", true);

        //make reloading function last 2 seconds
        yield return new WaitForSeconds(reloadTime);

        //end animation
        animator.SetBool("reloading", false);

        //reset ammo to max
        currentAmmo = maxAmmo;
        remainText.GetComponent<Text>().text = maxAmmo.ToString();
        //set boolean to false
        isReloading = false;


    }
    public void NextScene()
    {
        SceneManager.LoadScene("MAIN MENU");
    }
}
