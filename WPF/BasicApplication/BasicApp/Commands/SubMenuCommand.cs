using System;
using BasicApp.Helpers;

namespace BasicApp.Commands
{
    public class SubMenuCommand : Command<MenuGridHelper>
    {
        private readonly Guid _parentId;

        public SubMenuCommand(Guid parentId)
        {
            _parentId = parentId;
        }
        public override void ExecuteCommand(MenuGridHelper parameter)
        {
            parameter.ShowSubMenuChild(_parentId);
        }
    }
}
