using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SpawnCube : MonoBehaviour
{


    private int xcube;

    private int zcube;
    private int k;
    private int ycube;
    private int ytest;

    public GameObject cube;

    private bool isValide = false;

    private GameObject player;

    public Text guiText;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player.GetComponent<Stat>().win) {
            player.GetComponent<Stat>().isFollowed = false;
            player.GetComponent<Stat>().mentalLifeMax = 100;
            StatUp();
            for (int i = 0; i < 5; i++) {
                if (player.GetComponent<DontDestroy>().count < 24) {
                    while (!isValide) {
                        xcube = Random.Range(0, 3);
                        zcube = Random.Range(0, 3);
                        ycube = Check(xcube, zcube);
                        if (ycube != -1) {
                            Debug.Log("x :" + xcube + " y :" + ycube + " z :" + zcube);

                            isValide = true;
                            player.GetComponent<DontDestroy>().house[ycube, xcube, zcube] = true;
                        } else {
                            isValide = false;
                        }
                    }

                    player.GetComponent<DontDestroy>().count++;
                    Instantiate(cube, new Vector3(xcube - 2, 10, zcube - 9), new Quaternion(0, 0, 0, 0));
                    isValide = false;
                } else {
                    Debug.Log("La maison est finie");
                }
            }
            player.GetComponent<Stat>().win = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.G))
        {
            if(count<24)
            {
                while (!isValide)
                {
                    xcube = Random.Range(0, 3);
                    zcube = Random.Range(0, 3);
                    ycube = Check(xcube, zcube);
                    if (ycube != -1)
                    {
                        Debug.Log("x :" +xcube+ " y :" +ycube+" z :"+zcube);
                        
                        isValide = true;
                        house[ycube, xcube, zcube] = true;
                    }
                    else
                    {
                        isValide = false;
                    }
                }

                count++;
                Instantiate(cube, new Vector3(xcube - 2, 10, zcube - 9), new Quaternion(0, 0, 0, 0));
                isValide = false;
            }
            else
            {
                Debug.Log("La maison est finie");
            }
            
            

        }*/
    }

    int Check(int x, int z)
    {
        for (ytest = 0; ytest < 3; ytest++)
        {
            if (!player.GetComponent<DontDestroy>().house[ytest, x, z])
            {
                
                return ytest;
                
            }
        }

        return -1;
    }

    void StatUp()
    {
        if(!player.GetComponent<Stat>().StatUp[0] ||
           !player.GetComponent<Stat>().StatUp[1] ||
           !player.GetComponent<Stat>().StatUp[3] ||
           !player.GetComponent<Stat>().StatUp[4])
        {
            do
            {
                k = Random.Range(0, 4);

            } while (player.GetComponent<Stat>().StatUp[k]);

            player.GetComponent<Stat>().StatUp[k] = true;

            switch (k) {
                case 0:
                    StartCoroutine(showMessage("Damage up !"));
                    break;
                case 1:
                    StartCoroutine(showMessage("Crouch available !"));
                    break;
                case 2:
                    StartCoroutine(showMessage("Double jump available !"));
                    break;
                case 3:
                    StartCoroutine(showMessage("Speed up !"));
                    break;
                default:
                    break;
            }
        }
    }

    IEnumerator showMessage(string message) {
        guiText.text = message;
        guiText.enabled = true;
        yield return new WaitForSeconds(3f);
        guiText.enabled = false;
    }
}
