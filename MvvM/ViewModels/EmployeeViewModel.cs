using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

using MvvM.Models;
using MvvM.Commands;


namespace MvvM.ViewModels
{
    public class EmployeeViewModel: INotifyPropertyChanged
    {
        #region INotifyPropertyChanged_Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
                  
        }
        #endregion

        EmployeeService ObjEmployeeService;
        public EmployeeViewModel()
        {
            ObjEmployeeService = new EmployeeService();
            LoadData();
            CurrentEmployee = new Employee();
            saveCommand = new RelayComman(Save);
            searchCommnad = new RelayComman(Search);
        }

        #region DisplayOperation
        private ObservableCollection<Employee> employeeList;
        public  ObservableCollection<Employee> EmployeeList
        {
            get { return employeeList; }
            set { employeeList = value; OnPropertyChanged("EmployeeList"); }
        }
        private void LoadData() {
            EmployeeList = new ObservableCollection<Employee>(ObjEmployeeService.GetAll());
        }
        #endregion

        private Employee currentEmployee;

        public Employee CurrentEmployee
        {
            get { return currentEmployee; }
            set { currentEmployee = value; OnPropertyChanged("CurrentEmployee"); }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }

        #region SaveOpperation
        private RelayComman saveCommand;
        public RelayComman SaveCommand
        {
            get { return saveCommand; }
            set { saveCommand = value;}
        }

        public void Save() 
        {
            try
            {
                var IsSaved = ObjEmployeeService.Add(CurrentEmployee);
                LoadData();
                if (IsSaved)
                    Message = "Employe saved";
                else
                    Message = "Save opperation failed";
            }
            catch (Exception ex)
            {

                Message = ex.Message;
            }
        }
        #endregion

        #region SearchOpperation

        private RelayComman searchCommnad;
        public RelayComman SearchCommand
        {
            get { return searchCommnad; } 

        }
        public void Search() {
            try
            {
                var ObjEmployee = ObjEmployeeService.Search(CurrentEmployee.Id);
                if (ObjEmployee != null)
                {
                    CurrentEmployee.Name = ObjEmployee.Name;
                    CurrentEmployee.Age = ObjEmployee.Age;
                }
                   
                else
                    Message = "Employee Not Found";
            }
            catch (Exception ex)  
            {

                Message = ex.Message;
                
            }

        }
        #endregion



    }
}
