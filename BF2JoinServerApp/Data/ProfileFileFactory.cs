using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF2JoinServerApp.Data
{
    public class ProfileFileFactory
    {

        /// <summary>
        /// Creates Audio.con, Controls.con, General.con, Haptic.con, mapList.con, Profile.con, 
        /// ServerSettings.con, and Video.con with their default contents
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void CreateDefaultProfileFiles(string profileFolderPath, string profileName)
        {
            // Create Audio.con file
            string audioConFilePath = Path.Combine(profileFolderPath, "Audio.con");
            StringBuilder audioConContents = new StringBuilder();
            audioConContents.AppendLine(@"AudioSettings.setVoipEnabled 1
AudioSettings.setVoipPlaybackVolume 1
AudioSettings.setVoipCaptureVolume 1
AudioSettings.setVoipCaptureThreshold 0.1
AudioSettings.setVoipBoostEnabled 0
AudioSettings.setVoipUsePushToTalk 1
AudioSettings.setProvider ""software""
AudioSettings.setSoundQuality ""Low""
AudioSettings.setEffectsVolume 1
AudioSettings.setMusicVolume 0.33
AudioSettings.setHelpVoiceVolume 1
AudioSettings.setEnglishOnlyVoices 0
AudioSettings.setEnableEAX 1");

            WriteContentsToFile(audioConFilePath, audioConContents);

            // Create Controls.con file
            string controlsFilePath = Path.Combine(profileFolderPath, "Controls.con");
            StringBuilder controlsContents = new StringBuilder();
            controlsContents.AppendLine(@"ControlMap.create InfantryPlayerInputControlMap
ControlMap.addKeysToAxisMapping c_PIYaw IDFKeyboard IDKey_D IDKey_A 0
ControlMap.addKeysToAxisMapping c_PIThrottle IDFKeyboard IDKey_W IDKey_S 0
ControlMap.addButtonToTriggerMapping c_PIFire IDFMouse IDButton_0 0 0
ControlMap.addKeyToTriggerMapping c_PIAction IDFKeyboard IDKey_Space 10000 0
ControlMap.addKeyToTriggerMapping c_PIAltSprint IDFKeyboard IDKey_W 1000 0
ControlMap.addKeyToTriggerMapping c_PISprint IDFKeyboard IDKey_LeftShift 0 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect1 IDFKeyboard IDKey_1 10000 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect2 IDFKeyboard IDKey_2 10000 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect3 IDFKeyboard IDKey_3 10000 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect4 IDFKeyboard IDKey_4 10000 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect5 IDFKeyboard IDKey_5 10000 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect6 IDFKeyboard IDKey_6 10000 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect7 IDFKeyboard IDKey_7 10000 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect8 IDFKeyboard IDKey_8 10000 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect9 IDFKeyboard IDKey_9 10000 0
ControlMap.addKeyToTriggerMapping c_PIPositionSelect1 IDFKeyboard IDKey_F1 10000 0
ControlMap.addKeyToTriggerMapping c_PIPositionSelect2 IDFKeyboard IDKey_F2 10000 0
ControlMap.addKeyToTriggerMapping c_PIPositionSelect3 IDFKeyboard IDKey_F3 10000 0
ControlMap.addKeyToTriggerMapping c_PIPositionSelect4 IDFKeyboard IDKey_F4 10000 0
ControlMap.addKeyToTriggerMapping c_PIPositionSelect5 IDFKeyboard IDKey_F5 10000 0
ControlMap.addKeyToTriggerMapping c_PIPositionSelect6 IDFKeyboard IDKey_F6 10000 0
ControlMap.addKeyToTriggerMapping c_PIPositionSelect7 IDFKeyboard IDKey_F7 10000 0
ControlMap.addKeyToTriggerMapping c_PIPositionSelect8 IDFKeyboard IDKey_F8 10000 0
ControlMap.addButtonToTriggerMapping c_PIAltFire IDFMouse IDButton_1 0 0
ControlMap.addKeyToTriggerMapping c_PIDrop IDFKeyboard IDKey_G 10000 0
ControlMap.addKeyToTriggerMapping c_PILie IDFKeyboard IDKey_Z 0 0
ControlMap.addKeyToTriggerMapping c_PICameraMode1 IDFKeyboard IDKey_F9 10000 0
ControlMap.addKeyToTriggerMapping c_PICameraMode2 IDFKeyboard IDKey_F10 10000 0
ControlMap.addKeyToTriggerMapping c_PICameraMode3 IDFKeyboard IDKey_F11 10000 0
ControlMap.addKeyToTriggerMapping c_PICameraMode4 IDFKeyboard IDKey_F12 10000 0
ControlMap.addKeyToTriggerMapping c_PIToggleWeapon IDFKeyboard IDKey_F 10000 0

ControlMap.create LandPlayerInputControlMap
ControlMap.addKeysToAxisMapping c_PIYaw IDFKeyboard IDKey_D IDKey_A 0
ControlMap.addKeysToAxisMapping c_PIThrottle IDFKeyboard IDKey_W IDKey_S 0
ControlMap.addButtonToTriggerMapping c_PIFire IDFMouse IDButton_0 0 0
ControlMap.addKeyToTriggerMapping c_PIFire IDFKeyboard IDKey_Space 0 1
ControlMap.addKeyToTriggerMapping c_PISprint IDFKeyboard IDKey_LeftShift 0 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect1 IDFKeyboard IDKey_1 10000 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect2 IDFKeyboard IDKey_2 10000 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect3 IDFKeyboard IDKey_3 10000 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect4 IDFKeyboard IDKey_4 10000 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect5 IDFKeyboard IDKey_5 10000 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect6 IDFKeyboard IDKey_6 10000 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect7 IDFKeyboard IDKey_7 10000 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect8 IDFKeyboard IDKey_8 10000 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect9 IDFKeyboard IDKey_9 10000 0
ControlMap.addKeyToTriggerMapping c_PIPositionSelect1 IDFKeyboard IDKey_F1 10000 0
ControlMap.addKeyToTriggerMapping c_PIPositionSelect2 IDFKeyboard IDKey_F2 10000 0
ControlMap.addKeyToTriggerMapping c_PIPositionSelect3 IDFKeyboard IDKey_F3 10000 0
ControlMap.addKeyToTriggerMapping c_PIPositionSelect4 IDFKeyboard IDKey_F4 10000 0
ControlMap.addKeyToTriggerMapping c_PIPositionSelect5 IDFKeyboard IDKey_F5 10000 0
ControlMap.addKeyToTriggerMapping c_PIPositionSelect6 IDFKeyboard IDKey_F6 10000 0
ControlMap.addKeyToTriggerMapping c_PIPositionSelect7 IDFKeyboard IDKey_F7 10000 0
ControlMap.addKeyToTriggerMapping c_PIPositionSelect8 IDFKeyboard IDKey_F8 10000 0
ControlMap.addButtonToTriggerMapping c_PIAltFire IDFMouse IDButton_1 0 0
ControlMap.addKeyToTriggerMapping c_PIAltFire IDFKeyboard IDKey_Numpad0 0 1
ControlMap.addKeyToTriggerMapping c_PICameraMode1 IDFKeyboard IDKey_F9 10000 0
ControlMap.addKeyToTriggerMapping c_PICameraMode2 IDFKeyboard IDKey_F10 10000 0
ControlMap.addKeyToTriggerMapping c_PICameraMode3 IDFKeyboard IDKey_F11 10000 0
ControlMap.addKeyToTriggerMapping c_PICameraMode4 IDFKeyboard IDKey_F12 10000 0
ControlMap.addKeyToTriggerMapping c_PIToggleWeapon IDFKeyboard IDKey_F 10000 0
ControlMap.addKeyToTriggerMapping c_PIFlareFire IDFKeyboard IDKey_X 0 0

ControlMap.create AirPlayerInputControlMap
ControlMap.addKeysToAxisMapping c_PIYaw IDFKeyboard IDKey_D IDKey_A 0
ControlMap.addAxisToAxisMapping c_PIPitch IDFMouse IDAxis_1 0 0
ControlMap.addKeysToAxisMapping c_PIPitch IDFKeyboard IDKey_ArrowUp IDKey_ArrowDown 1
ControlMap.addAxisToAxisMapping c_PIRoll IDFMouse IDAxis_0 0 0
ControlMap.addKeysToAxisMapping c_PIRoll IDFKeyboard IDKey_ArrowRight IDKey_ArrowLeft 1
ControlMap.addKeysToAxisMapping c_PIThrottle IDFKeyboard IDKey_W IDKey_S 0
ControlMap.addButtonToTriggerMapping c_PIFire IDFMouse IDButton_0 0 0
ControlMap.addKeyToTriggerMapping c_PIFire IDFKeyboard IDKey_Space 0 1
ControlMap.addKeyToTriggerMapping c_PIMouseLook IDFKeyboard IDKey_LeftCtrl 0 0
ControlMap.addKeyToTriggerMapping c_PIAltSprint IDFKeyboard IDKey_W 1000 0
ControlMap.addKeyToTriggerMapping c_PISprint IDFKeyboard IDKey_LeftShift 0 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect1 IDFKeyboard IDKey_1 10000 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect2 IDFKeyboard IDKey_2 10000 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect3 IDFKeyboard IDKey_3 10000 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect4 IDFKeyboard IDKey_4 10000 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect5 IDFKeyboard IDKey_5 10000 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect6 IDFKeyboard IDKey_6 10000 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect7 IDFKeyboard IDKey_7 10000 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect8 IDFKeyboard IDKey_8 10000 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect9 IDFKeyboard IDKey_9 10000 0
ControlMap.addKeyToTriggerMapping c_PIPositionSelect1 IDFKeyboard IDKey_F1 10000 0
ControlMap.addKeyToTriggerMapping c_PIPositionSelect2 IDFKeyboard IDKey_F2 10000 0
ControlMap.addKeyToTriggerMapping c_PIPositionSelect3 IDFKeyboard IDKey_F3 10000 0
ControlMap.addKeyToTriggerMapping c_PIPositionSelect4 IDFKeyboard IDKey_F4 10000 0
ControlMap.addKeyToTriggerMapping c_PIPositionSelect5 IDFKeyboard IDKey_F5 10000 0
ControlMap.addKeyToTriggerMapping c_PIPositionSelect6 IDFKeyboard IDKey_F6 10000 0
ControlMap.addKeyToTriggerMapping c_PIPositionSelect7 IDFKeyboard IDKey_F7 10000 0
ControlMap.addKeyToTriggerMapping c_PIPositionSelect8 IDFKeyboard IDKey_F8 10000 0
ControlMap.addButtonToTriggerMapping c_PIAltFire IDFMouse IDButton_1 0 0
ControlMap.addKeyToTriggerMapping c_PIAltFire IDFKeyboard IDKey_Numpad0 0 1
ControlMap.addKeyToTriggerMapping c_PICameraMode1 IDFKeyboard IDKey_F9 10000 0
ControlMap.addKeyToTriggerMapping c_PICameraMode2 IDFKeyboard IDKey_F10 10000 0
ControlMap.addKeyToTriggerMapping c_PICameraMode3 IDFKeyboard IDKey_F11 10000 0
ControlMap.addKeyToTriggerMapping c_PICameraMode4 IDFKeyboard IDKey_F12 10000 0
ControlMap.addKeyToTriggerMapping c_PIToggleWeapon IDFKeyboard IDKey_F 10000 0
ControlMap.addKeyToTriggerMapping c_PIFlareFire IDFKeyboard IDKey_X 0 0
ControlMap.mouseSensitivity 1.7

ControlMap.create HelicopterPlayerInputControlMap
ControlMap.addKeysToAxisMapping c_PIYaw IDFKeyboard IDKey_D IDKey_A 0
ControlMap.addAxisToAxisMapping c_PIPitch IDFMouse IDAxis_1 0 0
ControlMap.addKeysToAxisMapping c_PIPitch IDFKeyboard IDKey_ArrowUp IDKey_ArrowDown 1
ControlMap.addAxisToAxisMapping c_PIRoll IDFMouse IDAxis_0 0 0
ControlMap.addKeysToAxisMapping c_PIRoll IDFKeyboard IDKey_ArrowRight IDKey_ArrowLeft 1
ControlMap.addKeysToAxisMapping c_PIThrottle IDFKeyboard IDKey_W IDKey_S 0
ControlMap.addButtonToTriggerMapping c_PIFire IDFMouse IDButton_0 0 0
ControlMap.addKeyToTriggerMapping c_PIFire IDFKeyboard IDKey_Space 0 1
ControlMap.addKeyToTriggerMapping c_PIMouseLook IDFKeyboard IDKey_LeftCtrl 0 0
ControlMap.addKeyToTriggerMapping c_PIAltSprint IDFKeyboard IDKey_W 1000 0
ControlMap.addKeyToTriggerMapping c_PISprint IDFKeyboard IDKey_LeftShift 0 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect1 IDFKeyboard IDKey_1 10000 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect2 IDFKeyboard IDKey_2 10000 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect3 IDFKeyboard IDKey_3 10000 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect4 IDFKeyboard IDKey_4 10000 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect5 IDFKeyboard IDKey_5 10000 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect6 IDFKeyboard IDKey_6 10000 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect7 IDFKeyboard IDKey_7 10000 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect8 IDFKeyboard IDKey_8 10000 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect9 IDFKeyboard IDKey_9 10000 0
ControlMap.addKeyToTriggerMapping c_PIPositionSelect1 IDFKeyboard IDKey_F1 10000 0
ControlMap.addKeyToTriggerMapping c_PIPositionSelect2 IDFKeyboard IDKey_F2 10000 0
ControlMap.addKeyToTriggerMapping c_PIPositionSelect3 IDFKeyboard IDKey_F3 10000 0
ControlMap.addKeyToTriggerMapping c_PIPositionSelect4 IDFKeyboard IDKey_F4 10000 0
ControlMap.addKeyToTriggerMapping c_PIPositionSelect5 IDFKeyboard IDKey_F5 10000 0
ControlMap.addKeyToTriggerMapping c_PIPositionSelect6 IDFKeyboard IDKey_F6 10000 0
ControlMap.addKeyToTriggerMapping c_PIPositionSelect7 IDFKeyboard IDKey_F7 10000 0
ControlMap.addKeyToTriggerMapping c_PIPositionSelect8 IDFKeyboard IDKey_F8 10000 0
ControlMap.addButtonToTriggerMapping c_PIAltFire IDFMouse IDButton_1 0 0
ControlMap.addKeyToTriggerMapping c_PIAltFire IDFKeyboard IDKey_Numpad0 0 1
ControlMap.addKeyToTriggerMapping c_PICameraMode1 IDFKeyboard IDKey_F9 10000 0
ControlMap.addKeyToTriggerMapping c_PICameraMode2 IDFKeyboard IDKey_F10 10000 0
ControlMap.addKeyToTriggerMapping c_PICameraMode3 IDFKeyboard IDKey_F11 10000 0
ControlMap.addKeyToTriggerMapping c_PICameraMode4 IDFKeyboard IDKey_F12 10000 0
ControlMap.addKeyToTriggerMapping c_PIToggleWeapon IDFKeyboard IDKey_F 10000 0
ControlMap.addKeyToTriggerMapping c_PIFlareFire IDFKeyboard IDKey_X 0 0
ControlMap.mouseSensitivity 3

ControlMap.create SeaPlayerInputControlMap
ControlMap.addKeysToAxisMapping c_PIYaw IDFKeyboard IDKey_D IDKey_A 0
ControlMap.addKeysToAxisMapping c_PIPitch IDFKeyboard IDKey_ArrowUp IDKey_ArrowDown 0
ControlMap.addKeysToAxisMapping c_PIThrottle IDFKeyboard IDKey_W IDKey_S 0
ControlMap.addButtonToTriggerMapping c_PIFire IDFMouse IDButton_0 0 0
ControlMap.addKeyToTriggerMapping c_PIFire IDFKeyboard IDKey_Space 0 1
ControlMap.addKeyToTriggerMapping c_PISprint IDFKeyboard IDKey_LeftShift 0 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect1 IDFKeyboard IDKey_1 10000 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect2 IDFKeyboard IDKey_2 10000 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect3 IDFKeyboard IDKey_3 10000 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect4 IDFKeyboard IDKey_4 10000 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect5 IDFKeyboard IDKey_5 10000 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect6 IDFKeyboard IDKey_6 10000 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect7 IDFKeyboard IDKey_7 10000 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect8 IDFKeyboard IDKey_8 10000 0
ControlMap.addKeyToTriggerMapping c_PIWeaponSelect9 IDFKeyboard IDKey_9 10000 0
ControlMap.addKeyToTriggerMapping c_PIPositionSelect1 IDFKeyboard IDKey_F1 10000 0
ControlMap.addKeyToTriggerMapping c_PIPositionSelect2 IDFKeyboard IDKey_F2 10000 0
ControlMap.addKeyToTriggerMapping c_PIPositionSelect3 IDFKeyboard IDKey_F3 10000 0
ControlMap.addKeyToTriggerMapping c_PIPositionSelect4 IDFKeyboard IDKey_F4 10000 0
ControlMap.addKeyToTriggerMapping c_PIPositionSelect5 IDFKeyboard IDKey_F5 10000 0
ControlMap.addKeyToTriggerMapping c_PIPositionSelect6 IDFKeyboard IDKey_F6 10000 0
ControlMap.addKeyToTriggerMapping c_PIPositionSelect7 IDFKeyboard IDKey_F7 10000 0
ControlMap.addKeyToTriggerMapping c_PIPositionSelect8 IDFKeyboard IDKey_F8 10000 0
ControlMap.addButtonToTriggerMapping c_PIAltFire IDFMouse IDButton_1 0 0
ControlMap.addKeyToTriggerMapping c_PIAltFire IDFKeyboard IDKey_Numpad0 0 1
ControlMap.addKeyToTriggerMapping c_PICameraMode1 IDFKeyboard IDKey_F9 10000 0
ControlMap.addKeyToTriggerMapping c_PICameraMode2 IDFKeyboard IDKey_F10 10000 0
ControlMap.addKeyToTriggerMapping c_PICameraMode3 IDFKeyboard IDKey_F11 10000 0
ControlMap.addKeyToTriggerMapping c_PICameraMode4 IDFKeyboard IDKey_F12 10000 0
ControlMap.addKeyToTriggerMapping c_PIToggleWeapon IDFKeyboard IDKey_F 10000 0

ControlMap.create defaultGameControlMap
ControlMap.addAxisToAxisMapping c_GIMouseLookX IDFMouse IDAxis_0 0 0
ControlMap.addAxisToAxisMapping c_GIMouseLookY IDFMouse IDAxis_1 0 0
ControlMap.addKeyToTriggerMapping c_GIMenu IDFKeyboard IDKey_Escape 10000 0
ControlMap.addKeyToTriggerMapping c_GIToggleConsole IDFKeyboard IDKey_Grave 10000 0
ControlMap.addKeyToTriggerMapping c_GIToggleConsole IDFKeyboard IDKey_End 10000 1
ControlMap.addKeyToTriggerMapping c_GIEscape IDFKeyboard IDKey_Escape 10000 0
ControlMap.addKeyToTriggerMapping c_GIUp IDFKeyboard IDKey_ArrowUp 10000 0
ControlMap.addKeyToTriggerMapping c_GIDown IDFKeyboard IDKey_ArrowDown 10000 0
ControlMap.addKeyToTriggerMapping c_GILeft IDFKeyboard IDKey_ArrowLeft 10000 0
ControlMap.addKeyToTriggerMapping c_GIRight IDFKeyboard IDKey_ArrowRight 10000 0
ControlMap.addKeyToTriggerMapping c_GIPageUp IDFKeyboard IDKey_PageUp 10000 0
ControlMap.addKeyToTriggerMapping c_GIPageDown IDFKeyboard IDKey_PageDown 10000 0
ControlMap.addKeyToTriggerMapping c_GIRightShift IDFKeyboard IDKey_RightShift 0 0
ControlMap.addKeyToTriggerMapping c_GILeftShift IDFKeyboard IDKey_LeftShift 0 0
ControlMap.addKeyToTriggerMapping c_GILeftCtrl IDFKeyboard IDKey_LeftCtrl 0 0
ControlMap.addKeyToTriggerMapping c_GIRightCtrl IDFKeyboard IDKey_RightCtrl 10000 0
ControlMap.addKeyToTriggerMapping c_GIRightAlt IDFKeyboard IDKey_RightAlt 0 0
ControlMap.addButtonToTriggerMapping c_GIOk IDFMouse IDButton_0 0 0
ControlMap.addButtonToTriggerMapping c_GIAltOk IDFMouse IDButton_1 0 0
ControlMap.addKeyToTriggerMapping c_GIScreenShot IDFKeyboard IDKey_PrintScreen 10000 0
ControlMap.addKeyToTriggerMapping c_GITogglePause IDFKeyboard IDKey_P 10000 0
ControlMap.addKeyToTriggerMapping c_GISayAll IDFKeyboard IDKey_J 10000 0
ControlMap.addKeyToTriggerMapping c_GISayTeam IDFKeyboard IDKey_K 10000 0
ControlMap.addKeyToTriggerMapping c_GISaySquad IDFKeyboard IDKey_L 10000 0
ControlMap.addAxisToTriggerMapping c_GIMouseWheelUp -1 IDFMouse IDAxis_2 0
ControlMap.addAxisToTriggerMapping -1 c_GIMouseWheelDown IDFMouse IDAxis_2 0
ControlMap.addKeyToTriggerMapping c_GITab IDFKeyboard IDKey_Tab 10000 0
ControlMap.addKeyToTriggerMapping c_GIEnter IDFKeyboard IDKey_Enter 10000 0
ControlMap.addKeyToTriggerMapping c_GIDelete IDFKeyboard IDKey_Delete 10000 0
ControlMap.addKeyToTriggerMapping c_GIBack IDFKeyboard IDKey_Backspace 10000 0
ControlMap.addKeyToTriggerMapping c_GITacticalComm IDFKeyboard IDKey_T 0 0
ControlMap.addKeyToTriggerMapping c_GIRadioComm IDFKeyboard IDKey_Q 0 0
ControlMap.addKeyToTriggerMapping c_GIMapSize IDFKeyboard IDKey_M 10000 0
ControlMap.addKeyToTriggerMapping c_GIMapZoom IDFKeyboard IDKey_N 10000 0
ControlMap.addKeyToTriggerMapping c_GIMenuSelect0 IDFKeyboard IDKey_0 10000 0
ControlMap.addKeyToTriggerMapping c_GIMenuSelect1 IDFKeyboard IDKey_1 10000 0
ControlMap.addKeyToTriggerMapping c_GIMenuSelect2 IDFKeyboard IDKey_2 10000 0
ControlMap.addKeyToTriggerMapping c_GIMenuSelect3 IDFKeyboard IDKey_3 10000 0
ControlMap.addKeyToTriggerMapping c_GIMenuSelect4 IDFKeyboard IDKey_4 10000 0
ControlMap.addKeyToTriggerMapping c_GIMenuSelect5 IDFKeyboard IDKey_5 10000 0
ControlMap.addKeyToTriggerMapping c_GIMenuSelect6 IDFKeyboard IDKey_6 10000 0
ControlMap.addKeyToTriggerMapping c_GIMenuSelect7 IDFKeyboard IDKey_7 10000 0
ControlMap.addKeyToTriggerMapping c_GIMenuSelect8 IDFKeyboard IDKey_8 10000 0
ControlMap.addKeyToTriggerMapping c_GIMenuSelect9 IDFKeyboard IDKey_9 10000 0
ControlMap.addKeyToTriggerMapping c_GIYes IDFKeyboard IDKey_PageUp 10000 0
ControlMap.addKeyToTriggerMapping c_GINo IDFKeyboard IDKey_PageDown 10000 0
ControlMap.addKeyToTriggerMapping c_GICreateSquad IDFKeyboard IDKey_Insert 10000 0
ControlMap.addKeyToTriggerMapping c_GIToggleFreeCamera IDFKeyboard IDKey_0 10000 0
ControlMap.addKeyToTriggerMapping c_GIHotRankUp IDFKeyboard IDKey_Add 10000 0
ControlMap.addKeyToTriggerMapping c_GIShowScoreboard IDFKeyboard IDKey_Tab 0 0
ControlMap.addKeyToTriggerMapping c_GIVoipUseLeaderChannel IDFKeyboard IDKey_V 0 0
ControlMap.addKeyToTriggerMapping c_GI3dMap IDFKeyboard IDKey_LeftAlt 10000 0
ControlMap.addKeyToTriggerMapping c_GISelectAll IDFKeyboard IDKey_A 10000 0
ControlMap.addKeyToTriggerMapping c_GIDeselectAll IDFKeyboard IDKey_D 10000 0
ControlMap.addKeyToTriggerMapping c_GILeader IDFKeyboard IDKey_Capital 10000 0
ControlMap.addKeyToTriggerMapping c_GILeader IDFKeyboard IDKey_Home 10000 1
ControlMap.addKeyToTriggerMapping c_GIVoipPushToTalk IDFKeyboard IDKey_B 0 0

ControlMap.create defaultPlayerInputControlMap
ControlMap.addAxisToAxisMapping c_PIMouseLookX IDFMouse IDAxis_0 0 0
ControlMap.addAxisToAxisMapping c_PIMouseLookY IDFMouse IDAxis_1 0 0
ControlMap.addKeyToTriggerMapping c_PIUse IDFKeyboard IDKey_E 0 0
ControlMap.addKeyToTriggerMapping c_PIReload IDFKeyboard IDKey_R 10000 0
ControlMap.addKeyToTriggerMapping c_PIToggleCameraMode IDFKeyboard IDKey_C 10000 0
ControlMap.addKeyToTriggerMapping c_PICrouch IDFKeyboard IDKey_LeftCtrl 0 0
ControlMap.addAxisToTriggerMapping c_PINextItem -1 IDFMouse IDAxis_2 0
ControlMap.addAxisToTriggerMapping -1 c_PIPrevItem IDFMouse IDAxis_2 0");

            WriteContentsToFile(controlsFilePath, controlsContents);

            // Create General.con file
            string generalFilePath = Path.Combine(profileFolderPath, "General.con");
            StringBuilder generalContents = new StringBuilder();
            generalContents.AppendLine(@"GeneralSettings.setSortOrder 0
GeneralSettings.setSortKey ""
GeneralSettings.setNumRoundsPlayed 0
GeneralSettings.setServerFilter ""
GeneralSettings.setHUDTransparency 204
GeneralSettings.setCrosshairColor 255 255 0 204
GeneralSettings.setBuddytagColor 0 0 0
GeneralSettings.setSquadtagColor 0 255 0
GeneralSettings.setMinimapRotate 0
GeneralSettings.setMinimapTransparency 204
GeneralSettings.setViewIntroMovie 1
GeneralSettings.setOutOfVoting 0
GeneralSettings.setBFTVSaveDirectory ""
GeneralSettings.setConfirmQuit 0
GeneralSettings.setMapIconAlphaTransparency 255
GeneralSettings.setUseAdvancedServerBrowser 0
GeneralSettings.setUseBots 1
GeneralSettings.setMaxBots 16
GeneralSettings.setMaxBotsIncludeHumans 1
GeneralSettings.setBotSkill 0
GeneralSettings.setLastAwardsCheckDate 1691140975
GeneralSettings.setAllowPunkBuster 1
GeneralSettings.setItemSelectionReverseItems 1
GeneralSettings.setToggleFilters 63616
GeneralSettings.setAutoReload 1
GeneralSettings.setAutoReady 0
GeneralSettings.setConnectionType 5
GeneralSettings.setLCDDisplayModes 0");

            WriteContentsToFile(generalFilePath, generalContents);

            // Create General.con file
            string hapticFilePath = Path.Combine(profileFolderPath, "Haptic.con");
            StringBuilder hapticContents = new StringBuilder();
            hapticContents.AppendLine(@"rem -------------------------
rem ---Force Cap Variables---
HapticSettings.setForceCapX 50
HapticSettings.setForceCapY 50
HapticSettings.setForceCapZ 50
rem -------------------------------------
rem ---Control Box Settings (Infantry)---
HapticSettings.setControlBoxLengthSOLDIER 0.03 0.03 0.01
HapticSettings.setControlBoxStiffnessSOLDIER 760 760 760
rem -----------------------------------------
rem ---Control Box (Land Vehicle) Settings---
HapticSettings.setControlBoxLengthLAND 0.015 0.015 0.01
HapticSettings.setControlBoxStiffnessLAND 400 400 800
rem -------------------------------------
rem ---Control Box (Airplane) Settings---
HapticSettings.setControlBoxLengthAIR 0.001 0.001 0.001
HapticSettings.setControlBoxStiffnessAIR 700 700 700
rem ---------------------------------------
rem ---Control Box (Helicopter) Settings---
HapticSettings.setControlBoxLengthHELI 0.001 0.001 0.001
HapticSettings.setControlBoxStiffnessHELI 500 500 500
rem -------------------------------------
rem ---Control Box (Seacraft) Settings---
HapticSettings.setControlBoxLengthSEA 0.015 0.015 0.01
HapticSettings.setControlBoxStiffnessSEA 400 400 400
rem ---------------------------------------------
rem ---Control Sensitivity Settings (Infantry)---
HapticSettings.setAimSensitivitySOLDIER 37 37 37
HapticSettings.setAimSensitivityLengthSOLDIER 0.03 0.03 0.01
HapticSettings.setTurnSensitivitySOLDIER 5.8 5.8 5.8
rem -------------------------------------------------
rem ---Control Sensitivity (Land Vehicle) Settings---
HapticSettings.setAimSensitivityLAND 20 20 20
HapticSettings.setAimSensitivityLengthLAND 0.02 0.02 0.01
HapticSettings.setTurnSensitivityLAND 4 4 4
rem ---------------------------------------------
rem ---Control Sensitivity (Airplane) Settings---
HapticSettings.setAimSensitivityAIR 0 0 0
HapticSettings.setAimSensitivityLengthAIR 0.01 0.01 0.01
HapticSettings.setTurnSensitivityAIR 4 4 3
rem -----------------------------------------------
rem ---Control Sensitivity (Helicopter) Settings---
HapticSettings.setAimSensitivityHELI 0 0 0
HapticSettings.setAimSensitivityLengthHELI 0.01 0.01 0.02
HapticSettings.setTurnSensitivityHELI 2 2 8
rem ---------------------------------------------
rem ---Control Sensitivity (Seacraft) Settings---
HapticSettings.setAimSensitivitySEA 3 3 3
HapticSettings.setAimSensitivityLengthSEA 0.015 0.015 0.015
HapticSettings.setTurnSensitivitySEA 3 3 3
rem -----------------------------
rem ---SOLDIER Physics Settings---
HapticSettings.setPhysicsSOLDIERScale 1 1 1
HapticSettings.setPhysicsSOLDIERScaleXLow 0.03
HapticSettings.setPhysicsSOLDIERScaleYLow 0.035
HapticSettings.setPhysicsSOLDIERScaleZLow 0.06
HapticSettings.setPhysicsSOLDIERSmoothTimeXLow 10
HapticSettings.setPhysicsSOLDIERSmoothTimeYLow 20
HapticSettings.setPhysicsSOLDIERSmoothTimeZLow 10
HapticSettings.setPhysicsSOLDIERTransitionValueMed 900
HapticSettings.setPhysicsSOLDIERScaleXMed 0
HapticSettings.setPhysicsSOLDIERScaleYMed 0
HapticSettings.setPhysicsSOLDIERScaleZMed 0
HapticSettings.setPhysicsSOLDIERSmoothTimeXMed 200
HapticSettings.setPhysicsSOLDIERSmoothTimeYMed 800
HapticSettings.setPhysicsSOLDIERSmoothTimeZMed 400
HapticSettings.setPhysicsSOLDIERTransitionValueHigh 1000
HapticSettings.setPhysicsSOLDIERScaleXHigh 0
HapticSettings.setPhysicsSOLDIERScaleYHigh 0
HapticSettings.setPhysicsSOLDIERScaleZHigh 0
HapticSettings.setPhysicsSOLDIERSmoothTimeXHigh 200
HapticSettings.setPhysicsSOLDIERSmoothTimeYHigh 800
HapticSettings.setPhysicsSOLDIERSmoothTimeZHigh 400
rem -----------------------------------
rem ---Land Vehicle Physics Settings---
HapticSettings.setPhysicsLANDScale 1 1 1
HapticSettings.setPhysicsLANDScaleXLow 0.1
HapticSettings.setPhysicsLANDScaleYLow 0.2
HapticSettings.setPhysicsLANDScaleZLow 0.3
HapticSettings.setPhysicsLANDSmoothTimeXLow 50
HapticSettings.setPhysicsLANDSmoothTimeYLow 25
HapticSettings.setPhysicsLANDSmoothTimeZLow 10
HapticSettings.setPhysicsLANDTransitionValueMed 10
HapticSettings.setPhysicsLANDScaleXMed 0.1
HapticSettings.setPhysicsLANDScaleYMed 0.2
HapticSettings.setPhysicsLANDScaleZMed 0.2
HapticSettings.setPhysicsLANDSmoothTimeXMed 19
HapticSettings.setPhysicsLANDSmoothTimeYMed 30
HapticSettings.setPhysicsLANDSmoothTimeZMed 19
HapticSettings.setPhysicsLANDTransitionValueHigh 90
HapticSettings.setPhysicsLANDScaleXHigh 0.4
HapticSettings.setPhysicsLANDScaleYHigh 0.4
HapticSettings.setPhysicsLANDScaleZHigh 0.4
HapticSettings.setPhysicsLANDSmoothTimeXHigh 5
HapticSettings.setPhysicsLANDSmoothTimeYHigh 5
HapticSettings.setPhysicsLANDSmoothTimeZHigh 5
rem -------------------------------
rem ---Airplane Physics Settings---
HapticSettings.setPhysicsAIRScale 1 1 1
HapticSettings.setPhysicsAIRScaleXLow 0.2
HapticSettings.setPhysicsAIRScaleYLow 0.2
HapticSettings.setPhysicsAIRScaleZLow 0.2
HapticSettings.setPhysicsAIRSmoothTimeXLow 400
HapticSettings.setPhysicsAIRSmoothTimeYLow 150
HapticSettings.setPhysicsAIRSmoothTimeZLow 150
HapticSettings.setPhysicsAIRTransitionValueMed 100
HapticSettings.setPhysicsAIRScaleXMed 0
HapticSettings.setPhysicsAIRScaleYMed 0
HapticSettings.setPhysicsAIRScaleZMed 0
HapticSettings.setPhysicsAIRSmoothTimeXMed 150
HapticSettings.setPhysicsAIRSmoothTimeYMed 150
HapticSettings.setPhysicsAIRSmoothTimeZMed 150
HapticSettings.setPhysicsAIRTransitionValueHigh 200
HapticSettings.setPhysicsAIRScaleXHigh 0
HapticSettings.setPhysicsAIRScaleYHigh 0
HapticSettings.setPhysicsAIRScaleZHigh 0
HapticSettings.setPhysicsAIRSmoothTimeXHigh 150
HapticSettings.setPhysicsAIRSmoothTimeYHigh 150
HapticSettings.setPhysicsAIRSmoothTimeZHigh 150
rem ----------------------------------
rem ---Helicopter Physics Settings----
HapticSettings.setPhysicsHELIScale 1 1 1
HapticSettings.setPhysicsHELIScaleXLow 0.3
HapticSettings.setPhysicsHELIScaleYLow 0.3
HapticSettings.setPhysicsHELIScaleZLow 0.3
HapticSettings.setPhysicsHELISmoothTimeXLow 400
HapticSettings.setPhysicsHELISmoothTimeYLow 400
HapticSettings.setPhysicsHELISmoothTimeZLow 400
HapticSettings.setPhysicsHELITransitionValueMed 100
HapticSettings.setPhysicsHELIScaleXMed 0
HapticSettings.setPhysicsHELIScaleYMed 0
HapticSettings.setPhysicsHELIScaleZMed 0
HapticSettings.setPhysicsHELISmoothTimeXMed 150
HapticSettings.setPhysicsHELISmoothTimeYMed 150
HapticSettings.setPhysicsHELISmoothTimeZMed 150
HapticSettings.setPhysicsHELITransitionValueHigh 200
HapticSettings.setPhysicsHELIScaleXHigh 0
HapticSettings.setPhysicsHELIScaleYHigh 0
HapticSettings.setPhysicsHELIScaleZHigh 0
HapticSettings.setPhysicsHELISmoothTimeXHigh 150
HapticSettings.setPhysicsHELISmoothTimeYHigh 150
HapticSettings.setPhysicsHELISmoothTimeZHigh 150
rem ----------------------------------
rem ---Seacraft Physics Settings------
HapticSettings.setPhysicsSEAScale 1 1 1
HapticSettings.setPhysicsSEAScaleXLow 0.5
HapticSettings.setPhysicsSEAScaleYLow 0.9
HapticSettings.setPhysicsSEAScaleZLow 0.4
HapticSettings.setPhysicsSEASmoothTimeXLow 2
HapticSettings.setPhysicsSEASmoothTimeYLow 2
HapticSettings.setPhysicsSEASmoothTimeZLow 2
HapticSettings.setPhysicsSEATransitionValueMed 10
HapticSettings.setPhysicsSEAScaleXMed 0.3
HapticSettings.setPhysicsSEAScaleYMed 0.6
HapticSettings.setPhysicsSEAScaleZMed 0.4
HapticSettings.setPhysicsSEASmoothTimeXMed 4
HapticSettings.setPhysicsSEASmoothTimeYMed 4
HapticSettings.setPhysicsSEASmoothTimeZMed 4
HapticSettings.setPhysicsSEATransitionValueHigh 40
HapticSettings.setPhysicsSEAScaleXHigh 0.0006
HapticSettings.setPhysicsSEAScaleYHigh 0.0006
HapticSettings.setPhysicsSEAScaleZHigh 0.0006
HapticSettings.setPhysicsSEASmoothTimeXHigh 5
HapticSettings.setPhysicsSEASmoothTimeYHigh 5
HapticSettings.setPhysicsSEASmoothTimeZHigh 5
rem ---------------------
rem ---Damage Settings---
HapticSettings.setDamageScale 0.4
rem ------------------------------------
rem ---Recoil Settings (Pistol Class)---
HapticSettings.setRecoilPunchScalePISTOL 19
HapticSettings.setRecoilPunchTimePISTOL 3
HapticSettings.setRecoilYawScalePISTOL 0
HapticSettings.setRecoilPitchScalePISTOL 0
rem -----------------------------------
rem ---Recoil Settings (Rifle Class)---
HapticSettings.setRecoilPunchScaleRIFLE 40
HapticSettings.setRecoilPunchTimeRIFLE 2
HapticSettings.setRecoilYawScaleRIFLE 0
HapticSettings.setRecoilPitchScaleRIFLE 0
rem -------------------------------------
rem ---Recoil Settings (Carbine Class)---
HapticSettings.setRecoilPunchScaleCARBINE 40
HapticSettings.setRecoilPunchTimeCARBINE 2
HapticSettings.setRecoilYawScaleCARBINE 0
HapticSettings.setRecoilPitchScaleCARBINE 0
rem -------------------------------------
rem ---Recoil Settings (Shotgun Class)---
HapticSettings.setRecoilPunchScaleSHOTGUN 11
HapticSettings.setRecoilPunchTimeSHOTGUN 5
HapticSettings.setRecoilYawScaleSHOTGUN 0
HapticSettings.setRecoilPitchScaleSHOTGUN 0
rem ------------------------------------------
rem ---Recoil Settings (Sniper Rifle Class)---
HapticSettings.setRecoilPunchScaleSNIPER 16
HapticSettings.setRecoilPunchTimeSNIPER 6
HapticSettings.setRecoilYawScaleSNIPER 0
HapticSettings.setRecoilPitchScaleSNIPER 0
rem ----------------------------------------------------
rem ---Recoil Settings (Rifle Grenade Launcher Class)---
HapticSettings.setRecoilPunchScaleRIFLELAUNCHER 10
HapticSettings.setRecoilPunchTimeRIFLELAUNCHER 9
HapticSettings.setRecoilYawScaleRIFLELAUNCHER 0
HapticSettings.setRecoilPitchScaleRIFLELAUNCHER 0
rem ----------------------------------------------
rem ---Recoil Settings (Rocket Launcher Class)---
HapticSettings.setRecoilPunchScaleLAUNCHER 24
HapticSettings.setRecoilPunchTimeLAUNCHER 40
HapticSettings.setRecoilYawScaleLAUNCHER 0
HapticSettings.setRecoilPitchScaleLAUNCHER 0
rem -----------------------------------------------
rem ---Recoil Settings (Light Machine Gun Class)---
HapticSettings.setRecoilPunchScaleLMG 42
HapticSettings.setRecoilPunchTimeLMG 6
HapticSettings.setRecoilYawScaleLMG 0
HapticSettings.setRecoilPitchScaleLMG 0
rem ---------------------------------------------
rem ---Recoil Settings (Sub Machine Gun Class)---
HapticSettings.setRecoilPunchScaleSMG 30
HapticSettings.setRecoilPunchTimeSMG 2
HapticSettings.setRecoilYawScaleSMG 0
HapticSettings.setRecoilPitchScaleSMG 0
rem ------------------------------------------
rem ---Recoil Settings (Melee Weapon Class)---
HapticSettings.setRecoilPunchScaleKNIFE 10
HapticSettings.setRecoilPunchTimeKNIFE 50
HapticSettings.setRecoilYawScaleKNIFE 0
HapticSettings.setRecoilPitchScaleKNIFE 0
rem ---------------------------------------------
rem ---Recoil Settings (Dropped Item Class)---
HapticSettings.setRecoilPunchScaleDROP 10
HapticSettings.setRecoilPunchTimeDROP 75
HapticSettings.setRecoilYawScaleDROP 0
HapticSettings.setRecoilPitchScaleDROP 0
rem ---------------------------------------------
rem ---Recoil Settings (Thrown Item Class)---
HapticSettings.setRecoilPunchScaleTHROWN 15
HapticSettings.setRecoilPunchTimeTHROWN 80
HapticSettings.setRecoilYawScaleTHROWN 0
HapticSettings.setRecoilPitchScaleTHROWN 0
rem ---------------------------------------------
rem ---Recoil Settings (Defibrillator Class)---
HapticSettings.setRecoilPunchScaleDEFIB 40
HapticSettings.setRecoilPunchTimeDEFIB 50
HapticSettings.setRecoilYawScaleDEFIB 0
HapticSettings.setRecoilPitchScaleDEFIB 0
rem -------------------------------------------------------
rem ---Vehicle Recoil Settings (Light Machine Gun Class)---
HapticSettings.setRecoilPunchScaleV_LMG 10
HapticSettings.setRecoilPunchTimeV_LMG 2
HapticSettings.setRecoilYawScaleV_LMG 0
HapticSettings.setRecoilPitchScaleV_LMG 2
rem -------------------------------------------------------
rem ---Vehicle Recoil Settings (Heavy Machine Gun Class)---
HapticSettings.setRecoilPunchScaleV_HMG 12
HapticSettings.setRecoilPunchTimeV_HMG 4
HapticSettings.setRecoilYawScaleV_HMG 0
HapticSettings.setRecoilPitchScaleV_HMG -2
rem -------------------------------------------------------
rem ---Vehicle Recoil Settings (Helicopter Cannon Class)---
HapticSettings.setRecoilPunchScaleV_HELIGUN 12
HapticSettings.setRecoilPunchTimeV_HELIGUN 5
HapticSettings.setRecoilYawScaleV_HELIGUN 2
HapticSettings.setRecoilPitchScaleV_HELIGUN 6
rem -----------------------------------------------------
rem ---Vehicle Recoil Settings (Airplane Cannon Class)---
HapticSettings.setRecoilPunchScaleV_AIRGUN 12
HapticSettings.setRecoilPunchTimeV_AIRGUN 10
HapticSettings.setRecoilYawScaleV_AIRGUN 2
HapticSettings.setRecoilPitchScaleV_AIRGUN 6
rem -------------------------------------------------------
rem ---Vehicle Recoil Settings (Missile Launcher Class)---
HapticSettings.setRecoilPunchScaleV_MISSILE 8
HapticSettings.setRecoilPunchTimeV_MISSILE 4
HapticSettings.setRecoilYawScaleV_MISSILE 2
HapticSettings.setRecoilPitchScaleV_MISSILE 2
rem -------------------------------------------------
rem ---Vehicle Recoil Settings (Armor Cannon Class)---
HapticSettings.setRecoilPunchScaleV_ARMORCANNON 30
HapticSettings.setRecoilPunchTimeV_ARMORCANNON 8
HapticSettings.setRecoilYawScaleV_ARMORCANNON 10
HapticSettings.setRecoilPitchScaleV_ARMORCANNON 10
rem ---------------------------------------------------------
rem ---Vehicle Recoil Settings (Coaxial Machine Gun Class)---
HapticSettings.setRecoilPunchScaleV_COAXIALGUN 35
HapticSettings.setRecoilPunchTimeV_COAXIALGUN 10
HapticSettings.setRecoilYawScaleV_COAXIALGUN 2
HapticSettings.setRecoilPitchScaleV_COAXIALGUN 8
rem -------------------
rem ---Shake Effects---
HapticSettings.setGeneralShakeScale 14
HapticSettings.setExplosionShakeScale 4
HapticSettings.setSpeedShakeScale 6
rem ------------------------------
rem ---Weapon Type Template Map---
rem ***NO NEED TO EDIT THESE FOR EFFECT TUNING*********
rem ***THIS JUST MAPS WEAPON TYPES TO TEMPLATE NAME****
rem ***MOSTLY BASED OFF OF THE ''constants.py'' FILE***
HapticSettings.addWeaponClassMap usrif_m16a2 0
HapticSettings.addWeaponClassMap rurif_ak101 0
HapticSettings.addWeaponClassMap rurif_ak47 0
HapticSettings.addWeaponClassMap usrif_sa80 0
HapticSettings.addWeaponClassMap usrif_g3a3 0
HapticSettings.addWeaponClassMap usrif_m203 0
HapticSettings.addWeaponClassMap rurif_gp30 0
HapticSettings.addWeaponClassMap rurif_gp25 0
HapticSettings.addWeaponClassMap rurif_oc14 0
HapticSettings.addWeaponClassMap sasrif_fn2000 0
HapticSettings.addWeaponClassMap sasrif_g36e 0
HapticSettings.addWeaponClassMap sasrif_g36k 0
HapticSettings.addWeaponClassMap spzrif_aps 0
HapticSettings.addWeaponClassMap usrif_fnscarh 0
HapticSettings.addWeaponClassMap eurif_famas 0
HapticSettings.addWeaponClassMap gbrif_sa80a2_l85 0
HapticSettings.addWeaponClassMap usrgl_m203 1
HapticSettings.addWeaponClassMap rurgl_gp30 1
HapticSettings.addWeaponClassMap rurgl_gp25 1
HapticSettings.addWeaponClassMap sasgr_fn2000 1
HapticSettings.addWeaponClassMap gbgr_sa80a2_l85 1
HapticSettings.addWeaponClassMap rurrif_ak74u 2
HapticSettings.addWeaponClassMap usrif_m4 2
HapticSettings.addWeaponClassMap rurif_ak74u 2
HapticSettings.addWeaponClassMap chrif_type95 2
HapticSettings.addWeaponClassMap usrif_g36c 2
HapticSettings.addWeaponClassMap usrif_fnscarl 2
HapticSettings.addWeaponClassMap eurif_hk53a3 2
HapticSettings.addWeaponClassMap nsrif_crossbow 2
HapticSettings.addWeaponClassMap uslmg_m249saw 3
HapticSettings.addWeaponClassMap rulmg_rpk74 3
HapticSettings.addWeaponClassMap chlmg_type95 3
HapticSettings.addWeaponClassMap rulmg_pkm 3
HapticSettings.addWeaponClassMap sasrif_mg36 3
HapticSettings.addWeaponClassMap gbrif_hk21 3
HapticSettings.addWeaponClassMap usrif_m24 4
HapticSettings.addWeaponClassMap rurif_dragunov 4
HapticSettings.addWeaponClassMap chsni_type88 4
HapticSettings.addWeaponClassMap ussni_m82a1 4
HapticSettings.addWeaponClassMap ussni_m95_barret 4
HapticSettings.addWeaponClassMap gbrif_l96a1 4
HapticSettings.addWeaponClassMap uspis_92fs 5
HapticSettings.addWeaponClassMap uspis_92fs_silencer 5
HapticSettings.addWeaponClassMap rupis_baghira 5
HapticSettings.addWeaponClassMap rupis_baghira_silencer 5
HapticSettings.addWeaponClassMap chpis_qsz92 5
HapticSettings.addWeaponClassMap chpis_qsz92_silencer 5
HapticSettings.addWeaponClassMap usatp_predator 6
HapticSettings.addWeaponClassMap chat_eryx 6
HapticSettings.addWeaponClassMap insgr_rpg 6
HapticSettings.addWeaponClassMap usrif_mp5_a3 7
HapticSettings.addWeaponClassMap rurif_bizon 7
HapticSettings.addWeaponClassMap chrif_type85 7
HapticSettings.addWeaponClassMap sasrif_mp7 7
HapticSettings.addWeaponClassMap eurif_fnp90 7
HapticSettings.addWeaponClassMap usrif_remington11-87 8
HapticSettings.addWeaponClassMap rusht_saiga12 8
HapticSettings.addWeaponClassMap chsht_norinco982 8
HapticSettings.addWeaponClassMap chsht_protecta 8
HapticSettings.addWeaponClassMap ussht_jackhammer 8
HapticSettings.addWeaponClassMap gbrif_benelli_m4 8
HapticSettings.addWeaponClassMap kni_knife 9
HapticSettings.addWeaponClassMap c4_explosives 10
HapticSettings.addWeaponClassMap usmin_claymore 10
HapticSettings.addWeaponClassMap at_mine 10
HapticSettings.addWeaponClassMap ushgr_m67 11
HapticSettings.addWeaponClassMap hgr_smoke 11
HapticSettings.addWeaponClassMap nshgr_flashbang 11
HapticSettings.addWeaponClassMap sasrif_teargas 11
HapticSettings.addWeaponClassMap defibrillator 12
HapticSettings.addWeaponClassMap uslmg_m249saw_stationary 13
HapticSettings.addWeaponClassMap m249saw_ammo 13
HapticSettings.addWeaponClassMap chlmg_type95_stationary 13
HapticSettings.addWeaponClassMap rulmg_rpk74_stationary 13
HapticSettings.addWeaponClassMap chhmg_kord 14
HapticSettings.addWeaponClassMap hmg_h2mg 14
HapticSettings.addWeaponClassMap hmg_m2hb 14
HapticSettings.addWeaponClassMap hmg_m2hb_ammo 14
HapticSettings.addWeaponClassMap hmg_m134 14
HapticSettings.addWeaponClassMap hmg_m134_gun 14
HapticSettings.addWeaponClassMap chhmg_type85 14
HapticSettings.addWeaponClassMap ustnk_m1a2_barrel 18
HapticSettings.addWeaponClassMap tnk_type98_barrel 18
HapticSettings.addWeaponClassMap rutnk_t90_barrel 18
HapticSettings.addWeaponClassMap usapc_lav25_barrel 18
HapticSettings.addWeaponClassMap apc_wz551_barrel 18
HapticSettings.addWeaponClassMap apc_btr90__barrel 18
HapticSettings.addWeaponClassMap usaav_m6_barrel 18
HapticSettings.addWeaponClassMap aav_type95guns 18
HapticSettings.addWeaponClassMap aav_tunguska_gun 18
HapticSettings.addWeaponClassMap coaxial_browning 19
HapticSettings.addWeaponClassMap coaxial_mg_china 19
HapticSettings.addWeaponClassMap coaxial_mg_mec 19
HapticSettings.addWeaponClassMap rutnk_t90_smokelauncher 17
HapticSettings.addWeaponClassMap usapc_lav25_smokelauncher 17
HapticSettings.addWeaponClassMap usapc_lav25_towlauncher 17
HapticSettings.addWeaponClassMap apc_wz551_hj8launcher 17
HapticSettings.addWeaponClassMap apc_wz551_smokelauncher 17
HapticSettings.addWeaponClassMap apc_btr90_hj8launcher 17
HapticSettings.addWeaponClassMap apc_btr90_smokelauncher 17
HapticSettings.addWeaponClassMap usaav_m6_stinger_launcher 17
HapticSettings.addWeaponClassMap aav_type95_qw2launcher 17
HapticSettings.addWeaponClassMap aav_tunguska_sa19launcher 17
HapticSettings.addWeaponClassMap usthe_uh60_flarelauncher 17
HapticSettings.addWeaponClassMap the_mi17_flarelauncher 17
HapticSettings.addWeaponClassMap chthe_z8_flarelauncher 17
HapticSettings.addWeaponClassMap ats_tow_launcher 17
HapticSettings.addWeaponClassMap igla_djigit_launcher 17
HapticSettings.addWeaponClassMap ats_hj8_launcher 17
HapticSettings.addWeaponClassMap usaas_stinger_launcher 17
HapticSettings.addWeaponClassMap aas_seasparrow 17
HapticSettings.addWeaponClassMap aas_phalanx 17
HapticSettings.addWeaponClassMap f18_sidewinderlauncher 17
HapticSettings.addWeaponClassMap usair_f18_bomblauncher 17
HapticSettings.addWeaponClassMap usair_f15_mavericklauncherlaser 17
HapticSettings.addWeaponClassMap usair_f15_mavericklaunchertv 17
HapticSettings.addWeaponClassMap usair_f15_sidewinderlauncher 17
HapticSettings.addWeaponClassMap usair_f15_250kgbomblauncher 17
HapticSettings.addWeaponClassMap ruair_su34_kedgelauncherlaser 17
HapticSettings.addWeaponClassMap ruair_su34_kedgelaunchertv 17
HapticSettings.addWeaponClassMap ruair_su34_archerlauncher 17
HapticSettings.addWeaponClassMap ruair_su34_250kgbomblauncher 17
HapticSettings.addWeaponClassMap ruair_archerlauncher 17
HapticSettings.addWeaponClassMap ruair_mig29_bomblauncher_1 17
HapticSettings.addWeaponClassMap air_su30mkk_archerlauncher 17
HapticSettings.addWeaponClassMap air_su34mkk_bomblauncher 17
HapticSettings.addWeaponClassMap air_su30mkk_kedgelauncher_laser 17
HapticSettings.addWeaponClassMap air_su30mkk_kedgelauncher_wire 17
HapticSettings.addWeaponClassMap air_j10_archerlauncher 17
HapticSettings.addWeaponClassMap air_j10_bomblauncher 17
HapticSettings.addWeaponClassMap air_f35b_sidewinderlauncher 17
HapticSettings.addWeaponClassMap air_f35b_bomblauncher 17
HapticSettings.addWeaponClassMap ahe_z10_hj8launcher_tv 17
HapticSettings.addWeaponClassMap ahe_z10_s8launcher 17
HapticSettings.addWeaponClassMap ahe_z10_flarelauncher 17
HapticSettings.addWeaponClassMap ahe_havoc_atakalauncher_tv 17
HapticSettings.addWeaponClassMap ahe_havoc_flarelauncher 17
HapticSettings.addWeaponClassMap ahe_havoc_s8launcher 17
HapticSettings.addWeaponClassMap ahe_ah1z_cogunner_hellfirelaunchertv 17
HapticSettings.addWeaponClassMap ahe_ah1z_hydralauncher 17
HapticSettings.addWeaponClassMap ahe_ah1z_flarelauncher 17
HapticSettings.addWeaponClassMap f18_autocannon 16
HapticSettings.addWeaponClassMap usair_f15_autocannon 16
HapticSettings.addWeaponClassMap ruair_su34_30mmcannon 16
HapticSettings.addWeaponClassMap ruair_mig29_30mmcannon 16
HapticSettings.addWeaponClassMap air_su30mkk_30mmcannon 16
HapticSettings.addWeaponClassMap air_j10_cannon 16
HapticSettings.addWeaponClassMap air_f35b_autocannon 16
HapticSettings.addWeaponClassMap ahe_z10_gun 15
HapticSettings.addWeaponClassMap ahe_havoc_gun 15
HapticSettings.addWeaponClassMap ahe_ah1z_gun 15
");

            WriteContentsToFile(hapticFilePath, hapticContents);

            // Create mapList.con file
            string mapListFilePath = Path.Combine(profileFolderPath, "mapList.con");
            StringBuilder mapListContents = new StringBuilder();
            mapListContents.AppendLine(@"maplist.append ""gulf_of_oman"" ""sp1"" 16");

            WriteContentsToFile(mapListFilePath, mapListContents);

            // Create Profile.con file
            string profileFilePath = Path.Combine(profileFolderPath, "Profile.con");
            StringBuilder profileContents = new StringBuilder();
            profileContents.AppendLine($@"LocalProfile.setName ""{profileName}""
LocalProfile.setNick ""{profileName}""
LocalProfile.setGamespyNick """"
LocalProfile.setTotalPlayedTime 0
LocalProfile.setNumTimesLoggedIn 0");

            WriteContentsToFile(profileFilePath, profileContents);

            // Create ServerSettings.con file
            string serverSettingsFilePath = Path.Combine(profileFolderPath, "ServerSettings.con");
            StringBuilder serverSettingsContents = new StringBuilder();
            serverSettingsContents.AppendLine(@"GameServerSettings.setServerName ""
GameServerSettings.setPassword ""
GameServerSettings.setInternet 0
GameServerSettings.setMaxPlayers 16
GameServerSettings.setSpawnTime 15
GameServerSettings.setManDownTime 10
GameServerSettings.setTicketRatio 200
GameServerSettings.setRoundsPerMap 99
GameServerSettings.setTimeLimit 0
GameServerSettings.setScoreLimit 0
GameServerSettings.setSoldierFF 100
GameServerSettings.setVehicleFF 100
GameServerSettings.setSoldierSplashFF 100
GameServerSettings.setVehicleSplashFF 100
GameServerSettings.setPunishTeamKills 1
GameServerSettings.setVotingEnabled 1
GameServerSettings.setVoteTime 60
GameServerSettings.setMinPlayersForVoting 2
GameServerSettings.setTeamVoteOnly 1
GameServerSettings.setVoipEnabled 1
GameServerSettings.setVoipQuality 5
GameServerSettings.setVoipServerRemote 0
GameServerSettings.setVoipServerRemoteIP 
GameServerSettings.setVoipServerPort 55125
GameServerSettings.setVoipBFClientPort 55123
GameServerSettings.setVoipBFServerPort 55124
GameServerSettings.setVoipSharedPassword 
GameServerSettings.setAutoRecord 0
GameServerSettings.setSvPunkBuster 0
GameServerSettings.setTeamRatio 100
GameServerSettings.setAutoBalanceTeam 1
GameServerSettings.setFriendlyFireWithMines 103
GameServerSettings.setCoopBotRatio 50
GameServerSettings.setCoopBotCount 16
GameServerSettings.setCoopBotDifficulty 50
GameServerSettings.setNoVehicles 0
");

            WriteContentsToFile(serverSettingsFilePath, serverSettingsContents);

            // Create Video.con file
            string videoFilePath = Path.Combine(profileFolderPath, "Video.con");
            StringBuilder VideoContents = new StringBuilder();
            VideoContents.AppendLine(@"VideoSettings.setTerrainQuality 3
VideoSettings.setGeometryQuality 3
VideoSettings.setLightingQuality 3
VideoSettings.setDynamicLightingQuality 3
VideoSettings.setDynamicShadowsQuality 3
VideoSettings.setEffectsQuality 3
VideoSettings.setTextureQuality 3
VideoSettings.setTextureFilteringQuality 3
VideoSettings.setResolution 1920x1080@60Hz
VideoSettings.setAntialiasing 8Samples
VideoSettings.setViewDistanceScale 1
VideoSettings.setVideoOptionScheme 3");

            WriteContentsToFile(videoFilePath, VideoContents);
        }

        private void WriteContentsToFile(string filePath, StringBuilder contents)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(contents);
            }
        }
    }
}
