using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecnomatix.Engineering;
using Tecnomatix.Engineering.Olp;

namespace FutureFactoriesCmds
{
    public class CreateRandomPathCmd : TxButtonCommand
    {
        public override string Category
        {
            get
            {
                return "Future Factories";
            }
        }

        public override string Name
        {
            get
            {
                return "Create Random MoCap Path";
            }
        }

        public override void Execute(object cmdParams)
        {
            CreateRandomPathForm form = new CreateRandomPathForm();
            form.Show();
        }

        public static void CreateRandomPath(TxRobot robot, int numPoints)
        {
            //Get robot joints and configure operation
            TxObjectList<TxJoint> joints = robot.Joints;
            TxOperationRoot root = TxApplication.ActiveDocument.OperationRoot;
            TxGenericRoboticOperation op = root.CreateGenericRoboticOperation(new TxGenericRoboticOperationCreationData(robot.Name + "RandomPath"));
            op.Robot = robot;
            Random rnd = new Random();

            //configure collision detection params
            TxCollisionRoot collisionRoot = TxApplication.ActiveDocument.CollisionRoot;
            collisionRoot.CheckCollisions = true;
            collisionRoot.CollisionQueryMode = TxCollisionQueryParams.TxCollisionQueryMode.DefinedPairs;
            collisionRoot.ReportLevel = TxCollisionQueryParams.TxCollisionReportLevel.LowestLevel;
            TxCollisionQueryParams queryParams = new TxCollisionQueryParams();
            queryParams.ReportLevel = TxCollisionQueryParams.TxCollisionReportLevel.LowestLevel;
            queryParams.Mode = TxCollisionQueryParams.TxCollisionQueryMode.DefinedPairs;
            queryParams.StopQueryAfterFirstCollision = true;

            int currNumPoints = 0;

            while (currNumPoints < numPoints) //loop until we have a path created with all required points
            {
                joints[0].CurrentValue = ((rnd.NextDouble() * 360.0) - 180.0) * Math.PI / 180.0;
                joints[1].CurrentValue = ((rnd.NextDouble() * 360.0) - 180.0) * Math.PI / 180.0;
                joints[2].CurrentValue = ((rnd.NextDouble() * 360.0) - 5.0) * Math.PI / 180.0;
                joints[3].CurrentValue = ((rnd.NextDouble() * 360.0) - 180.0) * Math.PI / 180.0;
                joints[4].CurrentValue = ((rnd.NextDouble() * 360.0) - 180.0) * Math.PI / 180.0;
                joints[5].CurrentValue = ((rnd.NextDouble() * 360.0) - 180.0) * Math.PI / 180.0;
                TxCollisionQueryResults workspaceColResults = collisionRoot.GetCollidingObjects(queryParams);
                if (workspaceColResults.States.Count == 0)
                {
                    TxGenericRoboticLocationOperation robLoc = op.CreateGenericRoboticLocationOperation(new TxGenericRoboticLocationOperationCreationData("Loc " + currNumPoints));
                    TxRobotConfigurationData currConfig = robot.GetPoseConfiguration(robot.CurrentPose);
                    
                    robLoc.AbsoluteLocation = robot.TCPF.AbsoluteLocation;
                    robLoc.RobotConfigurationData = currConfig;
                    joints[0].CurrentValue = 0;
                    joints[1].CurrentValue = 0;
                    joints[2].CurrentValue = 0;
                    joints[3].CurrentValue = 0;
                    joints[4].CurrentValue = 0;
                    joints[5].CurrentValue = 0;
                    TxJumpToLocationStatus jumpStatus = Utils.JumpRobotToLocation(robLoc);
                    TxCollisionQueryResults colResCheck2 = collisionRoot.GetCollidingObjects(queryParams);
                    if (colResCheck2.States.Count != 0 || jumpStatus != TxJumpToLocationStatus.Success)
                        robLoc.Delete();
                    else
                        currNumPoints++;
                }
            }

        }
    }
}
