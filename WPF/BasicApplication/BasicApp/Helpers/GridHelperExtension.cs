using System.Windows;
using System.Windows.Controls;

namespace BasicApp.Helpers
{
    public static class GridHelperExtension
    {

        public static Grid RowDefinition(this Grid grid, int nRows, GridUnitType gridUnit)
        {
            for (int i = 0; i < nRows; i++)
            {
                RowDefinition rows = new RowDefinition
                {
                    Height = new GridLength(i, gridUnit)
                };
                grid.RowDefinitions.Add(rows);
            }
            return grid;
        }
        public static Grid ColumnDefinition(this Grid grid, int nColumns)
        {
            for (int i = 0; i < nColumns; i++)
            {
                ColumnDefinition columns = new ColumnDefinition();
                grid.ColumnDefinitions.Add(columns);
            }
            return grid;
        }
        public static Grid ColumnDefinition(this Grid grid, int nColumns, GridUnitType gridUnit)
        {
            for (int i = 0; i < nColumns; i++)
            {
                ColumnDefinition columns = new ColumnDefinition
                {
                    Width = new GridLength(i, gridUnit)
                };
                grid.ColumnDefinitions.Add(columns);
            }
            return grid;
        }
    }
}
