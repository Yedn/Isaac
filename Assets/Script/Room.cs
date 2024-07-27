using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class Room : MonoBehaviour
{
    [Header("RoomInformation")]
    public static Room room;
    public GameObject DoorUp, DoorDown, DoorLeft, DoorRight;//�ĸ��������
    public int DoorNum;//�м�����
    public bool LeftHasRoom, RightHasRoom, UpHasRoom, DownHasRoom;//�ĸ�������û����
    public BoxCollider2D Collider;

    [Header("EnemyInformation")]
    public int EnemyNum;//�����ڵ�������
    public List<GameObject> EnemyList = new List<GameObject>();
    public bool isActive = false;
    public EnemyManager enemyManager;

    [Header("ExploredInformation")]
    public bool HasExploed;
    public bool PlayerInRoom = false;
    private void Awake()
    {
        room = GetComponent<Room>();
        Collider = room.GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        DoorUp.SetActive(UpHasRoom);
        DoorDown.SetActive(DownHasRoom);
        DoorRight.SetActive(RightHasRoom);
        DoorLeft.SetActive(LeftHasRoom);
    }

    public void ShouldClose()//�Ƿ�Ӧ�ù���
    {
        if (PlayerInRoom == true && (HasExploed==false))
        {
            Invoke("CloseTheDoor", 0.5f);
            isActive = true;
            foreach (GameObject enemy in EnemyList)
            {
                if (enemy.CompareTag("Clotty"))
                {
                    enemy.GetComponent<ClottyControl>().state = ClottyControl.State.Active;
                }
                else if (enemy.CompareTag("RoundWorm"))
                {
                    enemy.GetComponent<RoundWormControl>().state = RoundWormControl.State.Active;
                }
            }
           //enemyManager.isActive = true;
        }
    }

    public void ShouldOpen()
    {
        if (PlayerInRoom == true && HasExploed==true)
        {
            OpenTheDoor();
        }
    }

    public void PlayerInside()//Player�Ƿ��ڷ�����
    {
        if (Collider.bounds.Contains(GameObject.Find("PlayerControllor").transform.position))
        {
            PlayerInRoom = true;
            CameraControllor.instance.ChangeTarget(transform);
            ShouldClose();
            
        }
        else
        {
            PlayerInRoom = false;
        }
    }


    public void OpenTheDoor()//���� Show����ͼ�� && ͣ����ײ��
    {
        if (LeftHasRoom)
        {
            transform.Find("Door_left").Find("Door_L_Open").gameObject.SetActive(true);
            transform.Find("Door_left").gameObject.GetComponent<BoxCollider2D>().enabled = false;
            //Destroy(transform.Find("Door_left").gameObject.GetComponent<Rigidbody2D>());
            //Debug.Log("Opend Left");
        }
        if (UpHasRoom)
        {
            transform.Find("Door_up").Find("Door_U_Open").gameObject.SetActive(true);
            //Destroy(GameObject.Find("Door_up").GetComponent<Rigidbody2D>());
            transform.Find("Door_up").gameObject.GetComponent<BoxCollider2D>().enabled = false;
            //Destroy(GameObject.Find("Door_up").GetComponent<Rigidbody2D>());
            //Debug.Log("Opend Up");
        }
        if (DownHasRoom)
        {
            transform.Find("Door_down").Find("Door_D_Open").gameObject.SetActive(true);
            //Destroy(GameObject.Find("Door_down").GetComponent<Rigidbody2D>());
            transform.Find("Door_down").gameObject.GetComponent<BoxCollider2D>().enabled = false;
            //Destroy(GameObject.Find("Door_down").GetComponent<Rigidbody2D>());
            //Debug.Log("Opend Down");
        }
        if (RightHasRoom)
        {
            transform.Find("Door_right").Find("Door_R_Open").gameObject.SetActive(true);
            transform.Find("Door_right").gameObject.GetComponent<BoxCollider2D>().enabled=false;
            //Destroy(transform.Find("Door_right").gameObject.GetComponent<Rigidbody2D>());
            //Destroy(GameObject.Find("Door_right").GetComponent<Rigidbody2D>());
            //Debug.Log("Opend Right");
        }
    }

    public void CloseTheDoor()//���� �ؿ���ͼ�� && ������ײ��
    {
        if (LeftHasRoom)
        {
            transform.Find("Door_left").Find("Door_L_Open").gameObject.SetActive(false);
            transform.Find("Door_left").gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        if (UpHasRoom)
        {
            transform.Find("Door_up").Find("Door_U_Open").gameObject.SetActive(false);
            transform.Find("Door_up").gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        if (DownHasRoom)
        {
            transform.Find("Door_down").Find("Door_D_Open").gameObject.SetActive(false);
            transform.Find("Door_down").gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        if (RightHasRoom)
        {
            transform.Find("Door_right").Find("Door_R_Open").gameObject.SetActive(false);
            transform.Find("Door_right").gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
    /*public void UpdateRoom(float xOffset,float yOffset)//��StepToStart��DoorNum
    {
        StepToStart = (int)(Mathf.Abs(transform.position.x / xOffset) + Mathf.Abs(transform.position.y / yOffset));
        if (LeftHasRoom)
        {
            DoorNum++;
        }
        if(RightHasRoom)
        {
            DoorNum++;
        }
        if (UpHasRoom)
        {
            DoorNum++;
        }
        if (DownHasRoom)
        {
            DoorNum++;
        }
    }*/

/*    private void OnTriggerEnter2D(Collider2D collision)//������ż��
    {
        if (collision.CompareTag("Player"))
        {
            CameraControllor.instance.ChangeTarget(transform);
        }
    }*/
    /*public void ControlDoor()
    {
        if (PlayerInRoom == true && EnemyNum >0)
        {
            CloseTheDoor();
        }
        else
        {
            OpenTheDoor();
        }
    }
    
}
*/