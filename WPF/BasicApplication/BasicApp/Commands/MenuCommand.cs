using System;
using BasicApp.Helpers;

namespace BasicApp.Commands
{
    public class MenuCommand : Command<MenuGridHelper>
    {
        private readonly Guid _parentId;

        public MenuCommand(Guid parentId)
        {
           _parentId = parentId;
        }
        public override void ExecuteCommand(MenuGridHelper parameter)
        {
            parameter.ShowMenuChild(_parentId);
        }
    }
}
