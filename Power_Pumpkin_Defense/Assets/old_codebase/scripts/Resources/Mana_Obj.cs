using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana_Obj : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Resource_Mngr = GameObject.Find("Resource_Manager");
        StartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tmp = transform.position;

        float newY = StartPos.y + Mathf.PingPong(Time.time, 0.25f);
        transform.position = new Vector3(tmp.x, newY, tmp.z);

        //transform.position = new Vector3(tmp.x, StartPos.y + Mathf.Sin(Time.time * m_Bob_Speed), tmp.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Resource_Mngr.GetComponent<Resource_Manager>().GainMana(m_Mana_Amount);

            Destroy(this.gameObject);
        }
    }

    private GameObject Resource_Mngr;
    public int m_Mana_Amount;

    public float m_Bob_Speed;
    private Vector3 StartPos;
}
