   M S B A M L   `   `   `  ���� F  BViserion_v1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Teditor_PlacementTeditor_Placement  "    Teditor_Placement.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:Teditor_Placement       � Title$  Viserion .WEPN Editor��$��1046.311��$��1347.99�� � 	Resources  �� 
TargetType �� Property �� Value��%�   '��       '�� (     '�� P     '�� x     �� " ��.���  � ��$ 0,5,0,5q��� " ��.���  � ��$ 0,5,0,5q��� " ��.���  � ��$ 0,5,0,5q��� " ��.���  � ��$ 	15,10,0,0q� J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command$ ApplicationCommands.Open��  -   $ ApplicationCommands.Close��  -   $ ApplicationCommands.Save��  -   $  ApplicationCommands.SaveAs��.��]� .+�o� $	��Top=�.@�m� $��_File��.@�m� $��_Open�� m� Command$ ApplicationCommands.Open���� m� -   $��_Save��$ ApplicationCommands.Save��m� -   $��Save _As�� m� InputGestureText$ 
Ctrl+Alt+S��$  ApplicationCommands.SaveAs���� m� -   $��_Exit��$ Alt+F4��$ ApplicationCommands.Close��m� $��_Help��.@�m� -   $��
_View Wiki��m� -	   $��_About���� $
��Auto=�.���� -
   	 ��Name$	 PnlRoot��
 �� Orientation$
 
Horizontal=�.+��� -    ��Name$ groupStartWeaponConfig������ �� $
��Bold"�.�startWeaponConfig.���� $
 Vertical=�.+��� $
 
Horizontal=�.+��� $
 Vertical=�.+��� $��25��.��Object Type�� $��25��.��
Mount Type�� $��25��.��Projectile Type�� $��25��.��ActivationType�� $��25��.��Launch Direction�� $��25��.��Penetration�� $��25��.��
Velocity�� $��25��.��Range�� $��25��.��Radius�� $��25��.��
Lifetime�� $��25��.��Anticipation Time�� $��25��.��Max FX Spawned�� $��25��.��
Shot Delay�� $��25��.��
Burst Time�� $��25��.��	Wait Time�� $��25��.��Max Azimuth Speed�� $��25��.��Max Declination Speed�� $��25��.��Speed Multiplier�� $��25��.��Skewer Threshold�� $��25��.��WeaponFire Script�� $
 Vertical=�.+��� -    ��Name$ ObjType��$��25��$	��135��$��Right=��� -   $ MntType��$��25��$��75��$��Right=��� -   $ PrjType��$��25��$��75��$��Right=��� -   $ ActType��$��25��$��75��$��Right=��� -   $ 	LaunchDir��$��25��$��50��$��Right=��� -   $	 Pen��$��25��$��75��$��Right=��� -    ��Name$ Velocity��$��25��$��50��$��Right=��� -   $ Range��$��25��$��50��$��Right=��� -   $ Radius��$��25��$��50��$��Right=��� -   $ Lifetime��$��25��$��50��$��Right=��� -   $ Anticipation��$��25��$��50��$��Right=��� -   $ MaxFX��$��25��$��50��$��Right=��� -   $ Delay��$��25��$��50��$��Right=��� -   $ Burst��$��25��$��50��$��Right=��� -   $
 Wait��$��25��$��50��$��Right=��� -   $ MaxAzi��$��25��$��50��$��Right=��� -   $ MaxDec��$��25��$��50��$��Right=��� -   $ 	SpeedMult��$��25��$��50��$��Right=��� -   $ Skewer��$��25��$��50��$��Right=��� -   $ WFScript��$��25��$	��100��$��Right=�� $��0��$��19��$��2�� � ColumnDefinitions �� $��* ��� $��* � � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��0��.��Target Prediction�� $��0��$��1��.��Check for Friendlies�� $��0��$��2��.��Shoot at Secondaries�� $��0��$��3��.��Scan for Enemies�� $��0��$��4��.��Track Outside Range�� $��0��$��5��.��Wait Until Code Red�� -     ��Name$ TargetPrediction��$��1��$��0��$��Center=�$��Right=��� -!   $ CheckForFriendlies��$��1��$��1��$��Center=�$��Right=��� -"   $ ShootAtSecondaries��$��1��$��2��$��Center=�$��Right=��� -#   $ ScanForEnemies��$��1��$��3��$��Center=�$��Right=��� -$   $ TrackOutsideRange��$��1��$��4��$��Center=�$��Right=��� -%   $ WaitUntilCodeRed��$��1��$��5��$��Center=�$��Right=��� $
 Vertical=�.+��� -&   $ GrpMK������ �� $
��Bold"�.�setMissileKiller.���� $
 Vertical=�.+�]� -'    ]�Name$ PnlMK��.+��� .��	Enabled�� -(   $ 	ContentMK��$��Right=�$��Center=� � ToolTip _� .��-+If checked, weapon can shoot down missiles.]� .+��� -)    ��Name$ BtnAddMK��$
��Left=�$��40��.��Add�� -*   $ BtnRemMK��$��Right=�$��60��.��Remove�� -+   $ GrpBal������ �� $
��Bold"�.�setBallistics.���� $
 Vertical=�.+�]� -,   $ PnlBal1��.+��� .��	Enabled�� --   $ ContentBal_Enable��$��Right=�$��Center=�]� -.   $ PnlBal2��.+��� .��	Leading�� -/   $ ContentBal_Leading��$��50��$��Right=�]� .+��� -0   $ 	BtnAddBal��$
��Left=�$��40��.��Add�� -1   $ 	BtnRemBal��$��Right=�$��60��.��Remove�� -2   $ GrpLM������ �� $
��Bold"�.�setLifetimeMult.���� $
 Vertical=�.+�]� -3   $ PnlLM��.+��� .��Value�� -4   $ 	ContentLM��$��50��$��Right=�]� .+��� -5   $ BtnAddLM��$
��Left=�$��40��.��Add�� -6   $ BtnRemLM��$��Right=�$��60��.��Remove�� -7   $ GrpFMF������ �� $
��Bold"�.�setFireMultFactor.���� $
 Vertical=�.+�]� -8   $ PnlFMF��.+��� .��Value�� -9   $ 
ContentFMF��$��50��$��Right=�]� .+��� -:   $ 	BtnAddFMF��$
��Left=�$��40��.��Add�� -;   $ 	BtnRemFMF��$��Right=�$��60��.��Remove�� -<   $ GrpDMF������ �� $
��Bold"�.�setDamageMultFactor.���� $
 Vertical=�.+�]� -=   $ PnlDMF��.+��� .��Value�� ->   $ 
ContentDMF��$��50��$��Right=�]� .+��� -?   $ 	BtnAddDMF��$
��Left=�$��40��.��Add�� -@   $ 	BtnRemDMF��$��Right=�$��60��.��Remove�� -A   $ GrpFT������ �� $
��Bold"�.�setFrustratedTimers.���� $
 Vertical=�.+�]� -B   $ PnlFT1��.+��� .��Min�� -C   $ ContentFT_Min��$��50��$��Right=�]� -D   $ PnlFT2��.+��� .��Max�� -E   $ ContentFT_Max��$��50��$��Right=�]� .+��� -F   $ BtnAddFT��$
��Left=�$��40��.��Add�� -G   $ BtnRemFT��$��Right=�$��60��.��Remove�� -H   $ GrpMV������ �� $
��Bold"�.�setMiscValues.���� $
 Vertical=�.+�]� -I   $ PnlMV1��.+��� .��Recoil�� -J   $ ContentMV_Recoil��$��50��$��Right=�]� -K   $ PnlMV2��.+��� .��Delay�� -L   $ ContentMV_Delay��$��50��$��Right=�]� .+��� -M   $ BtnAddMV��$
��Left=�$��40��.��Add�� -N   $ BtnRemMV��$��Right=�$��60��.��Remove�� -O   $ GrpAF������ �� $
��Bold"�.�setAccuracyFalloff.���� $
 Vertical=�.+�]� -P   $ PnlAF1��.+��� .��	Value 1�� -Q   $ ContentAF_Val1��$��80��$��Right=�]� -R   $ PnlAF2��.+��� .��	Value 2�� -S   $ ContentAF_Val2��$��50��$��Right=�]� .+��� -T   $ BtnAddAF��$
��Left=�$��40��.��Add�� -U   $ BtnRemAF��$��Right=�$��60��.��Remove�� -V   $ GrpDF������ �� $
��Bold"�.�setDamageFalloff.���� $
 Vertical=�.+�]� -W   $ PnlDF1��.+��� .��	Value 1�� -X   $ ContentDF_Val1��$��80��$��Right=�]� -Y   $ PnlDF2��.+��� .��	Value 2�� -Z   $ ContentDF_Val2��$��50��$��Right=�]� .+��� -[   $ BtnAddDF��$
��Left=�$��40��.��Add�� -\   $ BtnRemDF��$��Right=�$��60��.��Remove�� $
 Vertical=�.+�]� .+��� $
 Vertical=�.+�]� .+��� -]   $ GrpWR1������ �� $
��Bold"�.�addWeaponResult.���� $
 Vertical=�.+��� -^   $	 PnlWR1��$
 
Horizontal=�.+��� $
 Vertical=�.+��� $��25��.��	Condition�� $��25��.��Effect�� $��25��.��Target�� $��25��.��Min�� $��25��.��Max�� $��25��.��Effect Name�� $
 Vertical=�.+��� -_   $ ContentWR1_Condition��$��25��$��75��$��Right=��� -`   $ ContentWR1_Effect��$��25��$	��120��$��Right=��� -a   $ ContentWR1_Target��$��25��$��75��$��Right=��� -b   $ ContentWR1_Min��$��25��$��50��$��Right=��� -c   $ ContentWR1_Max��$��25��$��50��$��Right=��� -d   $ ContentWR1_Name��$��25��$	��120��$��Right=�]� .+��� -e   $ 	BtnAddWR1��$
