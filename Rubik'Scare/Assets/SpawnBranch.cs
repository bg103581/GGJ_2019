using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class SpawnBranch : MonoBehaviour
{
    public int branch = -1;
    public GameObject bbcubal;
    public int rotation;
    private GameObject player;
    public Material materialToon;
    public Material materialWall;
    public Material materialBBCubal;
    private Object[] spawn;
    private int index;
    private GameObject isSpawn;
    private GameObject[] allGO;

    private int k;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if(branch != -1)
        {
            Debug.Log("test");
            if (player.GetComponent<Stat>().StatUp[branch])
            {
                Debug.Log("test2");
                switch (branch)
                {
                    case 0:
                        spawn = Resources.LoadAll("Prefabs/Branches/Damage", typeof(GameObject));
                        break;
                    case 1:
                        spawn = Resources.LoadAll("Prefabs/Branches/Crouch", typeof(GameObject));
                        break;
                    case 2:
                        spawn = Resources.LoadAll("Prefabs/Branches/Jump", typeof(GameObject));
                        break;
                    case 3:
                        spawn = Resources.LoadAll("Prefabs/Branches/Speed", typeof(GameObject));
                        break;
                    default:
                        Debug.Log("Fail");
                        break;
                }
                
                index = Random.Range(0,spawn.Length);
                isSpawn=Instantiate((GameObject)spawn[index],gameObject.transform);
                Destroy(bbcubal);
                allGO = GameObject.FindGameObjectsWithTag("Ground");
                foreach (GameObject child in allGO)
                {
                    child.gameObject.GetComponent<MeshRenderer>().material = materialToon;
                }
                allGO = GameObject.FindGameObjectsWithTag("Wall");
                foreach (GameObject child in allGO)
                {
                    child.gameObject.GetComponent<MeshRenderer>().material = materialWall;
                }
                allGO = GameObject.FindGameObjectsWithTag("PNJ");
                foreach (GameObject child in allGO)
                {
                    foreach (Transform grandchild in child.transform)
                    {
                        grandchild.gameObject.GetComponent<MeshRenderer>().material = materialBBCubal;
                    }  
                }
                allGO = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject child in allGO)
                {
                    foreach (Transform grandchild in child.transform)
                    {
                        grandchild.gameObject.GetComponent<MeshRenderer>().material = materialToon;
                        foreach (Transform grandgrandchild in grandchild)
                        {
                            grandgrandchild.gameObject.GetComponent<MeshRenderer>().material = materialToon;
                        }
                        
                    }  
                }
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
