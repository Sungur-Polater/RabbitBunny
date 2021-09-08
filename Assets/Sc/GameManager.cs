using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text pointCarrot;
    public int pointCountText = 0;
    [SerializeField] public bool smallRabbit;
    [SerializeField] public bool bigRabbit;

    public GameObject smallRabbitObj;
    public GameObject bigRabbitObj;
    private SmallRabbitMove smallRabbitMove;
    private UpDownMove upDownMove;
    private float health;


    [SerializeField] private float timeCount = 0f;
    void Awake()
    {
        smallRabbitMove = GetComponentInChildren<SmallRabbitMove>();
        upDownMove = GetComponent<UpDownMove>();
    }
    void Start()
    {
        smallRabbit = true;
        bigRabbit = false;

    }

    void FixedUpdate()
    {
        // transform.Translate(0, 0, 7 * Time.deltaTime);
        pointCarrot.text = (10 * pointCountText).ToString();
        if (smallRabbitMove.pointCount == 5)
        {
            StartCoroutine("pointIncrease"); //anında kapatırsam sc'i arttırma işlemi yapamaz
        }

        if (bigRabbit)
        {
            smallRabbitObj.SetActive(false);
            bigRabbitObj.SetActive(true);
            upDownMove.enabled = false;
            timeCount += Time.deltaTime;
            smallRabbitMove.bar.fillAmount -= (1f/7f)*Time.deltaTime;

            if (timeCount > 7)
            {
                timeCount = 0;
                bigRabbit = false;
                smallRabbit = true;
                upDownMove.enabled = true;
            }
        }
        if (smallRabbit)
        {
            smallRabbitObj.SetActive(true);
            bigRabbitObj.SetActive(false);
        }

    }
    IEnumerator pointIncrease()
    {
        yield return new WaitForSeconds(0.1f);
        smallRabbitMove.pointCount = 0;
        smallRabbit = false;
        bigRabbit = true;
    }

    public void retry(){
        SceneManager.LoadScene(0);
    }
    public void next(){
        SceneManager.LoadScene(0);
    }
}
