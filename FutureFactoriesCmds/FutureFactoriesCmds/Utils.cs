using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecnomatix.Engineering.Olp;
using Tecnomatix.Engineering;

namespace FutureFactoriesCmds
{
    internal static class Utils
    {
        internal static string SetDynamicParameter(string controllername, string columnName, ITxOperation op, string paramValue)
        {
            TxOlpControllerUtilities utils = new TxOlpControllerUtilities();
            ITxOlpRobotControllerParametersHandler paramHandler = (ITxOlpRobotControllerParametersHandler)utils.GetInterfaceImplementationFromController(controllername, typeof(ITxOlpRobotControllerParametersHandler), typeof(TxRobotSimulationControllerAttribute), "ControllerName");
            if (paramHandler != null)
            {
                if (paramHandler.HasComplexRepresentation(columnName, op, TxOlpCommandLayerRepresentation.UI))
                {
                    paramHandler.OnComplexValueChanged(columnName, paramValue, op);
                }
            }
            return paramValue;
        }

        internal static TxJumpToLocationStatus JumpRobotToLocation(ITxRoboticLocationOperation location)
        {
            if (location != null && location.ParentRoboticOperation != null)
            {

                TxRobot robot = location.ParentRoboticOperation.Robot as TxRobot;

                TxOlpControllerUtilities controllerUtilities = new TxOlpControllerUtilities();
                ITxRoboticControllerServices rcs = (ITxRoboticControllerServices)controllerUtilities.GetInterfaceImplementationFromController(robot.Controller.Name, typeof(ITxRoboticControllerServices), typeof(TxControllerAttribute), "ControllerName");
                if (rcs == null)
                {
                    rcs = (ITxRoboticControllerServices)controllerUtilities.GetInterfaceImplementationFromController("default", typeof(ITxRoboticControllerServices), typeof(TxControllerAttribute), "ControllerName");
                }

                if (rcs != null)
                {
                    rcs.Init(robot);
                    TxJumpToLocationData data = new TxJumpToLocationData();
                    data.GenerateMessage = true;
                    data.UseExternalAxes = true;
                    data.UseTaughtPose = true;
                    data.UseTaughtLocations = true;
                    TxJumpToLocationStatus statusRes = rcs.JumpToLocation(location, data);
                    return statusRes;
                }
            }
            return TxJumpToLocationStatus.FailureNoInverse;
        }

        internal static string GetDynamicParameter(string controllername, string columnName, ITxOperation op)
        {
            string paramValue = "";
            TxOlpControllerUtilities utils = new TxOlpControllerUtilities();
            ITxOlpRobotControllerParametersHandler paramHandler = (ITxOlpRobotControllerParametersHandler)utils.GetInterfaceImplementationFromController(controllername, typeof(ITxOlpRobotControllerParametersHandler), typeof(TxRobotSimulationControllerAttribute), "ControllerName");
            if (paramHandler != null)
            {
                if (paramHandler.HasComplexRepresentation(columnName, op, TxOlpCommandLayerRepresentation.UI))
                {
                    paramValue = paramHandler.GetComplexRepresentation(columnName, op, TxOlpCommandLayerRepresentation.UI);
                }
            }
            return paramValue;
        }

        internal static double Distance(TxTransformation point1, TxTransformation point2)
        {
            return Math.Sqrt(Math.Pow((point1.Translation.X - point2.Translation.X), 2) + Math.Pow((point1.Translation.Y - point2.Translation.Y), 2) + Math.Pow((point1.Translation.Z - point2.Translation.Z), 2));
        }
    }
}
