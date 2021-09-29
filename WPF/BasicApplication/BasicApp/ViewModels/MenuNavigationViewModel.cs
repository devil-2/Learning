using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicApp.ViewModels.Factories;
using BasicApplication.Domain.Models;

namespace BasicApp.ViewModels
{
    public class MenuNavigationViewModel : ViewModelBase
    {
        private readonly AdminMenuListFactory _adminMenuListFactory;

        private int _rowCount;

        public int RowCount
        {
            get { return _rowCount; }
            set
            {
                _rowCount = value;
                OnPropertyChanged(nameof(RowCount));
            }
        }

        private int _columnCount;

        public int ColumnCount
        {
            get { return _columnCount; }
            set
            {
                _columnCount = value;
                OnPropertyChanged(nameof(ColumnCount));
            }
        }

        public IEnumerable<Menu> Columns { get; set; }



        public MenuNavigationViewModel(AdminMenuListFactory adminMenuListFactory)
        {
            _adminMenuListFactory = adminMenuListFactory;
            Columns = _adminMenuListFactory.GetMenus().Where(x => x.ParentId == Guid.Empty);
            RowCount = 1;
            ColumnCount = Columns.Count();
        }
    }
}
