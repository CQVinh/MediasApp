   M S B A M L   `   `   `  ����L  HDoAnCuoiKy_Medias, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:DoAnCuoiKy_Medias.ViewDoAnCuoiKy_Medias.View  5   	   Y1clr-namespace:DoAnCuoiKy_Medias.UserControlMedias#DoAnCuoiKy_Medias.UserControlMedias  5   	   1    +DoAnCuoiKy_Medias.View.ChooseProfilesWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:DoAnCuoiKy_Medias.View     5   	   @uc1clr-namespace:DoAnCuoiKy_Medias.UserControlMedias     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	   	   -   5        $��chooseprofilesWindow��5   	   $��Regular"�5
   	   $��14(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	      
ProfilesVM � DataContext# [  5   	    � Title$ ChooseProfilesWindow��5   	   $	��550��6&   $
��1000��63   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6$   �� *LoadedCommand+   CommandParameter 6F   ��  �� ElementName$ chooseprofilesWindow��5      .��5      � .+�5   
   � 
���   � � RowDefinitions 5      �� 5      $
��Auto �6    60   �� 5      $
��Auto �6    60   �� 5      6"   .+�5!      �� $��0��6   $��Who's watching?��6!   
�������$��50(�6N   $��Center=�6\   $��Center=�6w   $��0,50,0,0q�6�   6�   �� 5"      $��1��6    �� Orientation$ 
Horizontal=�6&   $��Center=�6?   $��0,30,0,0q�6\   .+�5#      �� $��Disabled=�6n   ��6   �� *ProfilesList+ �� SelectedItem 6@   �� *SelectedItemProfiles+��5$      �� 5%      .R�5&      �� .+�5'   "   �� $��70��6B   $��70��6N   $��Center=�6Y   $��Center=�6v   ��6(   �� *Avatar+6�   �� 5(   "   $��1��6,   
�������$��14(�6a   $��Center=�6o   $��Center=�6�   $
��Wrap=�6�   $��0,10,0,0q�6�   ��69   �� *Name+6�   5)      5*      ��5,      �� 5-      .R�5.      $�  K� IsItemsHost .  $� Orientation$ 
Horizontal=�6H   5/      51      �� 52       " MaterialDesignRaisedDarkButton#��[ 6   $	��130��6�   $	��110��6�   
������ 
������ $��10,0,0,0q�6  ��6Q   �� *AddProfilesCommand+��6x   �� $ chooseprofilesWindow����53      �� 54      .+�55      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 
PlusCircle=�66   
�������$��75��6Z   $��75��6f   $��Center=�6q   $��Center=�6�   �� 56      $��Add Profiles��6(   
�������$��14(�6N   $��Center=�6\   $��Center=�6w   $��0,5,0,0q�6�   6�   57      59      5:      � 5;      $��2��6   $��Center=�6     � ColumnDefinitions 5<      �� 5=      6)   �� 5>      6)   .+�5@      �� $	��100��6   $��40��6%   #��[ 6�   
�������
���  ��$��0,0,60,0q�6�   ��61   �� *DoneCommand+��6Q   �� $ chooseprofilesWindow����5A      �� 5B      $��D O N E��6$   
�������$��15(�6F   $��Center=�6T   6q   5D      �� 5E      $��1��6   $	��300��6)   $��40��65   #��[ 6�   
�������
������ ��6A   �� *ManageProfilesCommand+��6k   �� $ chooseprofilesWindow����5F      �� 5G      $#��M A N A G E   P R O F I L E S��6$   
�������$��15(�6[   $��Center=�6i   6�   5I      5J      5K      � 5L   
   y�6   �� *ShowMessage+��5M      �� 5N       �� Opacity$
 0.01Q�6"    �� Color$ Black��61   6A   .+�5P      � $	��200��6   $	��300��6    ��5Q      �� 5R      $	 0.8Q�6&   $ Black��64   6D    5T      �� 5U      6&   �� 5V      $
��Auto �6$   64   .+�5X      �� $
��Bold"�65   
�������$��20(�6Z   $��Center=�6h   $��Center=�6�   $
��Wrap=�6�   $��5q�6�   ��6   �� *	Message+6�   �� 5Y      $��1��6   $	��100��6&   $��40��62   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 5��6>   
���  ��
���  ��$��10q�6�   ��6�   �� *MessageBoxCommand+��6�   �� $ chooseprofilesWindow����5Z      �� 5[      $��Ok��6    $��15(�6-   $
��Bold"�6;   
�������6b   5]      5^      5_      5`      5a      