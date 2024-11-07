using HarmonyLib;
using iiMenu.Notifications;
using Photon.Pun;
using Photon.Realtime;
using System.IO;
using UnityEngine;
using static iiMenu.Menu.Main;

namespace iiMenu.Patches
{
    [HarmonyPatch(typeof(MonoBehaviourPunCallbacks), "OnPlayerEnteredRoom")]
    public class JoinPatch
    {
        private static void Prefix(Player newPlayer)
        {
            if (newPlayer != oldnewplayer)
            {
                NotifiLib.SendNotification("<color=grey>[</color><color=purple>JOIN</color><color=grey>] </color><color=white>Name: " + newPlayer.NickName + "</color>");
                if (customSoundOnJoin)
                {
                    if (!Directory.Exists("VapezyyMenu"))
                    {
                        Directory.CreateDirectory("VapezyyMenu");
                    }
                    File.WriteAllText("VapezyyMenu/iiMenu_CustomSoundOnJoin.txt", "PlayerJoin");
                }
                oldnewplayer = newPlayer;
            }
        }

        private static Player oldnewplayer;
    }
}