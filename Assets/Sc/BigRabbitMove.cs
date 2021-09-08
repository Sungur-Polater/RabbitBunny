using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigRabbitMove : MonoBehaviour
{

    private GameManager gameManager;
    public GameObject smallRabbitObj;
    public GameObject levelCompleted;
    void Awake()
    {
        gameManager = GetComponentInParent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "carrot")
        {
            Destroy(other.gameObject);

            gameManager.pointCountText++;
        }
        if (other.gameObject.tag == "finish")
        {
            levelCompleted.SetActive(true);
            Debug.Log("bitti");

        }
        if (other.gameObject.tag == "garden")
        {
            afterCollision(other);

            Debug.Log("garden");
        }
        if (other.gameObject.tag == "trap")
        {
            afterCollision(other);
            Debug.Log("trap");
        }
        if (other.gameObject.tag == "fense")
        {
            //afterCollision(other);
            GetComponent<Animator>().SetBool("run", false);
            StartCoroutine("animState" , other);
            Debug.Log("fense");
        }
    }
    void afterCollision(Collider col)
    {
        col.transform.gameObject.GetComponent<BoxCollider>().enabled = false;
        Transform[] childrens = col.transform.gameObject.GetComponentsInChildren<Transform>();
        foreach (var childrenObject in childrens)
        {
            childrenObject.gameObject.AddComponent<Rigidbody>();

        }
    }

    IEnumerator animState(Collider col)
    {
        yield return new WaitForSeconds(0.05f);
        GetComponent<Animator>().SetBool("run", true);
        yield return new WaitForSeconds(0.5f);
        col.transform.gameObject.GetComponent<BoxCollider>().enabled = false;
        Transform[] childrens = col.transform.gameObject.GetComponentsInChildren<Transform>();
        foreach (var childrenObject in childrens)
        {
            childrenObject.gameObject.AddComponent<Rigidbody>();

        }
    }

}

