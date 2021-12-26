using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoService.UI.CarBL;

namespace AutoService.UI
{
    public partial class CreateOrderForm : Form
    {
        private Order order = null;
        private List<CarFirms> carFirms = new List<CarFirms>();

        public CreateOrderForm()
        {
            InitializeComponent();

            //Заполняем список фирм
            foreach (CarFirms firm in Enum.GetValues(typeof(CarFirms)))
            {
                carFirms.Add(firm);
            }

            comboBox1.DataSource = carFirms;
        }

        public Order GetOrder()
        {
            return order;
        }

        private void yesRBtn_CheckedChanged(object sender, EventArgs e)
        {
            if(yesRBtn.Checked == true)
            {
                groupBox2.Visible = true;
            }
            else
            {
                groupBox2.Visible = false;
            }
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string lastName = lastNameTextBox.Text;
            string phone = phoneTextBox.Text;
            string email = emailTextBox.Text;

            string firm = comboBox1.SelectedItem.ToString();
            string model = modelTextBox.Text;

            bool engineIsWork = false;
            bool transmissionIsWork = false;
            bool wheelsIsWork = false;

            if (yesRBtn.Checked)
            {
                engineIsWork = !engineCheckBox.Checked;
                transmissionIsWork = !transmissionCheckBox.Checked;
                wheelsIsWork = !wheelsCheckBox.Checked;
            }

            order = new Order(new Client(name, lastName, phone, email,
                              new Car(new Engine(GetMechanismStatus(engineIsWork)),
                              new Wheels(GetMechanismStatus(wheelsIsWork)),
                              new Transmission(GetMechanismStatus(transmissionIsWork)),
                              firm, model)));

            if (yesSendRbtn.Checked)
                order.Finished += SendMessageToClient;
        }

        private MechanismStatuses GetMechanismStatus(bool flag)
        {
            if (flag)
                return MechanismStatuses.Work;
            else
                return MechanismStatuses.Broken;
        }

        private void SendMessageToClient(object sender, EventArgs e)
        {
            Order temp = sender as Order;

            //Здесь например логика отправки сообщения на электронную почту

            MessageBox.Show($"На почту {temp.Client.EMail} отправлено сообщение.", "Внимание!",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
