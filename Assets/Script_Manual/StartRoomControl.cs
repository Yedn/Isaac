using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRoomControl : MonoBehaviour
{
    [Header("RoomInformation")]
    public static Room room;
    public GameObject DoorUp, DoorDown, DoorLeft, DoorRight;//�ĸ��������
    public int DoorNum;//�м�����
    public bool LeftHasRoom, RightHasRoom, UpHasRoom, DownHasRoom;//�ĸ�������û����
    public BoxCollider2D Collider;

    public List<Collider2D> Doors = new List<Collider2D>();
    // Start is called before the first frame update
    void Start()
    {
        room = GetComponent<Room>();
        Collider = room.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
