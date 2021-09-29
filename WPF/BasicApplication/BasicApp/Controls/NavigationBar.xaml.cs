using System;
using System.Collections.Generic;
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
using BasicApp.Helpers;
using BasicApp.ViewModels.Factories;
using Domain = BasicApplication.Domain.Models;

namespace BasicApp.Controls
{
    /// <summary>
    /// Interaction logic for NavigationBar.xaml
    /// </summary>
    public partial class NavigationBar : UserControl
    {


        public IEnumerable<Domain.Menu> MenuList
        {
            get { return (IEnumerable<Domain.Menu>)GetValue(GridProperty); }
            set { SetValue(GridProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Grid.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GridProperty =
            DependencyProperty.Register("MenuList", typeof(IEnumerable<Domain.Menu>), typeof(NavigationBar), 
                new FrameworkPropertyMetadata(null,FrameworkPropertyMetadataOptions.None,MenuListChanged,null,false,UpdateSourceTrigger.PropertyChanged));
        
        private static void MenuListChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is NavigationBar nav) {
                nav.Update();
            }
        }

        public NavigationBar()
        {
            
            InitializeComponent();
           
            
            //navigationGrid.Children.Add()
        }

        private void Update()
        {
            MenuGridHelper grid = new MenuGridHelper(MenuList);
            grid.CreateMainMenu(navigationGrid);
        }
    }
}