��Left=�$��40��.��Add�� -f   $ 	BtnRemWR1��$��Right=�$��60��.��Remove�� -g   $ GrpWR2������ �� $
��Bold"�.�addWeaponResult.���� $
 Vertical=�.+��� -h   $	 PnlWR2��$
 
Horizontal=�.+��� $
 Vertical=�.+��� $��25��.��	Condition�� $��25��.��Effect�� $��25��.��Target�� $��25��.��Min�� $��25��.��Max�� $��25��.��Effect Name�� $
 Vertical=�.+��� -i   $ ContentWR2_Condition��$��25��$	��100��$��Right=��� -j   $ ContentWR2_Effect��$��25��$	��100��$��Right=��� -k   $ ContentWR2_Target��$��25��$	��100��$��Right=��� -l   $ ContentWR2_Min��$��25��$��50��$��Right=��� -m   $ ContentWR2_Max��$��25��$��50��$��Right=��� -n   $ ContentWR2_Name��$��25��$��50��$��Right=�]� .+��� -o   $ 	BtnAddWR2��$
��Left=�$��40��.��Add�� -p   $ 	BtnRemWR2��$��Right=�$��60��.��Remove�� -q   $ GrpWR3������ �� $
��Bold"�.�addWeaponResult.���� $
 Vertical=�.+��� -r   $	 PnlWR3��$
 
