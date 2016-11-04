using GTA;
using GTA.Native;
using GTA.Math;
using System;
using System.Windows.Forms;

public class LocationalDamage : Script
{
    private ScriptSettings config;
    bool headshots, debug;
    public LocationalDamage()
    {
        Tick += OnTick;
        config = ScriptSettings.Load("scripts\\LocationalDamage.ini");
        headshots = config.GetValue<bool>("OPTIONS", "DeadlyHeadshots", false);
        debug = config.GetValue<bool>("OPTIONS", "Debug", false);
    }

    void OnTick(object sender, EventArgs e)
    {
        Ped player = Game.Player.Character;
        int health = player.Health;
        int armor = player.Armor;

        bool ishealthreduced = false;
        bool isarmorreduced = false;

        Wait(200);
        if (health > player.Health && !GTA.Native.Function.Call<bool>(GTA.Native.Hash.HAS_PED_BEEN_DAMAGED_BY_WEAPON, player, 0, 1))
        {
            ishealthreduced = true;
            //GTA.Native.Function.Call(GTA.Native.Hash.CLEAR_PED_LAST_WEAPON_DAMAGE, player);
        }
        if (armor > player.Armor && !GTA.Native.Function.Call<bool>(GTA.Native.Hash.HAS_PED_BEEN_DAMAGED_BY_WEAPON, player, 0, 1))
        {
            isarmorreduced = true;
            //GTA.Native.Function.Call(GTA.Native.Hash.CLEAR_PED_LAST_WEAPON_DAMAGE, player);
        }

        int bone;
        unsafe
        {
            bool damaged = GTA.Native.Function.Call<bool>(GTA.Native.Hash.GET_PED_LAST_DAMAGE_BONE, Game.Player.Character, &bone);
        }
        string bonestr = "null";
        string parte = "null"; //head, body, leg, arm
        switch (bone)
        {
            case 0:
                parte = "body";
                bonestr = "SKEL_ROOT"; break;
            case 11816:
                parte = "body";
                bonestr = "SKEL_Pelvis"; break;
            case 58271:
                parte = "leg";
                bonestr = "SKEL_L_Thigh"; break;
            case 63931:
                parte = "leg";
                bonestr = "SKEL_L_Calf"; break;
            case 14201:
                parte = "leg";
                bonestr = "SKEL_L_Foot"; break;
            case 2108:
                parte = "leg";
                bonestr = "SKEL_L_Toe0"; break;
            case 65245:
                parte = "leg";
                bonestr = "IK_L_Foot"; break;
            case 57717:
                parte = "leg";
                bonestr = "PH_L_Foot"; break;
            case 46078:
                parte = "leg";
                bonestr = "MH_L_Knee"; break;
            case 51826:
                parte = "leg";
                bonestr = "SKEL_R_Thigh"; break;
            case 36864:
                parte = "leg";
                bonestr = "SKEL_R_Calf"; break;
            case 52301:
                parte = "leg";
                bonestr = "SKEL_R_Foot"; break;
            case 20781:
                parte = "leg";
                bonestr = "SKEL_R_Toe0"; break;
            case 35502:
                parte = "leg";
                bonestr = "IK_R_Foot"; break;
            case 24806:
                parte = "leg";
                bonestr = "PH_R_Foot"; break;
            case 16335:
                parte = "leg";
                bonestr = "MH_R_Knee"; break;
            case 23639:
                parte = "leg";
                bonestr = "RB_L_ThighRoll"; break;
            case 6442:
                parte = "leg";
                bonestr = "RB_R_ThighRoll"; break;
            case 57597:
                parte = "body";
                bonestr = "SKEL_Spine_Root"; break;
            case 23553:
                parte = "body";
                bonestr = "SKEL_Spine0"; break;
            case 24816:
                parte = "body";
                bonestr = "SKEL_Spine1"; break;
            case 24817:
                parte = "body";
                bonestr = "SKEL_Spine2"; break;
            case 24818:
                parte = "body";
                bonestr = "SKEL_Spine3"; break;
            case 64729:
                parte = "body";
                bonestr = "SKEL_L_Clavicle"; break;
            case 45509:
                parte = "arm";
                bonestr = "SKEL_L_UpperArm"; break;
            case 61163:
                parte = "arm";
                bonestr = "SKEL_L_Forearm"; break;
            case 18905:
                parte = "arm";
                bonestr = "SKEL_L_Hand"; break;
            case 26610:
                parte = "arm";
                bonestr = "SKEL_L_Finger00"; break;
            case 4089:
                parte = "arm";
                bonestr = "SKEL_L_Finger01"; break;
            case 4090:
                parte = "arm";
                bonestr = "SKEL_L_Finger02"; break;
            case 26611:
                parte = "arm";
                bonestr = "SKEL_L_Finger10"; break;
            case 4169:
                parte = "arm";
                bonestr = "SKEL_L_Finger11"; break;
            case 4170:
                parte = "arm";
                bonestr = "SKEL_L_Finger12"; break;
            case 26612:
                parte = "arm";
                bonestr = "SKEL_L_Finger20"; break;
            case 4185:
                parte = "arm";
                bonestr = "SKEL_L_Finger21"; break;
            case 4186:
                parte = "arm";
                bonestr = "SKEL_L_Finger22"; break;
            case 26613:
                parte = "arm";
                bonestr = "SKEL_L_Finger30"; break;
            case 4137:
                parte = "arm";
                bonestr = "SKEL_L_Finger31"; break;
            case 4138:
                parte = "arm";
                bonestr = "SKEL_L_Finger32"; break;
            case 26614:
                parte = "arm";
                bonestr = "SKEL_L_Finger40"; break;
            case 4153:
                parte = "arm";
                bonestr = "SKEL_L_Finger41"; break;
            case 4154:
                parte = "arm";
                bonestr = "SKEL_L_Finger42"; break;
            case 60309:
                parte = "arm";
                bonestr = "PH_L_Hand"; break;
            case 36029:
                parte = "arm";
                bonestr = "IK_L_Hand"; break;
            case 61007:
                parte = "arm";
                bonestr = "RB_L_ForeArmRoll"; break;
            case 5232:
                parte = "arm";
                bonestr = "RB_L_ArmRoll"; break;
            case 22711:
                parte = "arm";
                bonestr = "MH_L_Elbow"; break;
            case 10706:
                parte = "body";
                bonestr = "SKEL_R_Clavicle"; break;
            case 40269:
                parte = "arm";
                bonestr = "SKEL_R_UpperArm"; break;
            case 28252:
                parte = "arm";
                bonestr = "SKEL_R_Forearm"; break;
            case 57005:
                parte = "arm";
                bonestr = "SKEL_R_Hand"; break;
            case 58866:
                parte = "arm";
                bonestr = "SKEL_R_Finger00"; break;
            case 64016:
                parte = "arm";
                bonestr = "SKEL_R_Finger01"; break;
            case 64017:
                parte = "arm";
                bonestr = "SKEL_R_Finger02"; break;
            case 58867:
                parte = "arm";
                bonestr = "SKEL_R_Finger10"; break;
            case 64096:
                parte = "arm";
                bonestr = "SKEL_R_Finger11"; break;
            case 64097:
                parte = "arm";
                bonestr = "SKEL_R_Finger12"; break;
            case 58868:
                parte = "arm";
                bonestr = "SKEL_R_Finger20"; break;
            case 64112:
                parte = "arm";
                bonestr = "SKEL_R_Finger21"; break;
            case 64113:
                parte = "arm";
                bonestr = "SKEL_R_Finger22"; break;
            case 58869:
                parte = "arm";
                bonestr = "SKEL_R_Finger30"; break;
            case 64064:
                parte = "arm";
                bonestr = "SKEL_R_Finger31"; break;
            case 64065:
                parte = "arm";
                bonestr = "SKEL_R_Finger32"; break;
            case 58870:
                parte = "arm";
                bonestr = "SKEL_R_Finger40"; break;
            case 64080:
                parte = "arm";
                bonestr = "SKEL_R_Finger41"; break;
            case 64081:
                parte = "arm";
                bonestr = "SKEL_R_Finger42"; break;
            case 28422:
                parte = "arm";
                bonestr = "PH_R_Hand"; break;
            case 6286:
                parte = "arm";
                bonestr = "IK_R_Hand"; break;
            case 43810:
                parte = "arm";
                bonestr = "RB_R_ForeArmRoll"; break;
            case 37119:
                parte = "arm";
                bonestr = "RB_R_ArmRoll"; break;
            case 2992:
                parte = "arm";
                bonestr = "MH_R_Elbow"; break;
            case 39317:
                parte = "head";
                bonestr = "SKEL_Neck_1"; break;
            case 31086:
                parte = "head";
                bonestr = "SKEL_Head"; break;
            case 12844:
                parte = "head";
                bonestr = "IK_Head"; break;
            case 65068:
                parte = "head";
                bonestr = "FACIAL_facialRoot"; break;
            case 58331:
                parte = "head";
                bonestr = "FB_L_Brow_Out_000"; break;
            case 45750:
                parte = "head";
                bonestr = "FB_L_Lid_Upper_000"; break;
            case 25260:
                parte = "head";
                bonestr = "FB_L_Eye_000"; break;
            case 21550:
                parte = "head";
                bonestr = "FB_L_CheekBone_000"; break;
            case 29868:
                parte = "head";
                bonestr = "FB_L_Lip_Corner_000"; break;
            case 43536:
                parte = "head";
                bonestr = "FB_R_Lid_Upper_000"; break;
            case 27474:
                parte = "head";
                bonestr = "FB_R_Eye_000"; break;
            case 19336:
                parte = "head";
                bonestr = "FB_R_CheekBone_000"; break;
            case 1356:
                parte = "head";
                bonestr = "FB_R_Brow_Out_000"; break;
            case 11174:
                parte = "head";
                bonestr = "FB_R_Lip_Corner_000"; break;
            case 37193:
                parte = "head";
                bonestr = "FB_Brow_Centre_000"; break;
            case 20178:
                parte = "head";
                bonestr = "FB_UpperLipRoot_000"; break;
            case 61839:
                parte = "head";
                bonestr = "FB_UpperLip_000"; break;
            case 20279:
                parte = "head";
                bonestr = "FB_L_Lip_Top_000"; break;
            case 17719:
                parte = "head";
                bonestr = "FB_R_Lip_Top_000"; break;
            case 46240:
                parte = "head";
                bonestr = "FB_Jaw_000"; break;
            case 17188:
                parte = "head";
                bonestr = "FB_LowerLipRoot_000"; break;
            case 20623:
                parte = "head";
                bonestr = "FB_LowerLip_000"; break;
            case 47419:
                parte = "head";
                bonestr = "FB_L_Lip_Bot_000"; break;
            case 49979:
                parte = "head";
                bonestr = "FB_R_Lip_Bot_000"; break;
            case 47495:
                parte = "head";
                bonestr = "FB_Tongue_000"; break;
            case 35731:
                parte = "head";
                bonestr = "RB_Neck_1"; break;
            case 56604:
                parte = "body";
                bonestr = "IK_Root"; break;
            }
        
            if (ishealthreduced || isarmorreduced) { //headshot
                if (debug) { UI.ShowSubtitle("Damaged bone:" + bonestr + " | Part: " + parte + " | ID=" + bone.ToString()); }
                if (headshots && parte == "head") {
                    //player.Health = 0;
                    player.Kill();
                }
            }

            if (isarmorreduced && parte != "body" && !player.IsDead) { //get shot on non-body part with armor
                int dmg = armor - player.Armor;
                player.Armor = armor;
                player.Health = player.Health - dmg;
            }

        }
}