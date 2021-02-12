using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using System.Collections.Specialized;

namespace Teditor_Placement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool IsFileOpen;
        string path;
        string tmpPath = @"C:\Users\Sastr\Desktop\teditor_tmp\test.wepn";

        string joinedContent = string.Empty;
        string[] content;
        string[] splitContent;
        string[] StartWeaponConfig;
        //readonly OpenFileDialog openFile;

        string[] addWeaponResult1;
        string[] addWeaponResult2;
        string[] addWeaponResult3;
        string[] addWeaponResult4;
        string[] addWeaponResult5;
        string[] addWeaponResult6;

        string[] addAnimTurretSound;
        string[] setAngles;
        string[] setBallistics;
        string[] setFireMultFactor;
        string[] setLifetimeMult;
        string[] setMiscValues;
        string[] setMissileKiller;
        string[] setMissProperties;
        string[] setRangeBoost;
        string[] setRangeByStance;
        string[] setSpeedvsAccuracyAgainst;
        string[] setAccuracyFalloff;
        string[] setDamageFalloff;
        string[] setFrustratedTimers;
        string[] setMagneticFieldPenetration;
        string[] setDamageMultFactor;

        string[] setPenetration;
        string[] setAccuracy;

        string[] ContentObject;
        string ContentObjectType;

        int MissileKillerEnabled;
        int BallisticsEnabled;
        int OverrideEnabled;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ParseWepnFile()
        {
            string[] ObjectType = new string[]
            {
                "NewShipType",
                "NewWeaponType",
                "NewSubSystemType",
                "NewResourceType",
                "NewNebulaType"
            };
            ObjType.ItemsSource = ObjectType;

            string[] MountType = new string[]
            {
                "Fixed",
                "Gimble",
                "AnimatedTurret"
            };
            MntType.ItemsSource = MountType;

            string[] ProjectileType = new string[]
            {
                "Bullet",
                "Missile",
                "SphereBurst",
                "InstantHit",
                "Mine"
            };
            PrjType.ItemsSource = ProjectileType;

            string[] ActivationType = new string[]
            {
                "Normal",
                "Normal Only",
                "Special Attack",
                "Dropped"
            };
            ActType.ItemsSource = ActivationType;

            string[] LaunchDirection = new string[]
            {
                "0",
                "1",
                "2"
            };
            LaunchDir.ItemsSource = LaunchDirection;

            string[] Penetration = new string[]
            {
                "Normal",
                "Enhanced",
                "Bypass"
            };
            Pen.ItemsSource = Penetration;

            string[] awrCondition = new string[]
            {
                "Hit",
                "Miss"
            };
            ContentWR1_Condition.ItemsSource = awrCondition;
            ContentWR2_Condition.ItemsSource = awrCondition;
            ContentWR3_Condition.ItemsSource = awrCondition;
            ContentWR4_Condition.ItemsSource = awrCondition;
            ContentWR5_Condition.ItemsSource = awrCondition;
            ContentWR6_Condition.ItemsSource = awrCondition;

            string[] awrEffect = new string[]
            {
                "DamageHealth",
                "Disable",
                "Push",
                "SpawnWeaponFire",
                "LatchWithTarget"
            };
            ContentWR1_Effect.ItemsSource = awrEffect;
            ContentWR2_Effect.ItemsSource = awrEffect;
            ContentWR3_Effect.ItemsSource = awrEffect;
            ContentWR4_Effect.ItemsSource = awrEffect;
            ContentWR5_Effect.ItemsSource = awrEffect;
            ContentWR6_Effect.ItemsSource = awrEffect;

            string[] awrTarget = new string[]
            {
                "Target",
                "Owner"
            };
            ContentWR1_Target.ItemsSource = awrTarget;
            ContentWR2_Target.ItemsSource = awrTarget;
            ContentWR3_Target.ItemsSource = awrTarget;
            ContentWR4_Target.ItemsSource = awrTarget;
            ContentWR5_Target.ItemsSource = awrTarget;
            ContentWR6_Target.ItemsSource = awrTarget;

            int i = 0;
            foreach (string line in splitContent)
            {
                if (line.StartsWith("AddWeaponResult"))
                    switch (i)
                    {
                        case 1:
                            addWeaponResult1 = line.Split(',');
                            break;
                        case 2:
                            addWeaponResult2 = line.Split(',');
                            break;
                        case 3:
                            addWeaponResult3 = line.Split(',');
                            break;
                        case 4:
                            addWeaponResult4 = line.Split(',');
                            break;
                        case 5:
                            addWeaponResult5 = line.Split(',');
                            break;
                        case 6:
                            addWeaponResult6 = line.Split(',');
                            break;
                    }
                i++;
            }

            foreach (string line in splitContent)
            {
                if (line.StartsWith("StartWeaponConfig"))
                {
                    StartWeaponConfig = line.Split(',');
                }
                else if (line.StartsWith("addAnimTurretSound"))
                {
                    addAnimTurretSound = line.Split(',');
                    BtnAddATS.Visibility = Visibility.Collapsed;
                    BtnRemATS.Visibility = Visibility.Visible;
                    PnlATS.Visibility = Visibility.Visible;
                }
                else if (line.StartsWith("setAngles"))
                {
                    setAngles = line.Split(',');
                    BtnAddAng.Visibility = Visibility.Collapsed;
                    BtnRemAng.Visibility = Visibility.Visible;
                    PnlAng.Visibility = Visibility.Visible;
                }
                else if (line.StartsWith("setBallistics"))
                {
                    setBallistics = line.Split(',');
                    BtnAddBal.Visibility = Visibility.Collapsed;
                    BtnRemBal.Visibility = Visibility.Visible;
                    PnlBal1.Visibility = Visibility.Visible;
                    PnlBal2.Visibility = Visibility.Visible;
                }
                else if (line.StartsWith("setFireMultFactor"))
                {
                    setFireMultFactor = line.Split(',');
                    BtnAddFMF.Visibility = Visibility.Collapsed;
                    BtnRemFMF.Visibility = Visibility.Visible;
                    PnlFMF.Visibility = Visibility.Visible;
                }
                else if (line.StartsWith("setLifetimeMult"))
                {
                    setLifetimeMult = line.Split(',');
                    BtnAddLM.Visibility = Visibility.Collapsed;
                    BtnRemLM.Visibility = Visibility.Visible;
                    PnlLM.Visibility = Visibility.Visible;
                }
                else if (line.StartsWith("setMiscValues"))
                {
                    setMiscValues = line.Split(',');
                    BtnAddMV.Visibility = Visibility.Collapsed;
                    BtnRemMV.Visibility = Visibility.Visible;
                    PnlMV1.Visibility = Visibility.Visible;
                    PnlMV2.Visibility = Visibility.Visible;
                }
                else if (line.StartsWith("setMissileKiller"))
                {
                    setMissileKiller = line.Split(',');
                    BtnAddMK.Visibility = Visibility.Collapsed;
                    BtnRemMK.Visibility = Visibility.Visible;
                    PnlMK.Visibility = Visibility.Visible;
                }
                else if (line.StartsWith("setMissProperties"))
                {
                    setMissProperties = line.Split(',');
                    BtnAddMP.Visibility = Visibility.Collapsed;
                    BtnRemMP.Visibility = Visibility.Visible;
                    PnlMP.Visibility = Visibility.Visible;
                }
                else if (line.StartsWith("setRangeBoost"))
                {
                    setRangeBoost = line.Split(',');
                    BtnAddRB.Visibility = Visibility.Collapsed;
                    BtnRemRB.Visibility = Visibility.Visible;
                    PnlRB.Visibility = Visibility.Visible;
                }
                else if (line.StartsWith("setRangeByStance"))
                {
                    setRangeByStance = line.Split(',');
                    BtnAddRBS.Visibility = Visibility.Collapsed;
                    BtnRemRBS.Visibility = Visibility.Visible;
                    PnlRBS.Visibility = Visibility.Visible;
                }
                else if (line.StartsWith("setSpeedvsAccuracyAgainst"))
                {
                    setSpeedvsAccuracyAgainst = line.Split(',');
                    BtnAddSAA.Visibility = Visibility.Collapsed;
                    BtnRemSAA.Visibility = Visibility.Visible;
                    PnlSAA0.Visibility = Visibility.Visible;
                    PnlSAA1.Visibility = Visibility.Visible;
                    PnlSAA2.Visibility = Visibility.Visible;
                    PnlSAA3.Visibility = Visibility.Visible;
                    PnlSAA4.Visibility = Visibility.Visible;
                    PnlSAA5.Visibility = Visibility.Visible;
                    PnlSAA6.Visibility = Visibility.Visible;
                    PnlSAA7.Visibility = Visibility.Visible;
                }
                else if (line.StartsWith("setAccuracyFalloff"))
                {
                    setAccuracyFalloff = line.Split(',');
                    BtnAddAF.Visibility = Visibility.Collapsed;
                    BtnRemAF.Visibility = Visibility.Visible;
                    PnlAF1.Visibility = Visibility.Visible;
                    PnlAF2.Visibility = Visibility.Visible;
                }
                else if (line.StartsWith("setDamageFalloff"))
                {
                    setDamageFalloff = line.Split(',');
                    BtnAddDF.Visibility = Visibility.Collapsed;
                    BtnRemDF.Visibility = Visibility.Visible;
                    PnlDF1.Visibility = Visibility.Visible;
                    PnlDF2.Visibility = Visibility.Visible;
                }
                else if (line.StartsWith("setFrustratedTimers"))
                {
                    setFrustratedTimers = line.Split(',');
                    BtnAddFT.Visibility = Visibility.Collapsed;
                    BtnRemFT.Visibility = Visibility.Visible;
                    PnlFT1.Visibility = Visibility.Visible;
                    PnlFT2.Visibility = Visibility.Visible;
                }
                else if (line.StartsWith("setMagneticFieldPenetration"))
                {
                    setMagneticFieldPenetration = line.Split(',');
                    BtnAddMFP.Visibility = Visibility.Collapsed;
                    BtnRemMFP.Visibility = Visibility.Visible;
                    PnlMFP.Visibility = Visibility.Visible;
                }
                else if (line.StartsWith("setDamageMultFactor"))
                {
                    setDamageMultFactor = line.Split(',');
                    BtnAddDMF.Visibility = Visibility.Collapsed;
                    BtnRemDMF.Visibility = Visibility.Visible;
                    PnlDMF.Visibility = Visibility.Visible;
                }
                else if (line.StartsWith("setPenetration"))
                {
                    setPenetration = line.Split(',');
                    BtnAddPen.Visibility = Visibility.Collapsed;
                    BtnRemPen.Visibility = Visibility.Visible;
                    PnlPen.Visibility = Visibility.Visible;
                }
                else if (line.StartsWith("setAccuracy("))
                {
                    setAccuracy = line.Split(',');
                    BtnAddAcc.Visibility = Visibility.Collapsed;
                    BtnRemAcc.Visibility = Visibility.Visible;
                    PnlAcc.Visibility = Visibility.Visible;
                }
            }

            //parse startWeaponConfig
            if (content[0].StartsWith("StartWeaponConfig"))
            {
                StartWeaponConfig = content[0].Split(',');
            }
            //determine Object Type
            string[] ContentObject = StartWeaponConfig[0].Split('(');
            string ContentObjectType = ContentObject[1];
            switch (ContentObjectType)
            {
                case "NewShipType":
                    ObjType.SelectedIndex = 0;
                    break;
                case "NewWeaponType":
                    ObjType.SelectedIndex = 1;
                    break;
                case "NewSubSystemType":
                    ObjType.SelectedIndex = 2;
                    break;
                case "NewResourceType":
                    ObjType.SelectedIndex = 3;
                    break;
                case "NewNebulaType":
                    ObjType.SelectedIndex = 4;
                    break;
            }

            string ContentMountType = StartWeaponConfig[1].Trim('"');
            switch (ContentMountType)
            {
                case "Fixed":
                    MntType.SelectedIndex = 0;
                    break;
                case "Gimble":
                    MntType.SelectedIndex = 1;
                    break;
                case "AnimatedTurret":
                    MntType.SelectedIndex = 2;
                    break;
            }

            string ContentProjectile = StartWeaponConfig[2].Trim('"');
            switch (ContentProjectile)
            {
                case "Bullet":
                    PrjType.SelectedIndex = 0;
                    break;
                case "Missile":
                    PrjType.SelectedIndex = 1;
                    break;
                case "SphereBurst":
                    PrjType.SelectedIndex = 2;
                    break;
                case "InstantHit":
                    PrjType.SelectedIndex = 3;
                    break;
                case "Mine":
                    PrjType.SelectedIndex = 4;
                    break;
            }

            string ContentActivation = StartWeaponConfig[4].Trim('"');
            switch (ContentActivation)
            {
                case "Normal":
                    ActType.SelectedIndex = 0;
                    break;
                case "Normal Only":
                    ActType.SelectedIndex = 1;
                    break;
                case "Special Attack":
                    ActType.SelectedIndex = 2;
                    break;
                case "Dropped":
                    ActType.SelectedIndex = 3;
                    break;
            }

            string ContentLaunchDir = StartWeaponConfig[10];
            switch (ContentLaunchDir)
            {
                case "0":
                    LaunchDir.SelectedIndex = 0;
                    break;
                case "1":
                    LaunchDir.SelectedIndex = 1;
                    break;
                case "2":
                    LaunchDir.SelectedIndex = 2;
                    break;
            }

            string ContentPenetration = StartWeaponConfig[22].Trim('"');
            switch (ContentPenetration)
            {
                case "Normal":
                    Pen.SelectedIndex = 0;
                    break;
                case "Enhanced":
                    Pen.SelectedIndex = 1;
                    break;
                case "Bypass":
                    Pen.SelectedIndex = 2;
                    break;
            }

            string ContentScriptName = StartWeaponConfig[3].Trim('"');
            WFScript.Text = ContentScriptName;

            Velocity.Text = StartWeaponConfig[5];
            Range.Text = StartWeaponConfig[6];
            Radius.Text = StartWeaponConfig[7];
            Lifetime.Text = StartWeaponConfig[8];
            Anticipation.Text = StartWeaponConfig[9];
            MaxFX.Text = StartWeaponConfig[11];
            Delay.Text = StartWeaponConfig[14];
            Burst.Text = StartWeaponConfig[15];
            Wait.Text = StartWeaponConfig[16];
            MaxAzi.Text = StartWeaponConfig[18];
            MaxDec.Text = StartWeaponConfig[19];
            SpeedMult.Text = StartWeaponConfig[20];
            Skewer.Text = StartWeaponConfig[25].Trim(')', ';');

            int ContentPredict = Convert.ToInt32(StartWeaponConfig[12]);
            if (ContentPredict == 0)
                TargetPrediction.IsChecked = false;
            else
                TargetPrediction.IsChecked = true;

            int ContentCheckFriendly = Convert.ToInt32(StartWeaponConfig[13]);
            if (ContentCheckFriendly == 0)
                CheckForFriendlies.IsChecked = false;
            else
                CheckForFriendlies.IsChecked = true;

            int ContentShootSecondaries = Convert.ToInt32(StartWeaponConfig[17]);
            if (ContentShootSecondaries == 0)
                ShootAtSecondaries.IsChecked = false;
            else
                ShootAtSecondaries.IsChecked = true;

            int ContentScanEnemies = Convert.ToInt32(StartWeaponConfig[18]);
            if (ContentScanEnemies == 0)
                ScanForEnemies.IsChecked = false;
            else
                ScanForEnemies.IsChecked = true;

            int ContentTrackOutsideRange = Convert.ToInt32(StartWeaponConfig[23]);
            if (ContentTrackOutsideRange == 0)
                TrackOutsideRange.IsChecked = false;
            else
                TrackOutsideRange.IsChecked = true;

            int ContentWaitForCodeRed = Convert.ToInt32(StartWeaponConfig[24]);
            if (ContentWaitForCodeRed == 0)
                WaitUntilCodeRed.IsChecked = false;
            else
                WaitUntilCodeRed.IsChecked = true;
        }

        private void DisplayContent()
        {
            if (setDamageMultFactor != null)
            {
                ContentDMF.Text = setDamageMultFactor[1].Trim(')');
            }
            else if (setDamageMultFactor == null)
            {
                PnlDMF.Visibility = Visibility.Collapsed;
                BtnRemDMF.Visibility = Visibility.Collapsed;
            }


            if (setLifetimeMult != null)
            {
                ContentLM.Text = setLifetimeMult[1].Trim(')');
            }
            else if (setLifetimeMult == null)
            {
                PnlLM.Visibility = Visibility.Collapsed;
                BtnRemLM.Visibility = Visibility.Collapsed;
            }

            if (setFireMultFactor != null)
            {
                ContentFMF.Text = setFireMultFactor[1].Trim(')');
            }
            else if (setFireMultFactor == null)
            {
                PnlFMF.Visibility = Visibility.Collapsed;
                BtnRemFMF.Visibility = Visibility.Collapsed;
            }


            if (setRangeBoost != null)
            {
                ContentRB.Text = setRangeBoost[1].Trim(')');
            }
            else if (setRangeBoost == null)
            {
                PnlRB.Visibility = Visibility.Collapsed;
                BtnRemRB.Visibility = Visibility.Collapsed;
            }


            if (setFrustratedTimers != null)
            {
                ContentFT_Min.Text = setFrustratedTimers[1];
                ContentFT_Max.Text = setFrustratedTimers[2].Trim(')');
            }
            else if (setFrustratedTimers == null)
            {
                PnlFT1.Visibility = Visibility.Collapsed;
                PnlFT2.Visibility = Visibility.Collapsed;
                BtnRemFT.Visibility = Visibility.Collapsed;
            }

            if (setMiscValues != null)
            {
                ContentMV_Recoil.Text = setMiscValues[1];
                ContentMV_Delay.Text = setMiscValues[2].Trim(')');
            }
            else if (setMiscValues == null)
            {
                PnlMV1.Visibility = Visibility.Collapsed;
                BtnRemMV.Visibility = Visibility.Collapsed;
            }

            if (setMissileKiller != null)
            {
                MissileKillerEnabled = Convert.ToInt32(setMissileKiller[1].Trim(')', ';'));
                if (MissileKillerEnabled == 0)
                    ContentMK.IsChecked = false;
                else
                    ContentMK.IsChecked = true;
            }
            else if (setMissileKiller == null)
            {
                PnlMK.Visibility = Visibility.Collapsed;
                BtnRemMK.Visibility = Visibility.Collapsed;
            }

            if (setBallistics != null)
            {
                BallisticsEnabled = Convert.ToInt32(setBallistics[1]);
                if (BallisticsEnabled == 0)
                    ContentBal_Enable.IsChecked = false;
                else
                    ContentBal_Enable.IsChecked = true;
                ContentBal_Leading.Text = setBallistics[2].Trim(')');
            }
            else if (setBallistics == null)
            {
                PnlBal1.Visibility = Visibility.Collapsed;
                PnlBal2.Visibility = Visibility.Collapsed;

                BtnRemBal.Visibility = Visibility.Collapsed;
            }

            if (setRangeByStance != null)
            {
                ContentRBS_Psv.Text = setRangeByStance[1];
                ContentRBS_Neu.Text = setRangeByStance[2];
                ContentRBS_Agg.Text = setRangeByStance[3].Trim(')');
            }
            else if (setRangeByStance == null)
            {
                PnlRBS.Visibility = Visibility.Collapsed;
                BtnRemRBS.Visibility = Visibility.Collapsed;
            }

            if (setAccuracyFalloff != null)
            {
                ContentAF_Val1.Text = setAccuracyFalloff[1];
                ContentAF_Val2.Text = setAccuracyFalloff[2].Trim(')');
            }
            else if (setAccuracyFalloff == null)
            {
                PnlAF1.Visibility = Visibility.Collapsed;
                PnlAF2.Visibility = Visibility.Collapsed;

                BtnRemAF.Visibility = Visibility.Collapsed;
            }

            if (setDamageFalloff != null)
            {
                ContentDF_Val1.Text = setDamageFalloff[1];
                ContentDF_Val2.Text = setDamageFalloff[2].Trim(')');
            }
            else if (setDamageFalloff == null)
            {
                PnlDF1.Visibility = Visibility.Collapsed;
                PnlDF2.Visibility = Visibility.Collapsed;

                BtnRemDF.Visibility = Visibility.Collapsed;
            }

            if (setMagneticFieldPenetration != null)
            {
                ContentMFP_Val1.Text = setMagneticFieldPenetration[1];
                ContentMFP_Val2.Text = setMagneticFieldPenetration[2].Trim('{');
                ContentMFP_Val3.Text = setMagneticFieldPenetration[3].Trim('}', ')');
            }
            else if (setMagneticFieldPenetration == null)
            {
                PnlMFP.Visibility = Visibility.Collapsed;
                BtnRemMFP.Visibility = Visibility.Collapsed;
            }

            if (addAnimTurretSound != null)
            {
                ContentATS.Text = addAnimTurretSound[1].Trim(')', '"');
            }
            else if (addAnimTurretSound == null)
            {
                PnlATS.Visibility = Visibility.Collapsed;
                BtnRemATS.Visibility = Visibility.Collapsed;
            }

            if (setMissProperties != null)
            {
                ContentMP_ConeHor.Text = setMissProperties[1];
                ContentMP_ConeVer.Text = setMissProperties[2];
                ContentMP_DmgLo.Text = setMissProperties[3];
                ContentMP_DmgHi.Text = setMissProperties[4];
                ContentMP_Speed.Text = setMissProperties[5];
                ContentMP_Life.Text = setMissProperties[6].Trim(')');
            }
            else if (setMissProperties == null)
            {
                PnlMP.Visibility = Visibility.Collapsed;
                BtnRemMP.Visibility = Visibility.Collapsed;
            }

            if (setAngles != null)
            {
                ContentAng_Cone.Text = setAngles[1];
                ContentAng_MinAzi.Text = setAngles[2];
                ContentAng_MaxAzi.Text = setAngles[3];
                ContentAng_MinDec.Text = setAngles[4];
                ContentAng_MaxDec.Text = setAngles[5].Trim(')');
            }
            else if (setAngles == null)
            {
                PnlAng.Visibility = Visibility.Collapsed;
                BtnRemAng.Visibility = Visibility.Collapsed;
            }

            if (setSpeedvsAccuracyAgainst != null)
            {
                OverrideEnabled = Convert.ToInt32(setSpeedvsAccuracyAgainst[1]);
                if (OverrideEnabled == 0)
                    ContentSAA_Override.IsChecked = false;
                else
                    ContentSAA_Override.IsChecked = true;

                int n = setSpeedvsAccuracyAgainst.Count();
                switch (n)
                {
                    case 4:
                        ContentSAA_Speed1.Text = setSpeedvsAccuracyAgainst[2];
                        ContentSAA_Acc1.Text = setSpeedvsAccuracyAgainst[n - 1].Trim(')');
                        BtnAddSAA2.Visibility = Visibility.Collapsed;
                        BtnRemSAA2.Visibility = Visibility.Visible;
                        PnlSAA2.Visibility = Visibility.Collapsed;
                        PnlSAA3.Visibility = Visibility.Collapsed;
                        PnlSAA4.Visibility = Visibility.Collapsed;
                        PnlSAA5.Visibility = Visibility.Collapsed;
                        PnlSAA6.Visibility = Visibility.Collapsed;
                        break;
                    case 6:
                        ContentSAA_Speed1.Text = setSpeedvsAccuracyAgainst[2];
                        ContentSAA_Acc1.Text = setSpeedvsAccuracyAgainst[3];
                        ContentSAA_Speed2.Text = setSpeedvsAccuracyAgainst[4];
                        ContentSAA_Acc2.Text = setSpeedvsAccuracyAgainst[n - 1].Trim(')');
                        BtnAddSAA2.Visibility = Visibility.Collapsed;
                        BtnAddSAA3.Visibility = Visibility.Collapsed;
                        BtnRemSAA3.Visibility = Visibility.Visible;
                        PnlSAA3.Visibility = Visibility.Collapsed;
                        PnlSAA4.Visibility = Visibility.Collapsed;
                        PnlSAA5.Visibility = Visibility.Collapsed;
                        PnlSAA6.Visibility = Visibility.Collapsed;
                        break;
                    case 8:
                        ContentSAA_Speed1.Text = setSpeedvsAccuracyAgainst[2];
                        ContentSAA_Acc1.Text = setSpeedvsAccuracyAgainst[3];
                        ContentSAA_Speed2.Text = setSpeedvsAccuracyAgainst[4];
                        ContentSAA_Acc2.Text = setSpeedvsAccuracyAgainst[5];
                        ContentSAA_Speed3.Text = setSpeedvsAccuracyAgainst[6];
                        ContentSAA_Acc3.Text = setSpeedvsAccuracyAgainst[n - 1].Trim(')');
                        BtnAddSAA2.Visibility = Visibility.Collapsed;
                        BtnAddSAA3.Visibility = Visibility.Collapsed;
                        BtnAddSAA4.Visibility = Visibility.Collapsed;
                        BtnRemSAA4.Visibility = Visibility.Visible;
                        PnlSAA4.Visibility = Visibility.Collapsed;
                        PnlSAA5.Visibility = Visibility.Collapsed;
                        PnlSAA6.Visibility = Visibility.Collapsed;
                        break;
                    case 10:
                        ContentSAA_Speed1.Text = setSpeedvsAccuracyAgainst[2];
                        ContentSAA_Acc1.Text = setSpeedvsAccuracyAgainst[3];
                        ContentSAA_Speed2.Text = setSpeedvsAccuracyAgainst[4];
                        ContentSAA_Acc2.Text = setSpeedvsAccuracyAgainst[5];
                        ContentSAA_Speed3.Text = setSpeedvsAccuracyAgainst[6];
                        ContentSAA_Acc3.Text = setSpeedvsAccuracyAgainst[7];
                        ContentSAA_Speed4.Text = setSpeedvsAccuracyAgainst[8];
                        ContentSAA_Acc4.Text = setSpeedvsAccuracyAgainst[n - 1].Trim(')');
                        BtnAddSAA2.Visibility = Visibility.Collapsed;
                        BtnAddSAA3.Visibility = Visibility.Collapsed;
                        BtnAddSAA4.Visibility = Visibility.Collapsed;
                        BtnAddSAA5.Visibility = Visibility.Collapsed;
                        BtnRemSAA5.Visibility = Visibility.Visible;
                        PnlSAA5.Visibility = Visibility.Collapsed;
                        PnlSAA6.Visibility = Visibility.Collapsed;
                        break;
                    case 12:
                        ContentSAA_Speed1.Text = setSpeedvsAccuracyAgainst[2];
                        ContentSAA_Acc1.Text = setSpeedvsAccuracyAgainst[3];
                        ContentSAA_Speed2.Text = setSpeedvsAccuracyAgainst[4];
                        ContentSAA_Acc2.Text = setSpeedvsAccuracyAgainst[5];
                        ContentSAA_Speed3.Text = setSpeedvsAccuracyAgainst[6];
                        ContentSAA_Acc3.Text = setSpeedvsAccuracyAgainst[7];
                        ContentSAA_Speed4.Text = setSpeedvsAccuracyAgainst[8];
                        ContentSAA_Acc4.Text = setSpeedvsAccuracyAgainst[9];
                        ContentSAA_Speed5.Text = setSpeedvsAccuracyAgainst[10];
                        ContentSAA_Acc5.Text = setSpeedvsAccuracyAgainst[n - 1].Trim(')');
                        BtnAddSAA2.Visibility = Visibility.Collapsed;
                        BtnAddSAA3.Visibility = Visibility.Collapsed;
                        BtnAddSAA4.Visibility = Visibility.Collapsed;
                        BtnAddSAA5.Visibility = Visibility.Collapsed;
                        BtnAddSAA6.Visibility = Visibility.Visible;
                        BtnRemSAA6.Visibility = Visibility.Collapsed;
                        PnlSAA6.Visibility = Visibility.Collapsed;
                        break;
                    case 14:
                        ContentSAA_Speed1.Text = setSpeedvsAccuracyAgainst[2];
                        ContentSAA_Acc1.Text = setSpeedvsAccuracyAgainst[3];
                        ContentSAA_Speed2.Text = setSpeedvsAccuracyAgainst[4];
                        ContentSAA_Acc2.Text = setSpeedvsAccuracyAgainst[5];
                        ContentSAA_Speed3.Text = setSpeedvsAccuracyAgainst[6];
                        ContentSAA_Acc3.Text = setSpeedvsAccuracyAgainst[7];
                        ContentSAA_Speed4.Text = setSpeedvsAccuracyAgainst[8];
                        ContentSAA_Acc4.Text = setSpeedvsAccuracyAgainst[9];
                        ContentSAA_Speed5.Text = setSpeedvsAccuracyAgainst[10];
                        ContentSAA_Acc5.Text = setSpeedvsAccuracyAgainst[11];
                        ContentSAA_Speed6.Text = setSpeedvsAccuracyAgainst[12];
                        ContentSAA_Acc6.Text = setSpeedvsAccuracyAgainst[n - 1].Trim(')');
                        break;
                }
            }
            else if (setSpeedvsAccuracyAgainst == null)
            {
                BtnAddSAA2.Visibility = Visibility.Visible;
                PnlSAA0.Visibility = Visibility.Collapsed;
                PnlSAA1.Visibility = Visibility.Collapsed;
                PnlSAA2.Visibility = Visibility.Collapsed;
                PnlSAA3.Visibility = Visibility.Collapsed;
                PnlSAA4.Visibility = Visibility.Collapsed;
                PnlSAA5.Visibility = Visibility.Collapsed;
                PnlSAA6.Visibility = Visibility.Collapsed;
                PnlSAA2_1.Visibility = Visibility.Collapsed;
                PnlSAA3_1.Visibility = Visibility.Collapsed;
                PnlSAA4_1.Visibility = Visibility.Collapsed;
                PnlSAA5_1.Visibility = Visibility.Collapsed;
                PnlSAA6_1.Visibility = Visibility.Collapsed;
                BtnRemSAA.Visibility = Visibility.Collapsed;
                }

            if (addWeaponResult1 != null)
            {
                string ContentCondition = addWeaponResult1[1].Trim('"');
                switch (ContentCondition)
                {
                    case "Hit":
                        ContentWR1_Condition.SelectedIndex = 0;
                        break;
                    case "Miss":
                        ContentWR1_Condition.SelectedIndex = 1;
                        break;
                }


                string ContentEffect = addWeaponResult1[2].Trim('"');
                switch (ContentEffect)
                {
                    case "DamageHealth":
                        ContentWR1_Effect.SelectedIndex = 0;
                        break;
                    case "Disable":
                        ContentWR1_Effect.SelectedIndex = 1;
                        break;
                    case "Push":
                        ContentWR1_Effect.SelectedIndex = 2;
                        break;
                    case "SpawnWeaponFire":
                        ContentWR1_Effect.SelectedIndex = 3;
                        break;
                    case "LatchWithTarget":
                        ContentWR1_Effect.SelectedIndex = 4;
                        break;
                }


                string ContentTarget = addWeaponResult1[3].Trim('"');
                switch (ContentTarget)
                {
                    case "Target":
                        ContentWR1_Target.SelectedIndex = 0;
                        break;
                    case "Owner":
                        ContentWR1_Target.SelectedIndex = 1;
                        break;
                }

                ContentWR1_Min.Text = addWeaponResult1[4];
                ContentWR1_Max.Text = addWeaponResult1[5];
                ContentWR1_Name.Text = addWeaponResult1[6].Trim(')', '"');
                PnlWR1.Visibility = Visibility.Visible;
                BtnAddWR1.Visibility = Visibility.Collapsed;
                BtnRemWR1.Visibility = Visibility.Visible;
            }
            else if (addWeaponResult1 == null)
            {
                PnlWR1.Visibility = Visibility.Collapsed;
                BtnRemWR1.Visibility = Visibility.Collapsed;
            }


            if (addWeaponResult2 != null)
            {
                string ContentCondition = addWeaponResult2[1].Trim('"');
                switch (ContentCondition)
                {
                    case "Hit":
                        ContentWR2_Condition.SelectedIndex = 0;
                        break;
                    case "Miss":
                        ContentWR2_Condition.SelectedIndex = 1;
                        break;
                }
                string ContentEffect = addWeaponResult2[2].Trim('"');
                switch (ContentEffect)
                {
                    case "DamageHealth":
                        ContentWR2_Effect.SelectedIndex = 0;
                        break;
                    case "Disable":
                        ContentWR2_Effect.SelectedIndex = 1;
                        break;
                    case "Push":
                        ContentWR2_Effect.SelectedIndex = 2;
                        break;
                    case "SpawnWeaponFire":
                        ContentWR2_Effect.SelectedIndex = 3;
                        break;
                    case "LatchWithTarget":
                        ContentWR2_Effect.SelectedIndex = 4;
                        break;
                }
                string ContentTarget = addWeaponResult2[3].Trim('"');
                switch (ContentTarget)
                {
                    case "Target":
                        ContentWR2_Target.SelectedIndex = 0;
                        break;
                    case "Owner":
                        ContentWR2_Target.SelectedIndex = 1;
                        break;
                }
                ContentWR2_Min.Text = addWeaponResult2[4];
                ContentWR2_Max.Text = addWeaponResult2[5];
                ContentWR2_Name.Text = addWeaponResult2[6].Trim(')', '"');
                PnlWR2.Visibility = Visibility.Visible;
                BtnAddWR2.Visibility = Visibility.Collapsed;
                BtnRemWR2.Visibility = Visibility.Visible;
            }
            else if (addWeaponResult2 == null)
            {
                PnlWR2.Visibility = Visibility.Collapsed;
                BtnRemWR2.Visibility = Visibility.Collapsed;
            }

            if (addWeaponResult3 != null)
            {
                string ContentCondition = addWeaponResult3[1].Trim('"');
                switch (ContentCondition)
                {
                    case "Hit":
                        ContentWR3_Condition.SelectedIndex = 0;
                        break;
                    case "Miss":
                        ContentWR3_Condition.SelectedIndex = 1;
                        break;
                }
                string ContentEffect = addWeaponResult3[2].Trim('"');
                switch (ContentEffect)
                {
                    case "DamageHealth":
                        ContentWR3_Effect.SelectedIndex = 0;
                        break;
                    case "Disable":
                        ContentWR3_Effect.SelectedIndex = 1;
                        break;
                    case "Push":
                        ContentWR3_Effect.SelectedIndex = 2;
                        break;
                    case "SpawnWeaponFire":
                        ContentWR3_Effect.SelectedIndex = 3;
                        break;
                    case "LatchWithTarget":
                        ContentWR3_Effect.SelectedIndex = 4;
                        break;
                }
                string ContentTarget = addWeaponResult3[3].Trim('"');
                switch (ContentTarget)
                {
                    case "Target":
                        ContentWR3_Target.SelectedIndex = 0;
                        break;
                    case "Owner":
                        ContentWR3_Target.SelectedIndex = 1;
                        break;
                }
                ContentWR3_Min.Text = addWeaponResult3[4];
                ContentWR3_Max.Text = addWeaponResult3[5];
                ContentWR3_Name.Text = addWeaponResult3[6].Trim(')', '"');
                PnlWR3.Visibility = Visibility.Visible;
                BtnAddWR3.Visibility = Visibility.Collapsed;
                BtnRemWR3.Visibility = Visibility.Visible;
            }
            else if (addWeaponResult3 == null)
            {
                PnlWR3.Visibility = Visibility.Collapsed;
                BtnRemWR3.Visibility = Visibility.Collapsed;
            }

            if (addWeaponResult4 != null)
            {
                string ContentCondition = addWeaponResult4[1].Trim('"');
                switch (ContentCondition)
                {
                    case "Hit":
                        ContentWR4_Condition.SelectedIndex = 0;
                        break;
                    case "Miss":
                        ContentWR4_Condition.SelectedIndex = 1;
                        break;
                }
                string ContentEffect = addWeaponResult4[2].Trim('"');
                switch (ContentEffect)
                {
                    case "DamageHealth":
                        ContentWR4_Effect.SelectedIndex = 0;
                        break;
                    case "Disable":
                        ContentWR4_Effect.SelectedIndex = 1;
                        break;
                    case "Push":
                        ContentWR4_Effect.SelectedIndex = 2;
                        break;
                    case "SpawnWeaponFire":
                        ContentWR4_Effect.SelectedIndex = 3;
                        break;
                    case "LatchWithTarget":
                        ContentWR4_Effect.SelectedIndex = 4;
                        break;
                }
                string ContentTarget = addWeaponResult4[3].Trim('"');
                switch (ContentTarget)
                {
                    case "Target":
                        ContentWR4_Target.SelectedIndex = 0;
                        break;
                    case "Owner":
                        ContentWR4_Target.SelectedIndex = 1;
                        break;
                }
                ContentWR4_Min.Text = addWeaponResult4[4];
                ContentWR4_Max.Text = addWeaponResult4[5];
                ContentWR4_Name.Text = addWeaponResult4[6].Trim(')', '"');
                PnlWR4.Visibility = Visibility.Visible;
                BtnAddWR4.Visibility = Visibility.Collapsed;
                BtnRemWR4.Visibility = Visibility.Visible;
            }
            else if (addWeaponResult4 == null)
            {
                PnlWR4.Visibility = Visibility.Collapsed;
                BtnRemWR4.Visibility = Visibility.Collapsed;
            }


            if (addWeaponResult5 != null)
            {
                string ContentCondition = addWeaponResult5[1].Trim('"');
                switch (ContentCondition)
                {
                    case "Hit":
                        ContentWR5_Condition.SelectedIndex = 0;
                        break;
                    case "Miss":
                        ContentWR5_Condition.SelectedIndex = 1;
                        break;
                }
                string ContentEffect = addWeaponResult5[2].Trim('"');
                switch (ContentEffect)
                {
                    case "DamageHealth":
                        ContentWR5_Effect.SelectedIndex = 0;
                        break;
                    case "Disable":
                        ContentWR5_Effect.SelectedIndex = 1;
                        break;
                    case "Push":
                        ContentWR5_Effect.SelectedIndex = 2;
                        break;
                    case "SpawnWeaponFire":
                        ContentWR5_Effect.SelectedIndex = 3;
                        break;
                    case "LatchWithTarget":
                        ContentWR5_Effect.SelectedIndex = 4;
                        break;
                }
                string ContentTarget = addWeaponResult5[3].Trim('"');
                switch (ContentTarget)
                {
                    case "Target":
                        ContentWR5_Target.SelectedIndex = 0;
                        break;
                    case "Owner":
                        ContentWR5_Target.SelectedIndex = 1;
                        break;
                }
                ContentWR5_Min.Text = addWeaponResult5[4];
                ContentWR5_Max.Text = addWeaponResult5[5];
                ContentWR5_Name.Text = addWeaponResult5[6].Trim(')', '"');
                PnlWR5.Visibility = Visibility.Visible;
                BtnAddWR5.Visibility = Visibility.Collapsed;
                BtnRemWR5.Visibility = Visibility.Visible;
            }
            else if (addWeaponResult5 == null)
            {
                PnlWR5.Visibility = Visibility.Collapsed;
                BtnRemWR5.Visibility = Visibility.Collapsed;
            }


            if (addWeaponResult6 != null)
            {
                string ContentCondition = addWeaponResult6[1].Trim('"');
                switch (ContentCondition)
                {
                    case "Hit":
                        ContentWR6_Condition.SelectedIndex = 0;
                        break;
                    case "Miss":
                        ContentWR6_Condition.SelectedIndex = 1;
                        break;
                }
                string ContentEffect = addWeaponResult6[2].Trim('"');
                switch (ContentEffect)
                {
                    case "DamageHealth":
                        ContentWR6_Effect.SelectedIndex = 0;
                        break;
                    case "Disable":
                        ContentWR6_Effect.SelectedIndex = 1;
                        break;
                    case "Push":
                        ContentWR6_Effect.SelectedIndex = 2;
                        break;
                    case "SpawnWeaponFire":
                        ContentWR6_Effect.SelectedIndex = 3;
                        break;
                    case "LatchWithTarget":
                        ContentWR6_Effect.SelectedIndex = 4;
                        break;
                }
                string ContentTarget = addWeaponResult6[3].Trim('"');
                switch (ContentTarget)
                {
                    case "Target":
                        ContentWR6_Target.SelectedIndex = 0;
                        break;
                    case "Owner":
                        ContentWR6_Target.SelectedIndex = 1;
                        break;
                }
                ContentWR6_Min.Text = addWeaponResult6[4];
                ContentWR6_Max.Text = addWeaponResult6[5];
                ContentWR6_Name.Text = addWeaponResult6[6].Trim(')', '"');
                PnlWR6.Visibility = Visibility.Visible;
                BtnAddWR6.Visibility = Visibility.Collapsed;
                BtnRemWR6.Visibility = Visibility.Visible;
            }
            else if (addWeaponResult6 == null)
            {
                PnlWR6.Visibility = Visibility.Collapsed;
                BtnRemWR6.Visibility = Visibility.Collapsed;
            }

            if (setPenetration != null)
            {
                int n = setPenetration.Count();
                for (int i = 3; i < (n - 1); i++)
                {
                    ContentPen_List.AppendText(setPenetration[i] + '\n');
                }
                ContentPen_List.AppendText(setPenetration[n - 1].Trim(')'));
                ContentPen_Fld.Text = setPenetration[1];
                ContentPen_Def.Text = setPenetration[2];
            }

            if (setAccuracy != null)
            {
                int n = setAccuracy.Count();
                if (n > 2)
                {
                    for (int i = 2; i < (n - 1); i++)
                    {
                        ContentAcc_List.AppendText(setAccuracy[i] + '\n');
                    }
                    ContentAcc_List.AppendText(setAccuracy[n - 1].Trim(')'));
                    ContentAcc_Def.Text = setAccuracy[1];
                }
                else if (n == 2)
                {
                    ContentAcc_Def.Text = setAccuracy[1].Trim(')');
                }
            }
        }

        private void SaveContent()
        {
            StringBuilder sbContent = new StringBuilder();
            int Predict = 0;
            int Check = 0;
            int Second = 0;
            int Scan = 0;
            int Track = 0;
            int Wait = 0;

            if (TargetPrediction.IsChecked == true)
                Predict = 1;
            else if (TargetPrediction.IsChecked == false)
                Predict = 0;

            if (CheckForFriendlies.IsChecked == true)
                Check = 1;
            else if (CheckForFriendlies.IsChecked == false)
                Check = 0;

            if (ShootAtSecondaries.IsChecked == true)
                Second = 1;
            else if (ShootAtSecondaries.IsChecked == false)
                Second = 0;

            if (ScanForEnemies.IsChecked == true)
                Scan = 1;
            else if (ScanForEnemies.IsChecked == false)
                Scan = 0;

            if (TrackOutsideRange.IsChecked == true)
                Track = 1;
            else if (TrackOutsideRange.IsChecked == false)
                Track = 0;

            if (WaitUntilCodeRed.IsChecked == true)
                Wait = 1;
            else if (WaitUntilCodeRed.IsChecked == false)
                Wait = 0;

            sbContent.AppendLine("StartWeaponConfig" + "(" + ObjType.SelectedItem + "," + '"' + MntType.SelectedItem + '"' + "," + '"' + PrjType.SelectedItem + '"' + "," + '"' + WFScript.Text + '"' + "," + '"' + ActType.SelectedItem + '"' + "," + Velocity.Text + "," + Range.Text + "," + Radius.Text + "," + Lifetime.Text + "," + Anticipation.Text + "," + LaunchDir.SelectedItem + "," + MaxFX.Text + "," + Predict + "," + Check + "," + Delay.Text + "," + Burst.Text + "," + Wait + "," + Second + "," + Scan + "," + MaxAzi.Text + "," + MaxDec.Text + "," + SpeedMult.Text + "," + '"' + Pen.SelectedItem + '"' + "," + Track + "," + Wait + "," + Skewer.Text + ");");

            if (PnlWR1.Visibility == Visibility.Visible)
            {
                sbContent.AppendLine("AddWeaponResult" + "(" + ObjType.SelectedItem + "," + '"' + ContentWR1_Condition.SelectedItem + '"' + "," + '"' + ContentWR1_Effect.SelectedItem + '"' + "," + '"' + ContentWR1_Target.SelectedItem + '"' + "," + ContentWR1_Min.Text + "," + ContentWR1_Max.Text + "," + '"' + ContentWR1_Name.Text + '"' + ");");
            }
            if (PnlWR2.Visibility == Visibility.Visible)
            {
                sbContent.AppendLine("AddWeaponResult" + "(" + ObjType.SelectedItem + "," + '"' + ContentWR2_Condition.SelectedItem + '"' + "," + '"' + ContentWR2_Effect.SelectedItem + '"' + "," + '"' + ContentWR2_Target.SelectedItem + '"' + "," + ContentWR2_Min.Text + "," + ContentWR2_Max.Text + "," + '"' + ContentWR2_Name.Text + '"' + ");");
            }
            if (PnlWR3.Visibility == Visibility.Visible)
            {
                sbContent.AppendLine("AddWeaponResult" + "(" + ObjType.SelectedItem + "," + '"' + ContentWR3_Condition.SelectedItem + '"' + "," + '"' + ContentWR3_Effect.SelectedItem + '"' + "," + '"' + ContentWR3_Target.SelectedItem + '"' + "," + ContentWR3_Min.Text + "," + ContentWR3_Max.Text + "," + '"' + ContentWR3_Name.Text + '"' + ");");
            }
            if (PnlWR4.Visibility == Visibility.Visible)
            {
                sbContent.AppendLine("AddWeaponResult" + "(" + ObjType.SelectedItem + "," + '"' + ContentWR4_Condition.SelectedItem + '"' + "," + '"' + ContentWR4_Effect.SelectedItem + '"' + "," + '"' + ContentWR4_Target.SelectedItem + '"' + "," + ContentWR4_Min.Text + "," + ContentWR4_Max.Text + "," + '"' + ContentWR4_Name.Text + '"' + ");");
            }
            if (PnlWR5.Visibility == Visibility.Visible)
            {
                sbContent.AppendLine("AddWeaponResult" + "(" + ObjType.SelectedItem + "," + '"' + ContentWR5_Condition.SelectedItem + '"' + "," + '"' + ContentWR5_Effect.SelectedItem + '"' + "," + '"' + ContentWR5_Target.SelectedItem + '"' + "," + ContentWR5_Min.Text + "," + ContentWR5_Max.Text + "," + '"' + ContentWR5_Name.Text + '"' + ");");
            }
            if (PnlWR6.Visibility == Visibility.Visible)
            {
                sbContent.AppendLine("AddWeaponResult" + "(" + ObjType.SelectedItem + "," + '"' + ContentWR6_Condition.SelectedItem + '"' + "," + '"' + ContentWR6_Effect.SelectedItem + '"' + "," + '"' + ContentWR6_Target.SelectedItem + '"' + "," + ContentWR6_Min.Text + "," + ContentWR6_Max.Text + "," + '"' + ContentWR6_Name.Text + '"' + ");");
            }

            if (PnlMFP.Visibility == Visibility.Visible)
            {
                sbContent.AppendLine("setMagneticFieldPenetration" + "(" + ObjType.SelectedItem + "," + ContentMFP_Val1.Text + "," + "{" + ContentMFP_Val2.Text + "," + ContentMFP_Val3.Text + "});");
            }

            //note - use \n instead of environment.newline so its easier to concatenate
            if (PnlPen.Visibility == Visibility.Visible)
            {
                StringBuilder sbPenetration = new StringBuilder();
                string[] arrPenetration = ContentPen_List.Text.Split('\n');
                int n = arrPenetration.Count();
                for (int i = 0; i < (n - 1); i++)
                    sbPenetration.Append(arrPenetration[i] + ',');
                sbPenetration.Append(arrPenetration[n - 1]);

                sbContent.AppendLine("setPenetration" + "(" + ObjType.SelectedItem + "," + ContentPen_Fld.Text + "," + ContentPen_Def.Text + "," + sbPenetration + ");");
            }

            if (PnlAcc.Visibility == Visibility.Visible)
            {
                int x = setAccuracy.Count();
                if (x > 2)
                {
                    StringBuilder sbAccuracy = new StringBuilder();
                    string[] arrAccuracy = ContentAcc_List.Text.Split('\n');
                    int n = arrAccuracy.Count();
                    for (int i = 0; i < (n - 1); i++)
                        sbAccuracy.Append(arrAccuracy[i] + ',');
                    sbAccuracy.Append(arrAccuracy[n - 1]);

                    sbContent.AppendLine("setAccuracy" + "(" + ObjType.SelectedItem + "," + ContentAcc_Def.Text + "," + sbAccuracy + ");");
                }
                else if (x == 2)
                {
                    sbContent.AppendLine("setAccuracy" + "(" + ObjType.SelectedItem + "," + ContentAcc_Def.Text + ");");
                }
            }

            if (PnlAng.Visibility == Visibility.Visible)
            {
                sbContent.AppendLine("setAngles" + "(" + ObjType.SelectedItem + "," + ContentAng_Cone.Text + "," + ContentAng_MinAzi.Text + "," + ContentAng_MaxAzi.Text + "," + ContentAng_MinDec.Text + "," + ContentAng_MaxDec.Text + ");");
            }
            if (PnlDMF.Visibility == Visibility.Visible)
            {
                sbContent.AppendLine("setDamageMultFactor" + "(" + ObjType.SelectedItem + "," + ContentDMF.Text + ");");
            }
            if (PnlLM.Visibility == Visibility.Visible)
            {
                sbContent.AppendLine("setLifetimeMult" + "(" + ObjType.SelectedItem + "," + ContentLM.Text + ");");
            }
            if (PnlFMF.Visibility == Visibility.Visible)
            {
                sbContent.AppendLine("setFireMultFactor" + "(" + ObjType.SelectedItem + "," + ContentFMF.Text + ");");
            }
            if (PnlRB.Visibility == Visibility.Visible)
            {
                sbContent.AppendLine("setRangeBoost" + "(" + ObjType.SelectedItem + "," + ContentRB.Text + ");");
            }
            if (PnlFT1.Visibility == Visibility.Visible)
            {
                sbContent.AppendLine("setFrustratedTimers" + "(" + ObjType.SelectedItem + "," + ContentFT_Min.Text + "," + ContentFT_Max.Text + ");");
            }
            if (PnlMV1.Visibility == Visibility.Visible)
            {
                sbContent.AppendLine("setMiscValues" + "(" + ObjType.SelectedItem + "," + ContentMV_Recoil.Text + "," + ContentMV_Delay.Text + ");");
            }
            if (PnlRBS.Visibility == Visibility.Visible)
            {
                sbContent.AppendLine("setRangeByStance" + "(" + ObjType.SelectedItem + "," + ContentRBS_Psv.Text + "," + ContentRBS_Neu.Text + "," + ContentRBS_Agg.Text + ");");
            }
            if (PnlATS.Visibility == Visibility.Visible)
            {
                sbContent.AppendLine("AddAnimTurretSound" + "(" + ObjType.SelectedItem + "," + '"' + ContentATS.Text + '"' + ");");
            }
            if (PnlMP.Visibility == Visibility.Visible)
            {
                sbContent.AppendLine("setMissProperties" + "(" + ObjType.SelectedItem + "," + ContentMP_ConeHor.Text + "," + ContentMP_ConeVer.Text + "," + ContentMP_DmgLo.Text + "," + ContentMP_DmgHi.Text + "," + ContentMP_Speed.Text + "," + ContentMP_Life.Text + ");");
            }

            if (PnlAF1.Visibility == Visibility.Visible)
            {
                sbContent.AppendLine("setAccuracyFalloff" + "(" + ObjType.SelectedItem + "," + ContentAF_Val1.Text + "," + ContentAF_Val2.Text + ");");
            }
            if (PnlDF1.Visibility == Visibility.Visible)
            {
                sbContent.AppendLine("setDamageFalloff" + "(" + ObjType.SelectedItem + "," + ContentDF_Val1.Text + "," + ContentDF_Val2.Text + ");");
            }

            int Ballistic = 0;
            if (ContentBal_Enable.IsChecked == true)
                Ballistic = 1;
            else if (ContentBal_Enable.IsChecked == false)
                Ballistic = 0;

            if (PnlBal1.Visibility == Visibility.Visible)
            {
                sbContent.AppendLine("setBallistics" + "(" + ObjType.SelectedItem + "," + Ballistic + "," + ContentBal_Leading.Text + ");");
            }

            int Missile = 0;
            if (ContentMK.IsChecked == true)
                Missile = 1;
            else if (ContentMK.IsChecked == false)
                Missile = 0;

            if (PnlMK.Visibility == Visibility.Visible)
            {
                sbContent.AppendLine("setMissileKiller" + "(" + ObjType.SelectedItem + "," + Missile + ");");
            }

            if (PnlSAA.Visibility == Visibility.Visible)
            {
                int Override = 0;
                if (ContentSAA_Override.IsChecked == true)
                    Override = 1;
                else if (ContentSAA_Override.IsChecked == false)
                    Override = 0;

                if ((PnlSAA1.Visibility == Visibility.Visible) && (PnlSAA2.Visibility == Visibility.Collapsed))
                {
                    sbContent.AppendLine("setSpeedvsAccuracyAgainst" + "(" + ObjType.SelectedItem + "," + Override + "," + ContentSAA_Speed1.Text + "," + ContentSAA_Acc1.Text + ");");
                }
                else if ((PnlSAA2.Visibility == Visibility.Visible) && (PnlSAA3.Visibility == Visibility.Collapsed))
                {
                    sbContent.AppendLine("setSpeedvsAccuracyAgainst" + "(" + ObjType.SelectedItem + "," + Override + "," + ContentSAA_Speed1.Text + "," + ContentSAA_Acc1.Text + "," + ContentSAA_Speed2.Text + "," + ContentSAA_Acc2.Text + ");");

                }
                else if ((PnlSAA3.Visibility == Visibility.Visible) && (PnlSAA4.Visibility == Visibility.Collapsed))
                {
                    sbContent.AppendLine("setSpeedvsAccuracyAgainst" + "(" + ObjType.SelectedItem + "," + Override + "," + ContentSAA_Speed1.Text + "," + ContentSAA_Acc1.Text + "," + ContentSAA_Speed2.Text + "," + ContentSAA_Acc2.Text + "," + ContentSAA_Speed3.Text + "," + ContentSAA_Acc3.Text + ");");

                }
                else if ((PnlSAA4.Visibility == Visibility.Visible) && (PnlSAA5.Visibility == Visibility.Collapsed))
                {
                    sbContent.AppendLine("setSpeedvsAccuracyAgainst" + "(" + ObjType.SelectedItem + "," + Override + "," + ContentSAA_Speed1.Text + "," + ContentSAA_Acc1.Text + "," + ContentSAA_Speed2.Text + "," + ContentSAA_Acc2.Text + "," + ContentSAA_Speed3.Text + "," + ContentSAA_Acc3.Text + "," + ContentSAA_Speed4.Text + "," + ContentSAA_Acc4.Text + ");");

                }
                else if ((PnlSAA5.Visibility == Visibility.Visible) && (PnlSAA6.Visibility == Visibility.Collapsed))
                {
                    sbContent.AppendLine("setSpeedvsAccuracyAgainst" + "(" + ObjType.SelectedItem + "," + Override + "," + ContentSAA_Speed1.Text + "," + ContentSAA_Acc1.Text + "," + ContentSAA_Speed2.Text + "," + ContentSAA_Acc2.Text + "," + ContentSAA_Speed3.Text + "," + ContentSAA_Acc3.Text + "," + ContentSAA_Speed4.Text + "," + ContentSAA_Acc4.Text + ContentSAA_Speed5.Text + "," + ContentSAA_Acc5.Text + ");");

                }
                else if (PnlSAA6.Visibility == Visibility.Visible)
                {
                    sbContent.AppendLine("setSpeedvsAccuracyAgainst" + "(" + ObjType.SelectedItem + "," + Override + "," + ContentSAA_Speed1.Text + "," + ContentSAA_Acc1.Text + "," + ContentSAA_Speed2.Text + "," + ContentSAA_Acc2.Text + "," + ContentSAA_Speed3.Text + "," + ContentSAA_Acc3.Text + "," + ContentSAA_Speed4.Text + "," + ContentSAA_Acc4.Text + ContentSAA_Speed5.Text + "," + ContentSAA_Acc5.Text + ContentSAA_Speed6.Text + "," + ContentSAA_Acc6.Text + ");");

                }
            }

            string updatedContent = sbContent.ToString();

            //System.IO.File.WriteAllText(tmpPath, updatedContent);
                System.IO.File.WriteAllText(path, updatedContent);
        }

        //private void MenuOpen_Click(object sender, RoutedEventArgs e)
        //{
        //    if (openFile.ShowDialog() == true)
        //    {
        //        path = openFile.FileName;
        //        content = File.ReadAllLines(path);
        //        joinedContent = string.Join("", content);
        //        splitContent = joinedContent.Split(';');
        //    }

        //    //foreach (Control controls in PnlRoot.Children)
        //    //{
        //    //    if (controls.GetType() == typeof(CheckBox))
        //    //        ((CheckBox)controls).IsChecked = false;
        //    //    if (controls.GetType() == typeof(TextBox))
        //    //        ((TextBox)controls).Text = String.Empty;
        //    //}

        //    ContentAcc_List.Text = String.Empty;
        //    ContentPen_List.Text = String.Empty;

        //    ParseWepnFile();
        //    DisplayContent();

        //}

        private void MenuSave_Click(object sender, RoutedEventArgs e)
        {
            SaveContent();
        }


        private void BtnAddMK_Click(object sender, RoutedEventArgs e)
        {
            BtnAddMK.Visibility = Visibility.Collapsed;
            BtnRemMK.Visibility = Visibility.Visible;
            PnlMK.Visibility = Visibility.Visible;
        }

        private void BtnRemMK_Click(object sender, RoutedEventArgs e)
        {
            BtnAddMK.Visibility = Visibility.Visible;
            BtnRemMK.Visibility = Visibility.Collapsed;
            PnlMK.Visibility = Visibility.Collapsed;
        }
        private void BtnAddBal_Click(object sender, RoutedEventArgs e)
        {
            BtnAddBal.Visibility = Visibility.Collapsed;
            BtnRemBal.Visibility = Visibility.Visible;
            PnlBal1.Visibility = Visibility.Visible;
            PnlBal2.Visibility = Visibility.Visible;
        }

        private void BtnRemBal_Click(object sender, RoutedEventArgs e)
        {
            BtnAddBal.Visibility = Visibility.Visible;
            BtnRemBal.Visibility = Visibility.Collapsed;
            PnlBal1.Visibility = Visibility.Collapsed;
            PnlBal2.Visibility = Visibility.Collapsed;
        }
        private void BtnAddRB_Click(object sender, RoutedEventArgs e)
        {
            BtnAddRB.Visibility = Visibility.Collapsed;
            BtnRemRB.Visibility = Visibility.Visible;
            PnlRB.Visibility = Visibility.Visible;
        }

        private void BtnRemRB_Click(object sender, RoutedEventArgs e)
        {
            BtnAddRB.Visibility = Visibility.Visible;
            BtnRemRB.Visibility = Visibility.Collapsed;
            PnlRB.Visibility = Visibility.Collapsed;
        }
        private void BtnAddLM_Click(object sender, RoutedEventArgs e)
        {
            BtnAddLM.Visibility = Visibility.Collapsed;
            BtnRemLM.Visibility = Visibility.Visible;
            PnlLM.Visibility = Visibility.Visible;
        }

        private void BtnRemLM_Click(object sender, RoutedEventArgs e)
        {
            BtnAddLM.Visibility = Visibility.Visible;
            BtnRemLM.Visibility = Visibility.Collapsed;
            PnlLM.Visibility = Visibility.Collapsed;
        }
        private void BtnAddFMF_Click(object sender, RoutedEventArgs e)
        {
            BtnAddFMF.Visibility = Visibility.Collapsed;
            BtnRemFMF.Visibility = Visibility.Visible;
            PnlFMF.Visibility = Visibility.Visible;
        }

        private void BtnRemFMF_Click(object sender, RoutedEventArgs e)
        {
            BtnAddFMF.Visibility = Visibility.Visible;
            BtnRemFMF.Visibility = Visibility.Collapsed;
            PnlFMF.Visibility = Visibility.Collapsed;
        }
        private void BtnAddDMF_Click(object sender, RoutedEventArgs e)
        {
            BtnAddDMF.Visibility = Visibility.Collapsed;
            BtnRemDMF.Visibility = Visibility.Visible;
            PnlDMF.Visibility = Visibility.Visible;
        }

        private void BtnRemDMF_Click(object sender, RoutedEventArgs e)
        {
            BtnAddDMF.Visibility = Visibility.Visible;
            BtnRemDMF.Visibility = Visibility.Collapsed;
            PnlDMF.Visibility = Visibility.Collapsed;
        }
        private void BtnAddFT_Click(object sender, RoutedEventArgs e)
        {
            BtnAddFT.Visibility = Visibility.Collapsed;
            BtnRemFT.Visibility = Visibility.Visible;
            PnlFT1.Visibility = Visibility.Visible;
            PnlFT2.Visibility = Visibility.Visible;
        }

        private void BtnRemFT_Click(object sender, RoutedEventArgs e)
        {
            BtnAddFT.Visibility = Visibility.Visible;
            BtnRemFT.Visibility = Visibility.Collapsed;
            PnlFT1.Visibility = Visibility.Collapsed;
            PnlFT2.Visibility = Visibility.Collapsed;
        }
        private void BtnAddMV_Click(object sender, RoutedEventArgs e)
        {
            BtnAddMV.Visibility = Visibility.Collapsed;
            BtnRemMV.Visibility = Visibility.Visible;
            PnlMV1.Visibility = Visibility.Visible;
            PnlMV2.Visibility = Visibility.Visible;
        }

        private void BtnRemMV_Click(object sender, RoutedEventArgs e)
        {
            BtnAddMV.Visibility = Visibility.Visible;
            BtnRemMV.Visibility = Visibility.Collapsed;
            PnlMV1.Visibility = Visibility.Collapsed;
            PnlMV2.Visibility = Visibility.Collapsed;
        }
        private void BtnAddAF_Click(object sender, RoutedEventArgs e)
        {
            BtnAddAF.Visibility = Visibility.Collapsed;
            BtnRemAF.Visibility = Visibility.Visible;
            PnlAF1.Visibility = Visibility.Visible;
            PnlAF2.Visibility = Visibility.Visible;
        }

        private void BtnRemAF_Click(object sender, RoutedEventArgs e)
        {
            BtnAddAF.Visibility = Visibility.Visible;
            BtnRemAF.Visibility = Visibility.Collapsed;
            PnlAF1.Visibility = Visibility.Collapsed;
            PnlAF2.Visibility = Visibility.Collapsed;
        }
        private void BtnAddDF_Click(object sender, RoutedEventArgs e)
        {
            BtnAddDF.Visibility = Visibility.Collapsed;
            BtnRemDF.Visibility = Visibility.Visible;
            PnlDF1.Visibility = Visibility.Visible;
            PnlDF2.Visibility = Visibility.Visible;
        }

        private void BtnRemDF_Click(object sender, RoutedEventArgs e)
        {
            BtnAddDF.Visibility = Visibility.Visible;
            BtnRemDF.Visibility = Visibility.Collapsed;
            PnlDF1.Visibility = Visibility.Collapsed;
            PnlDF2.Visibility = Visibility.Collapsed;
        }
        private void BtnAddWR1_Click(object sender, RoutedEventArgs e)
        {
            BtnAddWR1.Visibility = Visibility.Collapsed;
            BtnRemWR1.Visibility = Visibility.Visible;
            PnlWR1.Visibility = Visibility.Visible;
        }

        private void BtnRemWR1_Click(object sender, RoutedEventArgs e)
        {
            BtnAddWR1.Visibility = Visibility.Visible;
            BtnRemWR1.Visibility = Visibility.Collapsed;
            PnlWR1.Visibility = Visibility.Collapsed;
        }
        private void BtnAddWR2_Click(object sender, RoutedEventArgs e)
        {
            BtnAddWR2.Visibility = Visibility.Collapsed;
            BtnRemWR2.Visibility = Visibility.Visible;
            PnlWR2.Visibility = Visibility.Visible;
        }

        private void BtnRemWR2_Click(object sender, RoutedEventArgs e)
        {
            BtnAddWR2.Visibility = Visibility.Visible;
            BtnRemWR2.Visibility = Visibility.Collapsed;
            PnlWR2.Visibility = Visibility.Collapsed;
        }
        private void BtnAddWR3_Click(object sender, RoutedEventArgs e)
        {
            BtnAddWR3.Visibility = Visibility.Collapsed;
            BtnRemWR3.Visibility = Visibility.Visible;
            PnlWR3.Visibility = Visibility.Visible;
        }

        private void BtnRemWR3_Click(object sender, RoutedEventArgs e)
        {
            BtnAddWR3.Visibility = Visibility.Visible;
            BtnRemWR3.Visibility = Visibility.Collapsed;
            PnlWR3.Visibility = Visibility.Collapsed;
        }
        private void BtnAddWR4_Click(object sender, RoutedEventArgs e)
        {
            BtnAddWR4.Visibility = Visibility.Collapsed;
            BtnRemWR4.Visibility = Visibility.Visible;
            PnlWR4.Visibility = Visibility.Visible;
        }

        private void BtnRemWR4_Click(object sender, RoutedEventArgs e)
        {
            BtnAddWR4.Visibility = Visibility.Visible;
            BtnRemWR4.Visibility = Visibility.Collapsed;
            PnlWR4.Visibility = Visibility.Collapsed;
        }
        private void BtnAddWR5_Click(object sender, RoutedEventArgs e)
        {
            BtnAddWR5.Visibility = Visibility.Collapsed;
            BtnRemWR5.Visibility = Visibility.Visible;
            PnlWR5.Visibility = Visibility.Visible;
        }

        private void BtnRemWR5_Click(object sender, RoutedEventArgs e)
        {
            BtnAddWR5.Visibility = Visibility.Visible;
            BtnRemWR5.Visibility = Visibility.Collapsed;
            PnlWR5.Visibility = Visibility.Collapsed;
        }
        private void BtnAddWR6_Click(object sender, RoutedEventArgs e)
        {
            BtnAddWR6.Visibility = Visibility.Collapsed;
            BtnRemWR6.Visibility = Visibility.Visible;
            PnlWR6.Visibility = Visibility.Visible;
        }

        private void BtnRemWR6_Click(object sender, RoutedEventArgs e)
        {
            BtnAddWR6.Visibility = Visibility.Visible;
            BtnRemWR6.Visibility = Visibility.Collapsed;
            PnlWR6.Visibility = Visibility.Collapsed;
        }
        private void BtnAddRBS_Click(object sender, RoutedEventArgs e)
        {
            BtnAddRBS.Visibility = Visibility.Collapsed;
            BtnRemRBS.Visibility = Visibility.Visible;
            PnlRBS.Visibility = Visibility.Visible;
        }

        private void BtnRemRBS_Click(object sender, RoutedEventArgs e)
        {
            BtnAddRBS.Visibility = Visibility.Visible;
            BtnRemRBS.Visibility = Visibility.Collapsed;
            PnlRBS.Visibility = Visibility.Collapsed;
        }
        private void BtnAddMFP_Click(object sender, RoutedEventArgs e)
        {
            BtnAddMFP.Visibility = Visibility.Collapsed;
            BtnRemMFP.Visibility = Visibility.Visible;
            PnlMFP.Visibility = Visibility.Visible;
        }

        private void BtnRemMFP_Click(object sender, RoutedEventArgs e)
        {
            BtnAddMFP.Visibility = Visibility.Visible;
            BtnRemMFP.Visibility = Visibility.Collapsed;
            PnlMFP.Visibility = Visibility.Collapsed;
        }
        private void BtnAddAng_Click(object sender, RoutedEventArgs e)
        {
            BtnAddAng.Visibility = Visibility.Collapsed;
            BtnRemAng.Visibility = Visibility.Visible;
            PnlAng.Visibility = Visibility.Visible;
        }

        private void BtnRemAng_Click(object sender, RoutedEventArgs e)
        {
            BtnAddAng.Visibility = Visibility.Visible;
            BtnRemAng.Visibility = Visibility.Collapsed;
            PnlAng.Visibility = Visibility.Collapsed;
        }
        private void BtnAddMP_Click(object sender, RoutedEventArgs e)
        {
            BtnAddMP.Visibility = Visibility.Collapsed;
            BtnRemMP.Visibility = Visibility.Visible;
            PnlMP.Visibility = Visibility.Visible;
        }

        private void BtnRemMP_Click(object sender, RoutedEventArgs e)
        {
            BtnAddMP.Visibility = Visibility.Visible;
            BtnRemMP.Visibility = Visibility.Collapsed;
            PnlMP.Visibility = Visibility.Collapsed;
        }
        private void BtnAddATS_Click(object sender, RoutedEventArgs e)
        {
            BtnAddATS.Visibility = Visibility.Collapsed;
            BtnRemATS.Visibility = Visibility.Visible;
            PnlATS.Visibility = Visibility.Visible;
        }

        private void BtnRemATS_Click(object sender, RoutedEventArgs e)
        {
            BtnAddATS.Visibility = Visibility.Visible;
            BtnRemATS.Visibility = Visibility.Collapsed;
            PnlATS.Visibility = Visibility.Collapsed;
        }
        private void BtnAddSAA_Click(object sender, RoutedEventArgs e)
        {
            BtnAddSAA.Visibility = Visibility.Collapsed;
            BtnRemSAA.Visibility = Visibility.Visible;
            PnlSAA0.Visibility = Visibility.Visible;
            PnlSAA1.Visibility = Visibility.Visible;
            PnlSAA2.Visibility = Visibility.Visible;
            PnlSAA3.Visibility = Visibility.Visible;
            PnlSAA4.Visibility = Visibility.Visible;
            PnlSAA5.Visibility = Visibility.Visible;
            PnlSAA6.Visibility = Visibility.Visible;
            PnlSAA2_1.Visibility = Visibility.Visible;
            PnlSAA3_1.Visibility = Visibility.Visible;
            PnlSAA4_1.Visibility = Visibility.Visible;
            PnlSAA5_1.Visibility = Visibility.Visible;
            PnlSAA6_1.Visibility = Visibility.Visible;
        }

        private void BtnRemSAA_Click(object sender, RoutedEventArgs e)
        {
            BtnAddSAA.Visibility = Visibility.Visible;
            BtnRemSAA.Visibility = Visibility.Collapsed;
            PnlSAA0.Visibility = Visibility.Collapsed;
            PnlSAA1.Visibility = Visibility.Collapsed;
            PnlSAA2.Visibility = Visibility.Collapsed;
            PnlSAA3.Visibility = Visibility.Collapsed;
            PnlSAA4.Visibility = Visibility.Collapsed;
            PnlSAA5.Visibility = Visibility.Collapsed;
            PnlSAA6.Visibility = Visibility.Collapsed;
            PnlSAA2_1.Visibility = Visibility.Collapsed;
            PnlSAA3_1.Visibility = Visibility.Collapsed;
            PnlSAA4_1.Visibility = Visibility.Collapsed;
            PnlSAA5_1.Visibility = Visibility.Collapsed;
            PnlSAA6_1.Visibility = Visibility.Collapsed;
        }

        private void BtnAddPen_Click(object sender, RoutedEventArgs e)
        {
            BtnAddPen.Visibility = Visibility.Collapsed;
            BtnRemPen.Visibility = Visibility.Visible;
            PnlPen.Visibility = Visibility.Visible;
        }

        private void BtnRemPen_Click(object sender, RoutedEventArgs e)
        {
            BtnAddPen.Visibility = Visibility.Visible;
            BtnRemPen.Visibility = Visibility.Collapsed;
            PnlPen.Visibility = Visibility.Collapsed;
        }
        private void BtnAddAcc_Click(object sender, RoutedEventArgs e)
        {
            BtnAddAcc.Visibility = Visibility.Collapsed;
            BtnRemAcc.Visibility = Visibility.Visible;
            PnlAcc.Visibility = Visibility.Visible;
        }

        private void BtnRemAcc_Click(object sender, RoutedEventArgs e)
        {
            BtnAddAcc.Visibility = Visibility.Visible;
            BtnRemAcc.Visibility = Visibility.Collapsed;
            PnlAcc.Visibility = Visibility.Collapsed;
        }

        private void BtnAddSAA2_Click(object sender, RoutedEventArgs e)
        {
            BtnAddSAA2.Visibility = Visibility.Collapsed;
            BtnRemSAA2.Visibility = Visibility.Visible;
            BtnAddSAA3.Visibility = Visibility.Visible;
            BtnRemSAA3.Visibility = Visibility.Collapsed;
            PnlSAA2.Visibility = Visibility.Visible;
            PnlSAA3_1.Visibility = Visibility.Visible;

        }

        private void BtnRemSAA2_Click(object sender, RoutedEventArgs e)
        {
            BtnAddSAA2.Visibility = Visibility.Visible;
            BtnRemSAA2.Visibility = Visibility.Collapsed;
            PnlSAA2.Visibility = Visibility.Collapsed;
            PnlSAA3.Visibility = Visibility.Collapsed;
            PnlSAA4.Visibility = Visibility.Collapsed;
            PnlSAA5.Visibility = Visibility.Collapsed;
            PnlSAA6.Visibility = Visibility.Collapsed;
            PnlSAA3_1.Visibility = Visibility.Collapsed;
            PnlSAA4_1.Visibility = Visibility.Collapsed;
            PnlSAA5_1.Visibility = Visibility.Collapsed;
            PnlSAA6_1.Visibility = Visibility.Collapsed;
        }
        private void BtnAddSAA3_Click(object sender, RoutedEventArgs e)
        {
            BtnAddSAA3.Visibility = Visibility.Collapsed;
            BtnRemSAA3.Visibility = Visibility.Visible;
            BtnAddSAA4.Visibility = Visibility.Visible;
            BtnRemSAA4.Visibility = Visibility.Collapsed;
            PnlSAA3.Visibility = Visibility.Visible;
            PnlSAA3_1.Visibility = Visibility.Visible;
            PnlSAA4_1.Visibility = Visibility.Visible;
        }

        private void BtnRemSAA3_Click(object sender, RoutedEventArgs e)
        {
            BtnAddSAA3.Visibility = Visibility.Visible;
            BtnRemSAA3.Visibility = Visibility.Collapsed;
            PnlSAA3.Visibility = Visibility.Collapsed;
            PnlSAA4.Visibility = Visibility.Collapsed;
            PnlSAA4_1.Visibility = Visibility.Collapsed;
            PnlSAA5.Visibility = Visibility.Collapsed;
            PnlSAA5_1.Visibility = Visibility.Collapsed;
            PnlSAA6.Visibility = Visibility.Collapsed;
            PnlSAA6_1.Visibility = Visibility.Collapsed;
        }
        private void BtnAddSAA4_Click(object sender, RoutedEventArgs e)
        {
            BtnAddSAA4.Visibility = Visibility.Collapsed;
            BtnRemSAA4.Visibility = Visibility.Visible;
            BtnAddSAA5.Visibility = Visibility.Visible;
            BtnRemSAA5.Visibility = Visibility.Collapsed;
            PnlSAA4.Visibility = Visibility.Visible;
            PnlSAA5_1.Visibility = Visibility.Visible;

        }

        private void BtnRemSAA4_Click(object sender, RoutedEventArgs e)
        {
            BtnAddSAA4.Visibility = Visibility.Visible;
            BtnRemSAA4.Visibility = Visibility.Collapsed;
            PnlSAA4.Visibility = Visibility.Collapsed;
            PnlSAA5.Visibility = Visibility.Collapsed;
            PnlSAA5_1.Visibility = Visibility.Collapsed;
            PnlSAA6.Visibility = Visibility.Collapsed;
            PnlSAA6_1.Visibility = Visibility.Collapsed;
        }
        private void BtnAddSAA5_Click(object sender, RoutedEventArgs e)
        {
            BtnAddSAA5.Visibility = Visibility.Collapsed;
            BtnRemSAA5.Visibility = Visibility.Visible;
            BtnAddSAA6.Visibility = Visibility.Visible;
            BtnRemSAA6.Visibility = Visibility.Collapsed;
            PnlSAA5.Visibility = Visibility.Visible;
            PnlSAA6_1.Visibility = Visibility.Visible;

        }

        private void BtnRemSAA5_Click(object sender, RoutedEventArgs e)
        {
            BtnAddSAA5.Visibility = Visibility.Visible;
            BtnRemSAA5.Visibility = Visibility.Collapsed;
            PnlSAA5.Visibility = Visibility.Collapsed;
            PnlSAA6.Visibility = Visibility.Collapsed;
            PnlSAA6_1.Visibility = Visibility.Collapsed;
        }
        private void BtnAddSAA6_Click(object sender, RoutedEventArgs e)
        {
            BtnAddSAA6.Visibility = Visibility.Collapsed;
            BtnRemSAA6.Visibility = Visibility.Visible;
            PnlSAA6.Visibility = Visibility.Visible;
        }
        private void BtnRemSAA6_Click(object sender, RoutedEventArgs e)
        {
            BtnAddSAA6.Visibility = Visibility.Visible;
            BtnRemSAA6.Visibility = Visibility.Collapsed;
            PnlSAA6.Visibility = Visibility.Collapsed;
        }

        private void Wiki_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/hwrm/KarosGraveyard/wiki");
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Viserion WEPN File Editor\nBy Sastrei\n2021", "About", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.None, MessageBoxOptions.RightAlign);
        }
        private void MenuSaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveAs = new SaveFileDialog()
            {
                Filter = "WEPN files | *.wepn",
                Title = "Open WEPN file"
            };

            if (saveAs.ShowDialog() == true)
            {

                    path = saveAs.FileName;
                    SaveContent();

            }
        }

        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void SaveAsCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (IsFileOpen == true)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }


        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (IsFileOpen == true)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("File saved.");
        }
        private void SaveAsCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("File saved.");
        }

        private void CloseCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CloseCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Exiting");
        }

        private void OpenCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.FileName = "Select a file";
            openFile.Filter = "WEPN files | *.wepn";
            openFile.Title = "Open WEPN file";

            if (openFile.ShowDialog() == true)
            {
                path = openFile.FileName;
                content = File.ReadAllLines(path);
                joinedContent = string.Join("", content);
                splitContent = joinedContent.Split(';');

                ContentAcc_List.Text = String.Empty;
                ContentPen_List.Text = String.Empty;

                IsFileOpen = true;
                this.Title = path;

                ParseWepnFile();
                DisplayContent();
            }
        }
    }
}
