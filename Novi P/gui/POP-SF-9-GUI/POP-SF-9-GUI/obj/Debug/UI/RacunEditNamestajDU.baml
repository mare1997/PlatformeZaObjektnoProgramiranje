   M S B A M L   `   `   `  ����G  CPOP-SF-9-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:POP_SF_9_GUI.UIPOP_SF_9_GUI.UI  5   	   )    #POP_SF_9_GUI.UI.RacunEditNamestajDU   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:POP_SF_9_GUI.UI     5   	     � Title$  RacunEditNamestajDU��5   	   $	��300��6%   $	��300��62    � 	Resources 5	         TextBoxError)  #POP_SF_9_GUI.UI.ValidationConverter  	converter��%�   &	        &	 �     �� 5
   
   .R�5      ]� ��. .+�5      �� $��Right=�6   
���  ��$
��12pt(�6D   Polje ne sme biti prazno!6o   �� 5      
���  ��$��1q�6+   ._�5      �� 5      5      5        5   
   6$   5      .��5      � .+�5   
   �� -   5         ��Name$ label��5      $��Izaberi jednu stavku:��6   $
��Left=�6?   $��7,5,0,0q�6Z   $	��Top=�6k    J� RenderTransformOrigin$ -0.263,-0.385&�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgPrikaz��5         CanUserAddRows .  $
��Left=�6r   $��0,30,0,0q�6�   $	��Top=�6�   $	��290��6�   $	��150��6�   �� 5   
   -   5         ��Name$ 	btSacuvaj��5      $��Dodaj��6$   $
��Left=�6J   $��	5,240,0,0q�6e   $	��Top=�6x   $��75��6�   �� 5   
   -   5        $ btIzlaz��5      $��Izlaz��6"   $
��Left=�6H   $��210,240,0,0q�6c   $	��Top=�6x   $��75��6�   �� 5   
   -   5        $ label1��5      $��	Kolicina:��6    $
��Left=�64   $��	5,189,0,0q�6O   $	��Top=�6b   �� 5   
   -   5         ��Name$ 
tbKolicina��5      $
��Left=�6&   $��23��6A   $��
70,190,0,0q�6M    �� TextWrapping$
 Wrap=�6a   $	��Top=�6v   $	��120��6�   5      5      