Horizontal=�.+��� $
 Vertical=�.+��� $��25��.��	Condition�� $��25��.��Effect�� $��25��.��Target�� $��25��.��Min�� $��25��.��Max�� $��25��.��Effect Name�� $
 Vertical=�.+��� -s   $ ContentWR3_Condition��$��25��$	��100��$��Right=��� -t   $ ContentWR3_Effect��$��25��$	��100��$��Right=��� -u   $ ContentWR3_Target��$��25��$	��100��$��Right=��� -v   $ ContentWR3_Min��$��25��$��50��$��Right=��� -w   $ ContentWR3_Max��$��25��$��50��$��Right=��� -x   $ ContentWR3_Name��$��25��$��50��$��Right=�]� .+��� -y   $ 	BtnAddWR3��$
��Left=�$��40��.��Add�� -z   $ 	BtnRemWR3��$��Right=�$��60��.��Remove]� .+��� -{   $ GrpWR4������ �� $
��Bold"�.�addWeaponResult.���� $
 Vertical=�.+��� -|   $	 PnlWR4��$
 
Horizontal=�.+��� $
 Vertical=�.+��� $��25��.��	Condition�� $��25��.��Effect�� $��25��.��Target�� $��25��.��Min�� $��25��.��Max�� $��25��.��Effect Name�� $
 Vertical=�.+��� -}   $ ContentWR4_Condition��$��25��$	��100��$��Right=��� -~   $ ContentWR4_Effect��$��25��$	��100��$��Right=��� -   $ ContentWR4_Target��$��25��$	��100��$��Right=��� -�   $ ContentWR4_Min��$��25��$��50��$��Right=��� -�   $ ContentWR4_Max��$��25��$��50��$��Right=��� -�   $ ContentWR4_Name��$��25��$��50��$��Right=�]� .+��� -�   $ 	BtnAddWR4��$
