using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicApplication.Domain.Models;

namespace BasicApp.ViewModels.Factories
{
    public class AdminMenuListFactory
    {
        public IEnumerable<Menu> GetMenus()
        {

            IList<Menu> menus = new List<Menu>();
            List<Guid> guids = new List<Guid>();
            for (int i = 0; i < 10; i++)
            {
                guids.Add(Guid.NewGuid());
            }
            menus.Add(new Menu
            {
                Id = guids[0],
                ParentId = Guid.Empty,
                Sequence = 1,
                Name = "L1-1"
            }) ; 
            menus.Add(new Menu
            {
                Id = guids[1],
                ParentId = Guid.Empty,
                Sequence = 2,
                Name = "L1-2"
            }); 
            menus.Add(new Menu
            {
                Id = guids[2],
                ParentId = Guid.Empty,
                Sequence = 3,
                Name = "L1-3"
            }); 
            menus.Add(new Menu
            {
                Id = guids[3],
                ParentId = guids[0],
                Sequence = 1,
                Name = "L1-C1"
            }); 
            menus.Add(new Menu
            {
                Id = guids[4],
                ParentId = guids[0],
                Sequence = 2,
                Name = "L1-C2"
            }); 
            menus.Add(new Menu
            {
                Id = guids[5],
                ParentId = guids[1],
                Sequence = 1,
                Name = "L2-C1"
            }); 
            menus.Add(new Menu
            {
                Id = guids[6],
                ParentId = guids[2],
                Sequence = 1,
                Name = "L3-C1"
            }); 
            menus.Add(new Menu
            {
                Id = guids[7],
                ParentId = guids[3],
                Sequence = 1,
                Name = "L1-C1-C1"
            });
            menus.Add(new Menu
            {
                Id = guids[8],
                ParentId = guids[6],
                Sequence = 1,
                Name = "L3-C1-C1"
            });
            return menus;
        }
    }
}
