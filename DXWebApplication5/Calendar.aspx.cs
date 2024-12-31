using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using DevExpress.Web.ASPxScheduler;
using DevExpress.XtraScheduler;

namespace DXWebApplication5 {
    public partial class Calendar : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            
        }
        int lastInsertedAppointmentId;
        
        // DXCOMMENT: This handler is called when a datasource insert operation has been completed
        protected void SchedulingDataSource_Inserted(object sender, SqlDataSourceStatusEventArgs e) {
            // DXCOMMENT: This method saves the last inserted appointment's unique identifier
            SqlConnection connection = (SqlConnection)e.Command.Connection;
            using (SqlCommand cmd = new SqlCommand("SELECT IDENT_CURRENT('Appointments')", connection)) {
                this.lastInsertedAppointmentId = Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        
        // DXCOMMENT: This handler is called before appointment data is posted to the datasource for insertion
        protected void Scheduler_AppointmentRowInserting(object sender, ASPxSchedulerDataInsertingEventArgs e) {
            // DXCOMMENT: This method removes the ID field from the row insert query
            e.NewValues.Remove("ID");
        }
        
        // DXCOMMENT: This handler is called after a new record that contains appointment information has been inserted into the datasource
        protected void Scheduler_AppointmentRowInserted(object sender, ASPxSchedulerDataInsertedEventArgs e) {
            // DXCOMMENT: This method sets the value of the key field for the appointment's data record
            e.KeyFieldValue = this.lastInsertedAppointmentId;
        }
        
        // DXCOMMENT: This handler is called after appointments are added to the collection
        protected void Scheduler_AppointmentsInserted(object sender, PersistentObjectsEventArgs e) {
            // DXCOMMENT: This method sets unique identifiers for new appointments
            ((ASPxSchedulerStorage)sender).SetAppointmentId((Appointment)e.Objects[0], lastInsertedAppointmentId);
        }
    }
}