��Left=�$��40��.��Add�� -�   $ 	BtnRemWR4��$��Right=�$��60��.��Remove�� -�   $ GrpWR5������ �� $
��Bold"�.�addWeaponResult.���� $
 Vertical=�.+��� -�   $	 PnlWR5��$
 
Horizontal=�.+��� $
 Vertical=�.+��� $��25��.��	Condition�� $��25��.��Effect�� $��25��.��Target�� $��25��.��Min�� $��25��.��Max�� $��25��.��Effect Name�� $
 Vertical=�.+��� -�   $ ContentWR5_Condition��$��25��$	��100��$��Right=��� -�   $ ContentWR5_Effect��$��25��$	��100��$��Right=��� -�   $ ContentWR5_Target��$��25��$	��100��$��Right=��� -�   $ ContentWR5_Min��$��25��$��50��$��Right=��� -�   $ ContentWR5_Max��$��25��$��50��$��Right=��� -�   $ ContentWR5_Name��$��25��$��50��$��Right=�]� .+��� -�   $ 	BtnAddWR5��$
��Left=�$��40��.��Add�� -�   $ 	BtnRemWR5��$��Right=�$��60��.��Remove�� -�   $ GrpWR6������ �� $
��Bold"�.�addWeaponResult.���� $
 Vertical=�.+��� -�   $	 PnlWR6��$
 
Horizontal=�.+��� $
 Vertical=�.+��� $��25��.��	Condition�� $��25��.��Effect�� $��25��.��Target�� $��25��.��Min�� $��25��.��Max�� $��25��.��Effect Name�� $
 Vertical=�.+��� -�   $ ContentWR6_Condition��$��25��$	��100��$��Right=��� -�   $ ContentWR6_Effect��$��25��$	��100��$��Right=��� -�   $ ContentWR6_Target��$��25��$	��100��$��Right=��� -�   $ ContentWR6_Min��$��25��$��50��$��Right=��� -�   $ ContentWR6_Max��$��25��$��50��$��Right=��� -�   $ ContentWR6_Name��$��25��$��50��$��Right=�]� .+��� -�   $ 	BtnAddWR6��$
��Left=�$��40��.��Add�� -�   $ 	BtnRemWR6��$��Right=�$��60��.��Remove]� .+��� $
 Vertical=�.+��� -�   $ GrpRB������ �� $
��Bold"�.�setRangeBoost.���� $
 Vertical=�.+�]� -�   $ PnlRB��.+��� .��Value�� -�   $ 	ContentRB��$��50��$��Right=�]� .+��� -�   $ BtnAddRB��$
��Left=�$��40��.��Add�� -�   $ BtnRemRB��$��Right=�$��60��.��Remove�� -�   $ GrpRBS������ �� $
��Bold"�.�setRangeByStance.���� $
 Vertical=�.+�]� -�   $ PnlRBS��.+��� $
 Vertical=�.+��� $��25��.��	Passive�� $��25��.��	Neutral�� $��25��.��
Aggressive�� $
 Vertical=�.+��� -�   $ ContentRBS_Psv��$��25��$��50��$��Right=��� -�   $ ContentRBS_Neu��$��25��$��50��$��Right=��� -�   $ ContentRBS_Agg��$��25��$��50��$��Right=�]� .+��� -�   $ 	BtnAddRBS��$
��Left=�$��40��.��Add�� -�   $ 	BtnRemRBS��$��Right=�$��60��.��Remove�� -�   $ GrpMFP������ �� $
��Bold"�.�setMagneticFieldPenetration.���� $
 Vertical=�.+�]� -�   $ PnlMFP��.+��� $
 Vertical=�.+��� $��25��.��	Value 1�� $��25��.��	Value 2�� $��25��.��	Value 3�� $
 Vertical=�.+��� -�   $ ContentMFP_Val1��$��25��$��50��$��Right=��� -�   $ ContentMFP_Val2��$��25��$	��100��$��Right=��� -�   $ ContentMFP_Val3��$��25��$��50��$��Right=�]� .+��� -�   $ 	BtnAddMFP��$
