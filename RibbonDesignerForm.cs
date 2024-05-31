using DevExpress.DataAccess.UI.Native.Sql;
using DevExpress.DataAccess.Wizard;
using DevExpress.DataAccess.Wizard.Services;
using DevExpress.XtraReports.UserDesigner;
using DevExpress.XtraReports.Wizards.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportDesignQueries
{
    public partial class RibbonDesignerForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public RibbonDesignerForm()
        {
            InitializeComponent();
        }

        private void customXRDesignPanel1_DesignerHostLoading(object sender, EventArgs e)
        {
            var designPnl = sender as XRDesignPanel;
            designPnl.RemoveService(typeof(ISqlWizardOptionsProvider));
            designPnl.AddService(typeof(DevExpress.DataAccess.UI.Sql.ISqlWizardSettingsProvider), new SqlWizardSettingsProvider(() =>
               new DevExpress.DataAccess.UI.Wizard.SqlWizardSettings
               {
                   DatabaseCredentialsSavingBehavior = SensitiveInfoSavingBehavior.Always,
                   EnableCustomSql = true
               }));
            designPnl.AddService(typeof(ICustomQueryValidator), new CustomSqlQueryValidator());

        }
    }
}
