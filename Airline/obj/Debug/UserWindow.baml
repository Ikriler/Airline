   M S B A M L   `   `   `  ????B  >Airline, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:AirlineAirline  5   	       Airline.UserWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Airline     5   	   -   5          ? Title$'  !AMONIC Airlines Automation System??5   	   $	??450??63   $	??800??6@   .??5	      ?  ? RowDefinitions 5
   
   ?? 5      $??0.25* ?6   ?? 5      $
??0.5* ?6   ?? 5      $
??0.5* ?6   ?? 5      $
??0.5* ?6   ?? 5      ?? 5      ?? 5      .+?5   
   ]? .+?5      o? $	??Top=?6   .@?5      m? -   5         m?Name$ exit_menu_item??5      $??_Exit??63   6B   5      5      ?? 5   
   -   5         ??Name$ hello_label??5      $??Label??6%   $
??Left=?65   $??Center=?6P   $??1??6k   ?? 5   
   -   5        $ spent_time_label??5      $??Label??6*   $
??Left=?6:   $??Center=?6U   $??2??6p   ?? 5   
   -   5        $ crashes_label??5      $??Label??6'   $
??Left=?67   $??Center=?6R   $??3??6m   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid??5      $??4??6P   $??3??6]      AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     
IsReadOnly . 	   RowStyle	 5      ?? 5      
 ?? 
TargetType)  #System.Windows.Controls.DataGridRow"
  6   .?5      ??  ?? Property ? ?? ?? Value
 ?  ??6A    ?? Triggers 5      ?? 5        ?? Binding 6&   ??  ?? Path$ reason? ?? Value  6F   .a?5!      ??  ? ??
 ?????6K   5"      5$         Columns 5&      0  *System.Windows.Controls.DataGridTextColumn  5'      ,  &System.Windows.Controls.DataGridColumn   Header$
 Date??6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   ?? $
 date?6S     5(      $ 
Login time??6%    69   ?? $ 
login_time?6_     5)      $ Logout time??6%    6:   ?? $ logout_time?6a     5*      $ Time spent on system??6%    6C   ?? $ 
spent_time?6i     5+      $  Unsuccessful logout reason??6%    6I   ?? $ reason?6k   5-      5/      50      