using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Cloud.Firestore;

namespace database
{
    public partial class fform : Form
    {
        FirestoreDb database;
        public fform()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fform_Load(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "mynewdb-ae79c-firebase-adminsdk-qrv3p-df49d02dae.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            database = FirestoreDb.Create("mynewdb-ae79c");
            getDocs("Book");
        }
        async void getDocs(string nameOfCollection)
        {
            Query createQuery = database.Collection(nameOfCollection);
            QuerySnapshot snap = await createQuery.GetSnapshotAsync();

            foreach(DocumentSnapshot docsnap in snap.Documents){
                FieldInit init = docsnap.ConvertTo<FieldInit>();
                if (docsnap.Exists)
                {
                    Table.Rows.Add(docsnap.Id, init.Address, init.Age, init.Country, init.Education, init.Material);
                }

            }



        }

        private void File_Opening(object sender, CancelEventArgs e)
        {

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            addToDatabase add = new addToDatabase();
            add.FormClosed += new FormClosedEventHandler(addToDatabase_FormClosed);
            add.ShowDialog();
        }
        private void addToDatabase_FormClosed(object sender, FormClosedEventArgs e)
        {
            Table.Rows.Clear();
            getDocs("Book");
        }

        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int Row = Convert.ToInt32(Table.SelectedCells[0].RowIndex.ToString());
            int Col = Convert.ToInt32(Table.SelectedCells[0].ColumnIndex.ToString());

            string DeleteRow = Table[Col, Row].Value.ToString();

            DocumentReference doc = database.Collection("Book").Document(DeleteRow);
            doc.DeleteAsync();

            Table.Rows.Clear();
            getDocs("Book");
        }
    }
}
