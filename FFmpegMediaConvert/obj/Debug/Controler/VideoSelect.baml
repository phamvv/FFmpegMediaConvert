   M S B A M L   `   `   `  ����M  IFFmpegMediaConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:FFmpegMediaConvert.ControlerFFmpegMediaConvert.Controler  5      .    (FFmpegMediaConvert.Controler.VideoSelect   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:FFmpegMediaConvert.Controler     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $	��100 �6   �� 5      $
��200* �6    � RowDefinitions 5   
   �� 5      $	��30* �6   �� 5      $	��30* �6   �� 5      $	��30* �6   �� 5      $	��30* �6   �� 5      $	��30* �6   �� 5      $	��30* �6   �� 5      $	��30* �6   .+�5   
   �� $��Video Code:��6   $��0��6'      TextBlockLable#��[  64   �� 5   
   -   5         ��Name$ tbl_VideoSelected��5      $��Videos Size:��6/   $��1��6C   #��[  6P   �� 5   
   -   5        $ 	tbl_Ratio��5      $��Ratio:��6'   $��2��65   #��[  6C   �� 5   
   -   5        $ 	tbl_Width��5      $��Width:��6'   $��3��65   #��[  6C   �� 5   
   -   5        $ 	tbl_Hight��5      $��Hight:��6'   $��4��65   #��[  6C   �� 5   
   $��FrameRate (FPS):��6   $��5��6,   #��[  69   �� 5   
   $��Bit Rate (Kbs/s):��6   $��6��6-   #��[  6:   �� 5   
   -   5         ��Name$ cb_Code��5      $��1��6$   $��0��64   6A   �� 5    
   -   5        $ cb_VideoSize��5       $��1��6)   $��1��69   6F   �� 5!   
   -   5        $ cb_Ratio��5!      $��1��6%   $��2��65   6B   �� 5"   
   -   5         ��Name$ 	txt_Width��5"       �� 
IsReadOnly . $��3��67   $��1��6D   �� 5#   
   -	   5        $ 	txt_Hight��5#       . $��4��67   $��1��6D   �� 5$   
   -
   5        $ txt_frameRate��5$      $��30��6)   $��5��63   $��1��6@   �� 5%   
   -   5        $ txt_bitRate��5%      $
��2500��6'   $��6��63   $��1��6@   5'      5(      