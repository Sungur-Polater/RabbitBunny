using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Vector3 screenPoint;
    Vector3 offset;
    Vector3 realPoint;
    Vector3 realPosition;


    public float MoveRange = 2f;
    public float Speed = 5f;

    private void Update()
    {
        //Kamera ileri Hareket
        Camera.main.transform.Translate(transform.forward * Time.deltaTime * Speed, Space.World);

        //İleri Hareket
        transform.Translate(transform.forward * Time.deltaTime * Speed, Space.World);

        if (Input.GetMouseButton(0))
        {


            //Eğer range içindeyse yana harekete et
            if (transform.position.x > -MoveRange && transform.position.x < MoveRange)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    // Tıklanmayla gerçek konum arasındaki fark hesaplanıp offsete ekleniyor

                    screenPoint = Camera.main.WorldToScreenPoint(transform.position);

                    offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

                }
                if (Input.GetMouseButton(0))
                {
                    realPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
                    realPosition = Camera.main.ScreenToWorldPoint(realPoint) + offset;

                    if (realPosition.x > -MoveRange && realPosition.x < MoveRange)
                    {
                        // X ekseninde hareket için positionda sadece x parametresi değiştirildi 
                        transform.position = new Vector3(realPosition.x, transform.position.y, transform.position.z);
                    }
                }
            }

        }

    }

}
