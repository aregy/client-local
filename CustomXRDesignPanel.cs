using DevExpress.DataAccess.Wizard;
using DevExpress.DataAccess.Wizard.Services;
using DevExpress.XtraReports.UserDesigner;
using DevExpress.XtraReports.Wizards.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportDesignQueries
{
    [ToolboxItem(true)]
    public class CustomXRDesignPanel : XRDesignPanel
    {
        public CustomXRDesignPanel() {
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // CustomXRDesignPanel
            // 
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
