   M S B A M L   `   `   `  ����  FFmpegMediaConvert.    (FFmpegMediaConvert.Controler.AudioSelect   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      �   � ColumnDefinitions  5	   
   �� 5
      $	��100 �6   �� 5      $
��200* �6    � RowDefinitions 5   
   �� 5      $	��30* �6   �� 5      $	��30* �6   �� 5      $	��30* �6   �� 5      $	��30* �6   .+�5   
   �� $��Audio Code:��6   $��0��6'      TextBlockLable#��[  64   �� 5   
   $��SampleRate:��6   $��1��6'   #��[  64   �� 5   
   $��BitRate:��6   $��2��6$   #��[  61   �� 5   
   $��Chanel:��6   $��3��6#   #��[  60   �� 5   
   -   5         ��Name$ cb_AudioCode��5      $��1��6)   $��0��69   � 5   
   $��1��6   $��1��6     5      �� 5      $	��70* �6#   �� 5      $	��30* �6#   .+�5      �� -   5         ��Name$ txt_SampleRate��5      $��44100��6.   $��0��6;   �� 5      $��Hz��6   $��1��6"    �� TextAlignment$ Center=�62   $��Center=�6I   5      � 5    
   $��2��6   $��1��6     5!      �� 5"      $	��70* �6#   �� 5#      $	��30* �6#   .+�5%      �� -   5        $ txt_BitRate��5%      $	��320��6+   $��0��66   �� 5&      $
��Kbps��6   $��1��6$   $ Center=�64   $��Center=�6K   5'      �� 5(   
   -   5        $ 
cb_channel��5(      $��1��6'   $��3��67   5)      5*      