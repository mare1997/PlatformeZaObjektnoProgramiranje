   M S B A M L   `   `   `  ����G  CPOP-SF-9-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:POP_SF_9_GUI.UIPOP_SF_9_GUI.UI  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   "    POP_SF_9_GUI.UI.AkcijaWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:POP_SF_9_GUI.UI     5   	   9System&clr-namespace:System;assembly=mscorlib     5   	     � Title$  AkcijaWindow��5	   	   $	��300��6   $	��300��6+    � 	Resources 5
         TextBoxError)  #POP_SF_9_GUI.UI.ValidationConverter  	converter��%�   &	        &	 �     �� 5   
   .R�5      ]� ��. .+�5      �� $��Right=�6   
���  ��$
��12pt(�6D   Polje ne sme biti prazno!6o   �� 5      
���  ��$��1q�6+   ._�5      �� 5      5      5        5   
   6$   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��146 �6   �� 5      $	��231 �6    � RowDefinitions 5   
   �� 5      $��42.748 �6   �� 5      $��0.252 �6   �� 5      $	��43* �6   �� 5      $	��42* �6   �� 5      $
��141* �6   .+�5"   
   �� $��Popust:��6   $��0��6"   $��20(�6/   $��0,0,2,0q�6=   �� 5#   
   $��Datum pocetka akcije:��6   $��2��60   $��13(�6=   $��0,0,2,0q�6K    J� RenderTransformOrigin$ 0.5,0.5&�6\   z�5$      V� 5%      .~�5&      �� �� 5'      �� 5(       �� Angle$ 0.785Q�6&   T� 5)      5*      5,      �� 5-   
   $��Datum kraja akcije:��6   $��3��6.   $��13(�6;   $��0,0,2,0q�6I   �� 5.   
   -   5        $��tbPopust��5.      $��0��6"   $��1��6/   $��15(�6?   $��	3,10,98,5q�6M   .��6b   ��5/      �� 50       �� Path$ Popust�6    �� UpdateSourceTrigger$ PropertyChanged=�6(    �� ValidationRules 51        POP_SF_9_GUI.UI.PV  52      54      .��55      56      �� 57   
   -   5        $��Dodaj��57   !   $��Dodaj��6   $��0��6B   $��4��6R   $��28,103,43,18q�6_   �� 58   
   -   5        $��Izlaz��58   !   $��Izlaz��6   $��1��6.   $��4��6>   $��40,102,123,19q�6_   (  "System.Windows.Controls.DatePicker  59   
   -   5        $	��dpP��59      $��1��6K   $
��Left=�6[   $��	31,10,0,0q�6v   $��2��6�   $	��Top=�6�   $��24��6�   $	��102��6�   	   SelectedDate	 6    �� $ DatumPocetka�6�     5:   
   -   5        $	��dpK��5:      $��1��6I   $
��Left=�6Y   $��	31,10,0,0q�6t   $��3��6�   $	��Top=�6�   $��24��6�   $	��102��6�   	 6    �� $ 
DatumKraja�6�   �� 5<   
   $��
145,35,0,0q�6   
���  ��$
��Bold"�69   $
��Left=�5>      $	��145��67   $��23��6C   $	��Top=�6O   $��2��6g   $��3��6{   ��5=      �� 
 �� ElementName$
 tbPopust��$2 ,(Validation.Errors).CurrentItem.ErrorContent�5>   {   5?      5@      