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
    public partial class Form1 : Form
    {
        private static List<Employee> _employees = new List<Employee>();
        private static List<Order> _orders = new List<Order>();
        private static Dictionary<Employee, Order> _employeesTasks = new Dictionary<Employee, Order>();

        public Form1()
        {
            InitializeComponent();
            RecruiteEmployee(new Employee("Mike", "Wazovski"));
        }

        /// <summary>
        /// Нанять сотрудника и добавить в "базу".
        /// </summary>
        /// <param name="employee"> Сотрудник. </param>
        public void RecruiteEmployee(Employee employee)
        {
            _employees.Add(employee);
            TreeNode employeesNode = treeView.Nodes[1];
            employeesNode.Nodes.Add(new TreeNode() { Text = employee.Name, Tag = employee });
        }

        public void TryTakeOrder()
        {
            foreach (var emp in _employees)
            {
                if (!_employeesTasks.ContainsKey(emp))
                {
                    Order order = GiveOrder();

                    if (order != null)
                    {
                        order.ChangeStatusToProgress();
                        _employeesTasks.Add(emp, order);
                    }
                }
                else
                {
                    Car car = _employeesTasks[emp].Client.Car;

                    foreach(var mechanism in car.GetComponents())
                    {
                        mechanism.Status = MechanismStatuses.Work;
                    }

                    _employeesTasks[emp].Close();
                    _employeesTasks.Remove(emp);
                }
            }
        }

        private Order GiveOrder()
        {
            foreach (var order in _orders)
            {
                if (order.OrderStatus == OrderStatuses.Wait)
                    return order;
            }

            return null;
        }


        private void getInfoBtn_Click(object sender, EventArgs e)
        {
            if(treeView.SelectedNode != null && treeView.SelectedNode.Tag != null)
            {
                TreeNode node = treeView.SelectedNode;
                object bindObj = node.Tag;

                if(bindObj is Employee)
                {
                    Employee emp = bindObj as Employee;
                    informationTextBox.Text = emp.GetInfo();
                }
                else
                {
                    Order order = bindObj as Order;
                    informationTextBox.Text = order.GetInfo();
                }
            }
        }

        private void createOrderBtn_Click(object sender, EventArgs e)
        {
            CreateOrderForm form = new CreateOrderForm();
            form.ShowDialog();
            if(form.DialogResult == DialogResult.OK)
            {
                Order order = form.GetOrder();
                _orders.Add(order);
                TreeNode ordersNode = treeView.Nodes[0];
                ordersNode.Nodes.Add(new TreeNode() { Text = order.Id.ToString(), Tag = order });
                informationTextBox.Text = order.GetInfo();

                TryTakeOrder();
            }
        }

        private void cancelOrderBtn_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode != null && treeView.SelectedNode.Tag != null)
            {
                TreeNode node = treeView.SelectedNode;
                object bindObj = node.Tag;

                if (bindObj is Order)
                {
                    Order order = bindObj as Order;
                    order.Canceled();
                    informationTextBox.Text = order.GetInfo();
                }
            }
        }
    }
}
