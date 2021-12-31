using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
        private static Thread workerEmployeesThread;

        public Form1()
        {
            InitializeComponent();

            RecruiteEmployee(new Employee("Mike", "Wazovski"));

            workerEmployeesThread = new Thread(() =>
            {
                while (true)
                    TryTakeOrder();
            });
            workerEmployeesThread.IsBackground = true;
            workerEmployeesThread.Start();
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
            Thread.Sleep(6000); //6sec
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

                    CarFactory.ReplaceCar(car, ChangeMechanismStatus);

                    _employeesTasks[emp].Close();
                    _employeesTasks.Remove(emp);
                }
            }
            Debug.WriteLine("TryTakeOrder done.");
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

        private static void ChangeMechanismStatus(Car car)
        {
            foreach (var mechanism in car.GetComponents())
            {
                mechanism.Status = MechanismStatuses.Work;
            }
        }

        private void getInfoBtn_Click(object sender, EventArgs e)
        {
            if(treeView.SelectedNode != null && treeView.SelectedNode.Tag != null)
            {
                //Больше не нужно определять является ли этот объект сотрудником или заказом
                //Нам это и не важно, нам важно получить информацию, а значит объект, из которого
                //мы будем пытаться её извлечь обязан реализовывать метод определенный интерфейсом.
                TreeNode node = treeView.SelectedNode;
                IGetInformation bindObj = node.Tag as IGetInformation;

                informationTextBox.Text = bindObj.GetInfo();
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

        private void analysisBtn_Click(object sender, EventArgs e)
        {
            int countWaitOrders = _orders.Where(order => order.OrderStatus == OrderStatuses.Wait)
                                         .Count();

            int countProgressOrders = _orders.Where(order => order.OrderStatus == OrderStatuses.Progress)
                                             .Count();

            int freeEmployees = _employees.Where(emp => !_employeesTasks.Keys.Contains(emp))
                                          .Count();

            int timeNeed = countWaitOrders * 2 / _employees.Count;

            var averageTimeDone = _orders.Where(order => order.OrderStatus == OrderStatuses.Finished)
                                         .Select(order => order.FinishDate - order.RequestDate)
                                         .Average(dateTime => dateTime.TotalSeconds);
                                         

            informationTextBox.Text = $"Заказов ожидающих выполнения: {countWaitOrders}\n" +
                                      $"Заказов в процессе выполнения: {countProgressOrders}\n" +
                                      $"Кол-во сотрудников: {_employees.Count}\n" +
                                      $"Кол-во свободных сотрудников: {freeEmployees}\n" +
                                      $"Примерное время ожидания: {timeNeed}\n" +
                                      $"Среднее выполнение заказа: {averageTimeDone} секунд";
        }
    }
}