��Left=�$��40��.��Add�� -�   $ 	BtnRemMFP��$��Right=�$��60��.��Remove�  �� $��* ��� $��* � �� $��* ��� $
��Auto �.+��� -�   $ GrpAng��$��0��$��0������ �� $
��Bold"�.�	setAngles.���� $
 Vertical=�.+�]� -�   $ PnlAng��.+��� $
 Vertical=�.+��� $��25��.��Firing Cone�� $��25��.��Min Azimuth�� $��25��.��Max Azimuth�� $��25��.��Min Declination�� $��25��.��Max Declination�� $
 Vertical=�.+��� -�   $ ContentAng_Cone��$��25��$��50��$��Right=��� -�   $ ContentAng_MinAzi��$��25��$��50��$��Right=��� -�   $ ContentAng_MaxAzi��$��25��$��50��$��Right=��� -�   $ ContentAng_MinDec��$��25��$��50��$��Right=��� -�   $ ContentAng_MaxDec��$��25��$��50��$��Right=�]� .+��� -�   $ 	BtnAddAng��$
��Left=�$��40��.��Add�� -�   $ 	BtnRemAng��$��Right=�$��60��.��Remove�� -�   $ GrpMP��$��1��$��0������ �� $
��Bold"�.�setMissProperties.���� $
 Vertical=�.+�]� -�   $ PnlMP��.+��� $
 Vertical=�.+��� $��25��.��Cone Horizontal�� $��25��.��Cone Vertical�� $��25��.��
Damage Low�� $��25��.��Damage High�� $��25��.��Speed�� $��25��.��
Lifetime�� $
 Vertical=�.+��� -�   $ ContentMP_ConeHor��$��25��$��50��$��Right=��� -�   $ ContentMP_ConeVer��$��25��$��50��$��Right=��� -�   $ ContentMP_DmgLo��$��25��$��50��$��Right=��� -�   $ ContentMP_DmgHi��$��25��$��50��$��Right=��� -�   $ ContentMP_Speed��$��25��$��50��$��Right=��� -�   $ ContentMP_Life��$��25��$��50��$��Right=�]� .+��� -�   $ BtnAddMP��$
��Left=�$��40��.��Add�� -�   $ BtnRemMP��$��Right=�$��60��.��Remove�� -�   $ GrpATS��$��0��$��1��$��2������ �� $
��Bold"�.�addAnimTurretSound.���� $
 Vertical=�.+�]� -�   $ PnlATS��.+��� .��Path�� -�   $ 
ContentATS��$	��300��$��Right=�]� .+��� -�   $ 	BtnAddATS��$
��Left=�$��40��.��Add�� -�   $ 	BtnRemATS��$��Right=�$��60��.��Remove]� .+�]� .+��  �� $��* � �� $
��Auto ��� $��* ��� $��* �.+��� -�   $ GrpSAA��$��0��$��0������ �� $
��Bold"�.�setSpeedvsAccuracyAgainst.��]� -�   $ PnlSAA��.+��  �� $��* � �� $
��Auto ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+�]� -�   $ PnlSAA0��$��0��.+��� .��
Override�� -�   $ ContentSAA_Override��$��Center=�$��Right=�]� -�   $ PnlSAA1��$��1��.+��� -�    ��Name$ 	LblSpeed1��$��25��.��	Speed 1�� -�   $ ContentSAA_Speed1��$��25��$��50��$��Right=��� -�   $ LblAcc1��$��10,0,0,0q�$��25��.��
Accuracy 1�� -�   $ ContentSAA_Acc1��$��25��$��50��$��Right=��� $
 Vertical=�$��2��.+�]� -�   $ PnlSAA2��.+��� -�   $ 	LblSpeed2��$��25��.��	Speed 2�� -�   $ ContentSAA_Speed2��$��25��$��50��$��Right=��� -�   $ LblAcc2��$��10,0,0,0q�$��25��.��
