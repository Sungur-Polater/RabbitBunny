using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class UpDownMove : MonoBehaviour
{
    Vector2 startPos;
    int pixelDistUp = 300, pixelDistDown = -300; //sol ve saga giderken zıplamasını onlemek ıcın belirlenen kaydırma pix
    public bool clickFinger, jump = false, floorLow = false, floor = true;

    public GameObject rock , smallRabbit;
    float timer = 0;

    void Update()
    {

        if (floorLow)
        {
            timer += Time.deltaTime;
            if (timer > 0.1f)
            {
                GameObject temp = Instantiate(rock, new Vector3(transform.position.x, 0, transform.position.z), rock.transform.rotation);
                temp.transform.DOScale(new Vector3(Random.Range(0.5f,1f), Random.Range(0.5f,0.7f), Random.Range(0.5f,1f)), 0.3f);
                timer = 0;
            }
        }
        if (clickFinger == false && Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            clickFinger = true;
        }

        if (clickFinger)
        {
            if (Input.mousePosition.y >= startPos.y + pixelDistUp) //yukarı dogru hareket var
            {
                clickFinger = false;
                if (floorLow) //zemıne gırmısse zıplamak yerıne zemının ustune cıksın
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
                    smallRabbit.GetComponent<Animator>().SetBool("run",true);
                    
                }
                else if (floor)//zemınde ise zıplayabılır
                {
                    GetComponent<Rigidbody>().velocity = transform.up * 7f;
                    floor = false;
                    smallRabbit.GetComponent<Animator>().SetBool("run",false);
                    
                }
            }

            if (Input.mousePosition.y <= startPos.y + pixelDistDown) //asagı dogru hareket var
            {
                clickFinger = false;
                if (floor)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
                    smallRabbit.GetComponent<Animator>().SetBool("run",false);
                    
                }
                else if (!floorLow && !floor)
                {
                    GetComponent<Rigidbody>().velocity = -transform.up * 7f;
                }
            }

        }
    }


    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "lowFloor")
        {
            floorLow = true;
            floor = false;
            
        }
        if (collision.gameObject.tag == "floor")
        {
            floor = true;
            floorLow = false;
            //smallRabbit.GetComponent<Animator>().SetBool("run",true);
            
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "lowFloor")
        {
            floorLow = false;
        }
        if (collision.gameObject.tag == "floor")
        {
            floor = false;
            //smallRabbit.GetComponent<Animator>().SetBool("run",false);
        }
    }

    private void OnCollisionEnter(Collision collision){
         if (collision.gameObject.tag == "floor")
        {
            smallRabbit.GetComponent<Animator>().SetBool("run",true);
        }
    }

}
