using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SmallRabbitMove : MonoBehaviour
{

    public int pointCount = 0;
    private GameManager gameManager;
    public Image bar;
    public GameObject levelFailed;
    public GameObject levelCompleted;
    public Text carrotCount;



    void Awake()
    {
        gameManager = GetComponentInParent<GameManager>();
    }

    void Update()
    {
        carrotCount.text = gameManager.pointCarrot.text;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "carrot")
        {
            Destroy(other.gameObject);
            pointCount++;
            gameManager.pointCountText++;
            bar.fillAmount += 1 / 5f;
        }
        if (other.gameObject.tag == "finish")
        {
            levelCompleted.SetActive(true);
            Debug.Log("bitti");

        }
        if (other.gameObject.tag == "garden")
        {
            levelFailed.SetActive(true);
            Debug.Log("garden");
        }
        if (other.gameObject.tag == "trap")
        {
            StartCoroutine("trapAnim",other);
            Debug.Log("trap");
        }
        if (other.gameObject.tag == "fense")
        {
            levelFailed.SetActive(true);
            Debug.Log("fense");
        }
    }
    IEnumerator trapAnim(Collider col){
        yield return new WaitForSeconds(0.1f);
        col.transform.GetChild(1).gameObject.SetActive(false);
        col.transform.GetChild(0).DOLocalRotate(new Vector3(40f,180f,0), 0.3f);
        yield return new WaitForSeconds(0.5f);
        levelFailed.SetActive(true);
    }


}
