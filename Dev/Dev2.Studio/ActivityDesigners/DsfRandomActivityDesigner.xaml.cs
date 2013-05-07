﻿using System;
using System.Activities.Presentation.Model;
using System.Activities.Presentation.View;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using Dev2.Common;
using Dev2.Common.Enums;
using Dev2.Common.ExtMethods;
using Dev2.Data.Enums;
using System.Linq;

namespace Dev2.Studio.ActivityDesigners
{
    // Interaction logic for DsfRandomActivityDesigner.xaml
    public partial class DsfRandomActivityDesigner
    {
        #region Fields

        #endregion

        #region Ctor

        public DsfRandomActivityDesigner()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        void CbxRandomType_OnLoaded(object sender, RoutedEventArgs e)
        {           
            ComboBox cbx = sender as ComboBox;            
            if (cbx != null)
            {
                if (cbx.Items.Count == 0)
                {
                    cbx.ItemsSource = Dev2EnumConverter.ConvertEnumsTypeToStringList<enRandomType>();
                }
            }
        }

        void CbxRandomType_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            switch ((string)e.AddedItems[0])
            {
                case "GUID":
                    txtLength.Text = string.Empty;
                    txtLength.IsEnabled = false;
                    txtFrom.Visibility = Visibility.Hidden;
                    txtFrom.Text = string.Empty;
                    txtTo.Text = string.Empty;
                    txtTo.Visibility = Visibility.Hidden;
                    lblTo.Visibility = Visibility.Hidden;
                    lblLength.Content = "Length";
                    break;

                case "Numbers":
                    txtLength.Text = string.Empty;
                    txtLength.IsEnabled = false;
                    txtFrom.Visibility = Visibility.Visible;                    
                    txtTo.Visibility = Visibility.Visible;
                    lblTo.Visibility = Visibility.Visible;
                    lblLength.Content = "Range";
                    break;               
               
                default:                    
                    txtLength.IsEnabled = true;
                    txtFrom.Text = string.Empty;
                    txtTo.Text = string.Empty;
                    txtFrom.Visibility = Visibility.Hidden;   
                    txtTo.Visibility = Visibility.Hidden;
                    lblTo.Visibility = Visibility.Hidden;
                    lblLength.Content = "Length";
                    break;

            }
        }

        #endregion     

        
    }
}
