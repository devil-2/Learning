using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using BasicApp.Commands;
using Domain = BasicApplication.Domain.Models;

namespace BasicApp.Helpers
{
    public class MenuGridHelper
    {
        private Grid _grid;
        private readonly IEnumerable<Domain.Menu> _menus;
        private UIElement subMenuElement, subMenuChildElement;

        public MenuGridHelper(IEnumerable<Domain.Menu> menus)
        {
            _menus = menus;
        }

        public void CreateMainMenu(Grid grid)
        {
            var menus = _menus.Where(x => x.ParentId == Guid.Empty);
            grid.RowDefinition(2, GridUnitType.Auto);
            grid.RowDefinition(1, GridUnitType.Star);
            foreach (var menu in menus)
            {
                grid.ColumnDefinition(1);
                menu.Row = 1;
                menu.Col = menu.Sequence - 1;
                var rb = Border(RadioButton(menu, new MenuCommand(menu.Id)));
                Grid.SetColumn(rb, menu.Col);
                Grid.SetRow(rb, menu.Row - 1);
                grid.Children.Add(rb);

            }
            _grid = grid;
        }

        private UIElement Border(UIElement child) {
            return new Border
            {
                BorderThickness = new Thickness(1),
                BorderBrush = Brushes.LightGray,
                Child = child
            };
        }

        private UIElement RadioButton(Domain.Menu menu, Command command)
        {
            return new RadioButton
            {
                Content = menu.Name,
                Command = command,
                CommandParameter = this,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(5),
                ToolTip = menu.ToolTip
            };
        }


        private UIElement LeftArrow()
        {
            return new Button();
        }

        private UIElement RadioButtonWithCaret(Domain.Menu menu,Command command)
        {
            Grid grid = new Grid();
            grid.ColumnDefinition(1);
           // grid.ColumnDefinition(1,GridUnitType.Auto);
            var rb = RadioButton(menu, command);
            //var caret = LeftArrow();
            grid.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetColumn(rb, 0);
           // Grid.SetColumn(caret, 1);
            grid.Children.Add(rb);
           // grid.Children.Add(caret);
            return grid;
        }
        public void ShowMenuChild(Guid parentId)
        {
            var parent = _menus.FirstOrDefault(x => x.Id.Equals(parentId));
            var subMenu = _menus.Where(x => x.ParentId.Equals(parentId));
            if (subMenuElement != null) _grid.Children.Remove(subMenuElement);
            if (subMenuChildElement != null) _grid.Children.Remove(subMenuChildElement);

            var stackPanel = new StackPanel();
            foreach (var menu in subMenu)
            {
                menu.Row = parent.Row;
                menu.Col = parent.Col;
                var rb = Border(RadioButtonWithCaret(menu, new SubMenuCommand(menu.Id)));
                stackPanel.Children.Add(rb);
            }
            Grid.SetColumn(stackPanel, parent.Col);
            Grid.SetRow(stackPanel, parent.Row);
            subMenuElement = stackPanel;

            _grid.Children.Add(stackPanel);
        }

        public void ShowSubMenuChild(Guid parentId)
        {
            var parent = _menus.FirstOrDefault(x => x.Id.Equals(parentId));
            var subMenu = _menus.Where(x => x.ParentId.Equals(parentId));
            if (subMenuChildElement != null) _grid.Children.Remove(subMenuChildElement);
            var stackPanel = new StackPanel();
            foreach (var menu in subMenu)
            {
                menu.Row = parent.Row;
                menu.Col = parent.Col;
                var rb = Border(RadioButton(menu, new SubMenuCommand(menu.Id)));
                stackPanel.Children.Add(rb);
            }
            var maxCol = _grid.ColumnDefinitions.Count - 1;

            Grid.SetColumn(stackPanel, parent.Col >= maxCol ? parent.Col - 1 : parent.Col + 1);
            Grid.SetRow(stackPanel, parent.Row);
            subMenuChildElement = stackPanel;
            _grid.Children.Add(stackPanel);
        }
    }
}
