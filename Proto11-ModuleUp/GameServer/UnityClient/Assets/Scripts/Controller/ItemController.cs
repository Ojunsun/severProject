using Google.Protobuf.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ItemController : CreatureController
{
    protected override void Init()
    {
        State = CreatureState.Moving;
        base.Init();
    }

    // 아이템 획득 감지 트리거
    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ActiveItem(other.gameObject);
        }
    }

    protected override void UpdateAnimation()
    {
        // 추후 기능 추가
    }

    protected void ActiveItem(GameObject player)
    {
        MyPlayerController mc = player.GetComponent <MyPlayerController> ();

        // 추후 기능 추가
        C_ItemGet cltemPacket = new C_ItemGet() { Iteminfo = new ItemInfo() }; 
        Debug.Log($"Creature {Id} Item Get");
        cltemPacket.Iteminfo.ItemId = Id;
        cltemPacket.Iteminfo.Name = "Coin";
        cltemPacket.Iteminfo.PosInfo = PosInfo;
        cltemPacket.PlayerObjectId = mc.Id;
        Managers.Network.Send(cltemPacket);
        Debug.Log($"Creature {mc.Id} Item Get");
    }
}