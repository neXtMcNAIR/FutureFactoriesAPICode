using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tecnomatix.Engineering.Ui;
using Tecnomatix.Engineering;

namespace FutureFactoriesCmds
{
    public partial class CreateRandomPathForm : TxForm
    {
        public CreateRandomPathForm()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            CreateRandomPathCmd.CreateRandomPath(RobotSelectCtrl.Object as TxRobot, (int)NumPoints.Value);
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RobotSelectCtrl_Picked(object sender, TxObjEditBoxCtrl_PickedEventArgs args)
        {

        }

        private void WorkspaceSelectCtrl_Picked(object sender, TxObjEditBoxCtrl_PickedEventArgs args)
        {

        }

        private void ColBodySelect_Picked(object sender, TxObjEditBoxCtrl_PickedEventArgs args)
        {

        }
    }
}
