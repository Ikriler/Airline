   M S B A M L   `   `   `  ????B  >Airline, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:AirlineAirline  5   	       Airline.AdminWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Airline     5   	   -   5          ? Title$  AdminWindow??5   	   $	??450??6   $	??800??6*   .??5	      ?  ? ColumnDefinitions 5
   
   ?? 5      $
??0.1* ?6   ?? 5      $
??0.5* ?6   ?? 5       ? RowDefinitions 5   
   ?? 5      $??0.15* ?6   ?? 5      $??0.25* ?6   ?? 5      ?? 5      $??0.25* ?6   .+?5   
   ]? $??3??6   .+?5      o? $	??Top=?6   .@?5      m? -   5         m?Name$ add_user_menu_item??5      $??	_Add user??67   6J   m? 5      -   5        $ exit_menu_item??5      $??_Exit??63   6B   5      5      ?? 5   
   $??Office: ??6   $??1??6#   $??Center=?60   $??Right=?6K   6i   ?? 5   
   -   5         ??Name$ officesCombo??5       ?? SelectedIndex$ 0??6)   $??1??6;   $??1??6H   $??20q?6X   6?   &   System.Windows.Controls.DataGrid  5!   
   -   5          Name$ dataGrid??5!      $??2??6%   $??3??62      CanUserAddRows .     AutoGenerateColumns .  	   
IsReadOnly	 . 
   SelectionMode$
 Single=?6?      RowStyle 5"      ?? 5#       ?? 
TargetType)  #System.Windows.Controls.DataGridRow"  6    ?? Triggers 5$      ?? 5%       ?? Binding 6&   ??  ?? Path$
 role? ?? Value Administrator6D   .a?5&      ??  ?? Property ? ?? ?? Value
 ?????6;   5'      ?? 5(       6&   ?? $ active?	 False6F   .a?5)      ??  ? ??
 ?  ??6;   5*      5,         Columns 5.      0  *System.Windows.Controls.DataGridTextColumn  5/      ,  &System.Windows.Controls.DataGridColumn   
Visibility$ Hidden=?6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   ?? $ id?6W     50      $ Hidden=?6%    69   ?? $ active?6[     51         Header$
 Name??6%    63   ?? $ 	firstName?  52      $ 	Last Name??6%    68   ?? $ lastName?  53      $	 Age??6%    62   ?? $	 age?  54      $ 	User Role??6%    68   ?? $
 role?  55      $ Email Address??6%    6<   ?? $ email?  56      $ Office??6%    65   ?? $ office?58      ?? 5:   
   -   5         ??Name$ change_role??5:      $??Change Role??6&   $??0??6<   $??3??6L   $??20q?6Y   $	??100??6e   $
??Left=?6q   $??2??6?   6?   ?? 5;   
   -   5        $ change_login_status??5;      $??Enable/Disable Login??6.   $??1??6M   $??3??6]   $??20q?6j   $	??140??6v   $??Right=?6?   6?   5<      5=      