   M S B A M L   `   `   `  ����L  HDoAnCuoiKy_Medias, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:DoAnCuoiKy_MediasDoAnCuoiKy_Medias  5      7    1DoAnCuoiKy_Medias.UserControlMedias.UserControlUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      +localclr-namespace:DoAnCuoiKy_Medias  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      -   5        $��ucControlBar��5	      .  (System.Windows.Interactivity.Interaction    Triggers  5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ MouseLeftButtonDown��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *MouseMoveWindowCommand+   CommandParameter 6O   ��  �� ElementName$ ucControlBar��5      .��5      � .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone     Mode$ Inverted=�6#   $��60��63   ��5      �� 5       �� Opacity$	 0.5Q�6"    �� Color$ Black��60   .��5      ]� .+�5      �� 	 �� Orientation$	 
Horizontal=�6   $��Right=�66   $��0,0,10,0q�6M   .+�5      �� $��50��6   $��35��6(   
 � ToolTip$
 MaterialDesignFlatButton��64   ��6W   �� *MinimizeWindowCommand+��6�   �� $ ucControlBar����5      '  !MaterialDesignThemes.Wpf.PackIcon  5         Kind$ WindowMinimize=�66   
�������6a   ��5      �� 5       �� 
TargetType" ��6$    !  MaterialDesignFlatMidBgButton �� BasedOn# [  68   .�5   "   ��  �� Property � �� �� Value
 ���� 6U   �� 5   "    � ��
 ���� 6V    �� Triggers 5   "   P� 5    &    P� Property �@J�IsMouseOver P� Value . . �5!   *   ��  � �� �	#FF7878786[   �� 5"   *    � �� �	#FF7878786\   5#   '   5%      5'      �� 5(      $��50��6   $��35��6(   $
 MaterialDesignFlatButton��64   ��6W   �� *MaximizeWindowCommand+��6�   �� $ ucControlBar����5)        5*      $ WindowMaximize=�66   
�������6a   ��5,      �� 5-      " ��6$   # [  68   .�5.   "   ��  � ��
 ���� 6U   �� 5/   "    � ��
 ���� 6V    50   "   P� 51   &    �@J�IsMouseOver . . �52   *   ��  � �� �	#FF7878786[   �� 53   *    � �� �	#FF7878786\   54   '   56      58      �� 59      $��50��6   $��35��6(   $
 MaterialDesignFlatButton��64   ��6W   �� *CloseWindowCommand+��6~   �� $ ucControlBar����5:        5;      $ WindowClose=�66   
�������6^   ��5=      �� 5>      " ��6$   # [  68   .�5?   "   ��  � ��
 ���� 6U   �� 5@   "    � ��
 ���� 6V    5A   "   P� 5B   &    �@J�IsMouseOver . . �5C   *   ��  � ��
 �  ��6U   �� 5D   *    � ��
 �  ��6V   5E   '   5G      5I      5J      �� 5K      $	 
Horizontal=�6   5L      5M      5N      5O      5P      