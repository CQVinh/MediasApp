   M S B A M L   `   `   `  ����L  HDoAnCuoiKy_Medias, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:DoAnCuoiKy_Medias.ViewDoAnCuoiKy_Medias.View  5   	   Y1clr-namespace:DoAnCuoiKy_Medias.UserControlMedias#DoAnCuoiKy_Medias.UserControlMedias  5   	   C&clr-namespace:DoAnCuoiKy_Medias.DomainDoAnCuoiKy_Medias.Domain  5
   	   1    +DoAnCuoiKy_Medias.View.ForgotPasswordWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:DoAnCuoiKy_Medias.View     5   	   @uc1clr-namespace:DoAnCuoiKy_Medias.UserControlMedias     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	   	   3domain&clr-namespace:DoAnCuoiKy_Medias.Domain  5
   	   -   5        $��forgotpasswordWindow��5   	   $��Regular"�5   	   $��14(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	      ForgotPasswordVM � DataContext# [  5   	    � Title$ ForgotPasswordWindow��5   	   $	��550��6&   $
��1000��63   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6$   �� *LoadedForgotPasswordCommand+   CommandParameter 6T   ��  �� ElementName$ forgotpasswordWindow��5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $��* �6   6)   ��5!   
   �� 5"       �� ImageSource$ /Images/Background.jpg��6    j� Stretch$
 Fill=�6>   6O   .+�5$   
   7   1DoAnCuoiKy_Medias.UserControlMedias.UserControlUC  $��0��6   6*   �� 5%   
   $��1��6   $��
NetComplex��6   $��30(�62   $��
UltraBlack"�6@   
���  ��$��	30,0,30,0q�6i   6~   � 5&   
   $��2��6   $��Center=�6   $��Center=�69   $	��300��6T   $	��420��6`   ��5'      �� 5(       �� Opacity$	 0.7Q�6"    �� Color$ Black��60   .+�5*      �  5+      �� 5,      $��60 �6$   62   �� 5-      $��60 �6$   62   �� 5.      $	��210 �6$   63   �� 5/      $��70 �6$   62   .+�51      � $��0��6   .+�52      �� $��Forgot Password��6   $��25(�66   $
��Bold"�6D   
�������$��Center=�6i   $��	10,0,10,0q�6�   6�   53      � 54      $��1��6   $��0,0,0,10q�6$   y�66   �� *VisibilityError+.+�55      �� $��	10,0,10,0q�6   
��� ���$��2q�6E   
��� ��� �� CornerRadius$ 5��6m   ._�56      �� $��11(�6;   $
��Bold"�6I   
��� ���
�������$��5q�6�   $
��Wrap=�6�   $��Center=�6�   $��Center=�6�   ��6$   �� *Error+6�   57      58      � 59      $��2��6   .+�5:      �� .+�5;      �� $��50��6!   
�������
���   �$��2q�6S   $ 5��6g   $��
10,0,10,10q�6x   ._�5<      �� )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Email:��6&   /  )MaterialDesignThemes.Wpf.ValidationAssist   UsePopup .    
Background
 ����    FontSize$ 12Q�6�   $��0,0,0,10q�6�      
Foreground
 � � �.	  (MaterialDesignThemes.Wpf.TextFieldAssist 	  UnderlineBrush
 � � � % !MaterialDesignFloatingHintTextBox#��[ 6[  $��Center=�6�  $��	10,0,10,0q�6�  .��6�  ��5=   "   �� 5>   &    �� Path$ Email�6.    �� UpdateSourceTrigger$ PropertyChanged=�6;    �� ValidationRules 5?   *   6
   0DoAnCuoiKy_Medias.Domain.EmailForgotPasswordRule
  5@   .   ,  &System.Windows.Controls.ValidationRule   ValidatesOnTargetUpdated . 6M   5B   '   .��5C   0   5D      5E      �� 5F      $��50��6!   
�������
���   �$��2q�6S   $ 5��6g   $��10q�6x   ._�5G      G� -   5         G�Name$ PasswordBox��5G   *   $ New Password:��6?    . 
 ���� $ 12Q�6�   $��0,0,0,10q�6  
 � � �
 � � � ) %MaterialDesignFloatingHintPasswordBox#��[ 6{  $��Center=�6�  $��	10,0,10,0q�6�  
 � Tag 5H   "   �� 5I   &    �� Mode$ OneWay=�6.   $ NewPassword�6<    5J   *   9   3DoAnCuoiKy_Medias.Domain.PasswordForgotPasswordRule  5K   .    . 6P   5M   '    5O   "     5P   &   $ PasswordChanged��65   .	 5Q   *     
 6@   �� *PasswordChangedCommand+ 6k   �� $ PasswordBox��5R   '   5T      5U      �� 5V      $��50��6!   
�������
���   �$��2q�6S   $ 5��6g   $��10q�6x   ._�5W      G� -   5        $ ConfirmPasswordBox��5W   *   $ Confirm New Password:��6F    . 
 ���� $ 12Q�6�   $��0,0,0,10q�6  
 � � �
 � � �#��[ 6�  $��Center=�6�  $��	10,0,10,0q�6�   5X   "   �� 5Y   &   $ OneWay=�6.   $ ConfirmNewPassword�6<    5Z   *   @   :DoAnCuoiKy_Medias.Domain.ConfirmPasswordForgotPasswordRule  5[   .    . 6W   5]   '    5_   "     5`   &   $ PasswordChanged��65   .	 5a   *     
 6@   �� *ConfirmPasswordChangedCommand+ 6r   �� $ ConfirmPasswordBox��5b   '   5d      5e      5f      5g      � 5h      $��3��6   .+�5i      �� $	��275��6   $��40��6)   +  %MaterialDesignThemes.Wpf.ButtonAssist    CornerRadius$  5��65   
���  ��
���  ��! �� 	IsDefault! . ��6�   �� *ForgotPasswordCommand+��6�   �� $ forgotpasswordWindow����5j      �� 5k      $��Continue��6%   $��15(�68   $
��Bold"�6F   
�������6m   5m      5n      5o      5p      5q      5r      