   M S B A M L   `   `   `  ����G  CPOP-SF-9-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:POP_SF_9_GUI.UIPOP_SF_9_GUI.UI  5   	   (    "POP_SF_9_GUI.UI.TipNamestajaWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:POP_SF_9_GUI.UI     5   	     � Title$  TipNamestajaWindow��5   	   $	��300��6$   $	��300��61    � 	Resources 5	         TextBoxError)  #POP_SF_9_GUI.UI.ValidationConverter  	converter��%�   &	        &	 �     �� 5
   
   .R�5      ]� ��. .+�5      �� $��Right=�6   
���  ��$
��12pt(�6D   Polje ne sme biti prazno!6o   �� 5      
���  ��$��1q�6+   ._�5      �� 5      5      5        5   
   6$   5      .��5      � .+�5   
   �� $��Naziv:��6   $
��Left=�6"   $��	17,24,0,0q�6=   $	��Top=�6P    J� RenderTransformOrigin$ -0.179,0.03&�6h   $��91��6�   $��29��6�   �� 5   
   -   5        $��tbNaziv��5      $
��Left=�6!   $��29��6<   $��
130,24,0,0q�6H    �� TextWrapping$
 Wrap=�6\   $	��Top=�6q   $	��161��6�   .��6�   ��5      �� 5       �� Path$ Naziv�6    �� UpdateSourceTrigger$ PropertyChanged=�6'    �� ValidationRules 5        POP_SF_9_GUI.UI.StringV  5      5      .��5      5      �� 5   
   -   5        $��	btSacuvaj��5      $��Sacuvaj��6"   $
��Left=�6L   $��
22,225,0,0q�6g   $	��Top=�6{   $��75��6�   �� 5    
   -   5        $��btIzlaz��5       $��Izlaz��6    $
��Left=�6>   $��198,225,0,0q�6Y   $	��Top=�6n   $��75��6�   �� 5!   
   -   5         ��Name$ 	textBlock��5!      $
��Left=�6'   $��130,54,-3,0q�6B   $
��Wrap=�6W   
���  ��$
��Bold"�6|   $	��Top=�6�   $	��165��6   ��6�   ��  �� ElementName$ tbNaziv��$2 ,(Validation.Errors).CurrentItem.ErrorContent�6   5#      5$      