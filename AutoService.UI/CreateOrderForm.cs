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

        public CreateOrderForm()
        {
            InitializeComponent();
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

            string firm = firmTextBox.Text;
            string model = modelTextBox.Text;

            bool engineIsWork = false;
            bool transmissionIsWork = false;
            bool wheelsIsWork = false;

            if(yesRBtn.Checked == true)
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
        }

        private MechanismStatuses GetMechanismStatus(bool flag)
        {
            if (flag)
                return MechanismStatuses.Work;
            else
                return MechanismStatuses.Broken;
        }
    }
}
