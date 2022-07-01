using lastchance.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace lastchance.ViewModels
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private EmployeeDetail _employeeDetail;

        public EmployeeDetail EmployeeDetail
        {
            get { return _employeeDetail; }
            set
            {
                _employeeDetail = value;
                OnPropertyChanged(nameof(EmployeeDetail));
            }
        }

        private ObservableCollection< EmployeeDetail> _lstemployeeDetail;

        public ObservableCollection<EmployeeDetail> LstEmployeeDetail
        {
            get { return _lstemployeeDetail; }
            set
            {
                _lstemployeeDetail = value;
                OnPropertyChanged(nameof(LstEmployeeDetail));
            }
        }

        private EmployeeDetail _selectedEmployee;

        public EmployeeDetail SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged(nameof(SelectedEmployee));
            }
        }
        private EmployeeDetail employeeDetail = new EmployeeDetail();
        public EmployeeDetail EmployeeDetailAdd
        {
            get { return employeeDetail; }
            set
            {
                employeeDetail = value;
                OnPropertyChanged(nameof(EmployeeDetailAdd));
            }
        }

        EmployeeEntities employeeEntities;

        public EmployeeViewModel()
        {
            employeeEntities = new EmployeeEntities();
            LoadEmployee();
            DeleteCommand = new Command((s) => true, Delete);
            UpdateCommand = new Command((s) => true, Update);
            UpdateEmployeeCommand = new Command((s) => true, UpdateEmployee);
            AddEmployeeCommand = new Command((s) => true, AddEmployee);
        }

        private void AddEmployee(object obj)
        {
            EmployeeDetailAdd.ID ="ID "+ employeeEntities.EmployeeDetails.Count();
            employeeEntities.EmployeeDetails.Add(EmployeeDetailAdd);
            employeeEntities.SaveChanges();
            EmployeeDetailAdd = new EmployeeDetail();
        }
        private void Delete(object obj)
        {
            var emp = obj as EmployeeDetail;
            employeeEntities.EmployeeDetails.Remove(emp);
            employeeEntities.SaveChanges();
            LstEmployeeDetail.Remove(emp);
        }
        private void Update(object obj)
        {
            SelectedEmployee = obj as EmployeeDetail;
        }
        private void UpdateEmployee(object obj)
        {
            employeeEntities.SaveChanges();
            SelectedEmployee = new EmployeeDetail();
        }

        private void LoadEmployee() //Read details
        {
            LstEmployeeDetail = new ObservableCollection<EmployeeDetail>(employeeEntities.EmployeeDetails);
        }

        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand UpdateEmployeeCommand { get; set; }
        public ICommand AddEmployeeCommand { get; set; }
    }

    class Command : ICommand
    {
        public Command(Func<Object, bool> methodCanExecute, Action<object> methodExecute)
        {
            MethodCanExecute = methodCanExecute;
            MethodExecute = methodExecute;
        }

        private Action<object> MethodExecute { get; set; }
        private Func<object, bool> MethodCanExecute { get; set; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return MethodExecute != null && MethodCanExecute.Invoke(parameter);
        }
        public void Execute(object parameter)
        {
            MethodExecute(parameter);
        }
        public void NotifyCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
