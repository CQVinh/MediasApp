   M S B A M L   `   `   `  ����L  HDoAnCuoiKy_Medias, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:DoAnCuoiKy_Medias.ViewDoAnCuoiKy_Medias.View  5   	   Y1clr-namespace:DoAnCuoiKy_Medias.UserControlMedias#DoAnCuoiKy_Medias.UserControlMedias  5   	   C&clr-namespace:DoAnCuoiKy_Medias.DomainDoAnCuoiKy_Medias.Domain  5
   	   .    (DoAnCuoiKy_Medias.View.AddProfilesWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:DoAnCuoiKy_Medias.View     5   	   @uc1clr-namespace:DoAnCuoiKy_Medias.UserControlMedias     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	   	   3domain&clr-namespace:DoAnCuoiKy_Medias.Domain  5
   	   -   5        $��addprofilesWindow��5   	   $��Regular"�5   	   $��14(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	      AddProfilesVM � DataContext# [  5   	    � Title$ AddProfilesWindow��5   	   $	��550��6#   $
��1000��60   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6$   �� *LoadedCommand+   CommandParameter 6F   ��  �� ElementName$ addprofilesWindow��5      .��5      � 
���   � � RowDefinitions 5   
   �� 5      6   �� 5      $
��Auto �6   6,   �� 5      6   �� 5       6    � ColumnDefinitions 5"   
   �� 5#      $
��0.3* �6   6.   �� 5$      6!   �� 5%      $
��0.3* �6   6.   .+�5'   
   �� $��0��6   $��1��6   $��Add Profile��6-   
�������$��50(�6V   $��Center=�6d   6�   �� 5(   
   $��1��6   $��1��6!   $;��5Add a profile for another person watching NetComplex.��61   
�������6�   � 5)   
   $��2��6   $��1��6    5*      �� 5+      $
��Auto �6#   62   �� 5,      $	��350 �6#   61   .+�5.      � $��80��6   $��80��6    5/      �� 50      6)    52      �� 53      6&   .+�55      � 
�������.+�56      �� $��80��66   $��80��6B   ��6   �� *Avatar+6O   57      �� 58      $��80��6   $��80��6%   $��Center=�6�   $��Center=�6�    " MaterialDesignRaisedDarkButton#��[ 6�   ��60   �� *OpenFileImageCommand+��6Y   �� $ addprofilesWindow����59      �� 5:       �� Opacity$	 0.2Q�6*    �� Color$ Black��68   6H   ��5<      �� 5=      $	 0.2Q�6*   $ Black��68   6H   ��5?      '  !MaterialDesignThemes.Wpf.PackIcon  5@         Kind$ CircleEditOutline=�62   $��20��6K   $��20��6W   5B      5C      �� 5D      $��1��6   
�������$��20(�69   $��DemiBold"�6G   $��30��6]   
�������$��10,0,0,0q�6{   $��20,0,0,0q�6�   .��6�   ��5E      �� 5F       �� Path$
 Name�6    �� UpdateSourceTrigger$ PropertyChanged=�6*    �� ValidationRules 5G      1   +DoAnCuoiKy_Medias.Domain.NameAddProfileRule  5H      ,  &System.Windows.Controls.ValidationRule   ValidatesOnTargetUpdated . 68   5J      .��5K       5L      5M      � 5N   
   $��3��6   $��1��6   $	��Top=�6,   $��0,20,0,0q�6D    5O      �� 5P      $
��Auto �6#   62   �� 5Q      $
��Auto �6#   62   .+�5S      �� $��0��6   $	��200��6%   $��40��61   +	  %MaterialDesignThemes.Wpf.ButtonAssist 	  CornerRadius$	 2.5��6=   
���  ��
���  ��$��
0,20,20,20q�6�   ��6�   �� *ContinueCommand+��6�   �� $ addprofilesWindow����5T      �� 5U      $��CONTINUE��6   $��15(�60   $
��Bold"�6>   
�������6i   5W      �� 5X      $��1��6   $	��200��6%   $��40��61   $	 2.5��6=   
������ 
�������$��
0,20,20,20q�6�   ��6�   �� *CancelCommand+��6�   �� $ addprofilesWindow����5Y      �� 5Z      $��CANCEL��6   $��15(�6.   $
��Bold"�6<   
�������6b   5\      5]      5^      5_      