﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WebDataReader.Client
{
  /// <summary>
  /// Lógica de interacción para MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window //MahApps.Metro.Controls.MetroWindow
  {
    private MainWindowViewModel context;
    public MainWindow(MainWindowViewModel vm)
    {
      InitializeComponent();
      context = vm;
      DataContext = vm;
      Loaded += (e, s) => { };
    }

    protected override void OnClosing(CancelEventArgs e)
    {
      try
      {
        if (context == null) return;

        context.TransformViewModel.OnClosing();
      }
      catch (Exception ex)
      {
       
       // Messenger.Default.Send(new FooterErrorMessage(ex));
      }
      base.OnClosing(e);
    }
  }
}
