   M S B A M L   `   `   `  ����G  CPOP-SF-9-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:POP_SF_9_GUI.UIPOP_SF_9_GUI.UI  5   	   -    'POP_SF_9_GUI.UI.DodatnaUslugaWindowEdit   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:POP_SF_9_GUI.UI     5   	     � Title$  DodatnaUslugaWindowEdit��5   	   $	��300��6)   $	��300��66    � 	Resources 5	         TextBoxError)  #POP_SF_9_GUI.UI.ValidationConverter  	converter��%�   &	        &	 �     �� 5
   
   .R�5      ]� ��. .+�5      �� $��Right=�6   
���  ��$
��12pt(�6D   Polje ne sme biti prazno!6o   �� 5      
���  ��$��1q�6+   ._�5      �� 5      5      5        5   
   6$   5      .��5      �  � RowDefinitions 5   
   �� 5      $	��55* �6   �� 5      $	��45* �6   �� 5      $
��169* �6   .+�5   
   �� $��Naziv:��6   $
��Left=�6"   $��-1,6,0,0q�6=   $	��Top=�6O    J� RenderTransformOrigin$ -0.179,0.03&�6g   $��91��6�   $��29��6�   �� 5   
   -   5        $��tbNaziv��5      $
��Left=�6!   $��29��6<   $��	160,6,0,0q�6H    �� TextWrapping$
 Wrap=�6[   $	��Top=�6p   $	��130��6�   .��6�   ��5      �� 5       �� Path$ Naziv�6    �� UpdateSourceTrigger$ PropertyChanged=�6'    �� ValidationRules 5        POP_SF_9_GUI.UI.StringV  5      5!      .��5"      5#      �� 5$   
   -   5        $��	btSacuvaj��5$      $��Sacuvaj��6"   $
��Left=�6L   $��
22,125,0,0q�6g   $	��Top=�6{   $��75��6�   $��2��6�   �� 5%   
   -   5        $��btIzlaz��5%      $��Izlaz��6    $
��Left=�6>   $��198,125,0,0q�6Y   $	��Top=�6n   $��75��6�   $��2��6�   �� 5&   
   $��Cena:��6   $
��Left=�6!   $	��Top=�6<   $ -0.179,0.03&�6T   $��91��6x   $��29��6�   $��1��6�   �� 5'   
   -   5         ��Name$ tbCena��5'      $
��Left=�6"   $��29��6=   $��	160,1,0,0q�6I   $
 Wrap=�6\   $	��Top=�6q   $	��130��6�   $��1��6�   .��6�   ��5(      �� 5)      $
 Cena�6   $ PropertyChanged=�6&    5*        POP_SF_9_GUI.UI.DoubleV  5+      5-      .��5.      5/      �� 50   
   -   5        	 ��Name$	 	textBlock��50      $
��Left=�6'   $��
161,34,0,0q�6B   $
��Wrap=�6V   $	��Top=�6k   $	��129��6�   
���  ��$
��Bold"�6�   ��51      �� 
 �� ElementName$
 tbNaziv��$2 ,(Validation.Errors).CurrentItem.ErrorContent��� 52   
   -   5        $	 textBlock_Copy��52      $
��Left=�6,   $��
160,30,0,0q�6G   $
��Wrap=�6[   
���  ��$
��Bold"�6�   $	��Top=�53   t   $	��129��6�   $��1��6�   $��2��6�   ��6   �� $
 tbCena��$2 ,(Validation.Errors).CurrentItem.ErrorContent�6�   55      56      