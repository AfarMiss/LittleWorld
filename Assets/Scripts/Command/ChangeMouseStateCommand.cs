using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static LittleWorld.Command.ChangeMouseStateCommand;

namespace LittleWorld.Command
{
    public class ChangeMouseStateCommand : ICommand
    {
        private MouseState mouseState;
        public delegate void Handler(object param);
        public ChangeMouseStateCommand(MouseState mouseState)
        {
            this.mouseState = mouseState;
        }

        public void Execute()
        {
            Current.MouseState = mouseState;
            switch (mouseState)
            {
                case MouseState.Normal:
                    InputController.Instance.DisableRenderGhostBuilding();
                    break;
                case MouseState.ExpandZone:
                    InputController.Instance.DisableRenderGhostBuilding();
                    break;
                case MouseState.ShrinkZone:
                    InputController.Instance.DisableRenderGhostBuilding();
                    break;
                case MouseState.AddSection:
                    InputController.Instance.DisableRenderGhostBuilding();
                    break;
                case MouseState.DeleteSection:
                    InputController.Instance.DisableRenderGhostBuilding();
                    break;
                case MouseState.ExpandStorageZone:
                    InputController.Instance.DisableRenderGhostBuilding();
                    break;
                case MouseState.ShrinkStorageZone:
                    InputController.Instance.DisableRenderGhostBuilding();
                    break;
                case MouseState.AddStorageSection:
                    InputController.Instance.DisableRenderGhostBuilding();
                    break;
                case MouseState.DeleteStorageSection:
                    InputController.Instance.DisableRenderGhostBuilding();
                    break;
                case MouseState.BuildingGhost:
                    InputController.Instance.EnableRenderGhostBuilding();
                    break;
                case MouseState.ReadyToFire:
                    InputController.Instance.DisableRenderGhostBuilding();
                    break;
                default:
                    InputController.Instance.DisableRenderGhostBuilding();
                    break;
            }
        }
    }

    public class ChangeGhostBuildingCommand : ICommand
    {
        private int buildingCode;
        public ChangeGhostBuildingCommand(int buildingCode)
        {
            this.buildingCode = buildingCode;
        }

        public void Execute()
        {
            InputController.Instance.CurSelectedBuildingCode = buildingCode;
            InputController.Instance.UpdateGhostBuilding(buildingCode);
        }
    }
}