Accuracy 2�� -�   $ ContentSAA_Acc2��$��25��$��50��$��Right=�]� -�   $ 	PnlSAA2_1��.+��� -�   $ 
BtnAddSAA2��$
��Left=�$��40��.��Add�� -�   $ 
BtnRemSAA2��$��Right=�$��60��.��Remove�� $
 Vertical=�$��3��.+�]� -�   $ PnlSAA3��.+��� -�   $ 	LblSpeed3��$��25��.��	Speed 3�� -�   $ ContentSAA_Speed3��$��25��$��50��$��Right=��� -�   $ LblAcc3��$��10,0,0,0q�$��25��.��
Accuracy 3�� -�   $ ContentSAA_Acc3��$��25��$��50��$��Right=�]� -�   $ 	PnlSAA3_1��.+��� -�   $ 
BtnAddSAA3��$
��Left=�$��40��.��Add�� -�   $ 
BtnRemSAA3��$��Right=�$��60��.��Remove�� $
 Vertical=�$��4��.+�]� -�   $ PnlSAA4��.+��� -�   $ 	LblSpeed4��$��25��.��	Speed 4�� -�   $ ContentSAA_Speed4��$��25��$��50��$��Right=��� -�   $ LblAcc4��$��10,0,0,0q�$��25��.��
Accuracy 4�� -�   $ ContentSAA_Acc4��$��25��$��50��$��Right=�]� -�   $ 	PnlSAA4_1��.+��� -�   $ 
BtnAddSAA4��$
��Left=�$��40��.��Add�� -�   $ 
BtnRemSAA4��$��Right=�$��60��.��Remove�� $
 Vertical=�$��5��.+�]� -�   $ PnlSAA5��.+��� -�   $ 	LblSpeed5��$��25��.��	Speed 5�� -�   $ ContentSAA_Speed5��$��25��$��50��$��Right=��� -�   $ LblAcc5��$��10,0,0,0q�$��25��.��
Accuracy 5�� -�   $ ContentSAA_Acc5��$��25��$��50��$��Right=�]� -�   $ 	PnlSAA5_1��.+��� -�   $ 
BtnAddSAA5��$
��Left=�$��40��.��Add�� -�   $ 
BtnRemSAA5��$��Right=�$��60��.��Remove�� $
 Vertical=�$��6��.+�]� -�   $ PnlSAA6��.+��� -�   $ 	LblSpeed6��$��25��.��	Speed 6�� -�   $ ContentSAA_Speed6��$��25��$��50��$��Right=��� -�   $ LblAcc6��$��10,0,0,0q�$��25��.��
Accuracy 6�� -�   $ ContentSAA_Acc6��$��25��$��50��$��Right=�]� -�   $ 	PnlSAA6_1��.+��� -�   $ 
BtnAddSAA6��$��Right=�$��40��.��Add�� -�   $ 
BtnRemSAA6��$��Right=�$��60��.��Remove]� -�   $ PnlSAA7��$��7��.+��� -�   $ 	BtnAddSAA��$
��Left=�$��40��.��Add�� -�   $ 	BtnRemSAA��$��Right=�$��60��.��Remove�� -�   $ GrpPen��$��0��$��1������ �� $
��Bold"�.�setPenetration.���� $
 Vertical=�.+�]� -�   $ PnlPen��.+��  �� $��* ��� $��* � �� $
��Auto ��� $
��Auto ��� $	��250 �.+��� $��0��$��0��.��Field Penetration�� $��0��$��1��.��Default Penetration�� -�   $ ContentPen_Fld��$��1��$��0���� -�   $ ContentPen_Def��$��1��$��1���� -�   $ ContentPen_List��$��0��$��2��$��2��$
��Auto��]� .+��� -�   $ 	BtnAddPen��$
��Left=�$��40��.��Add�� -�   $ 	BtnRemPen��$��Right=�$��60��.��Remove�� -�   $ GrpAcc��$��0��$��2������ �� $
��Bold"�.�setAccuracy.���� $
 Vertical=�.+�]� -   $ PnlAcc��.+��  �� $��* ��� $��* � �� $
��Auto ��� $	��250 �.+��� $��0��$��0��.��Default Accuracy�� -  $ ContentAcc_Def��$��1��$��0���� -  $ ContentAcc_List��$��0��$��1��$��2��$
��Auto��]� .+��� -  $ 	BtnAddAcc��$
��Left=�$��40��.��Add�� -  $ 	BtnRemAcc��$��Right=�$��60��.��Remove