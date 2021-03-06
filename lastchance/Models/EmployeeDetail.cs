//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace lastchance.Models
{
    // This class implements INotifyPropertyChanged
    // to support one-way and two-way bindings
    // (such that the UI element updates when the source
    // has been changed dynamically)
    public partial class EmployeeDetail : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

       
        private string iD;
        private string name;
        private string gender;
        private string age;
        private string address;

        public string ID
        {
            get => iD; set
            {
                iD = value;
                OnPropertyChanged(nameof(ID));
            }
        }
        public string Name
        {
            get => name; set
            {
               name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Age
        {
            get => age; set
            {
                age = value;
                OnPropertyChanged(nameof(age));
            }
        }
        public string Gender {
            get => gender; set
            {
                gender = value;
                OnPropertyChanged(nameof(Gender));
            }
        }
        public string Address { 
            get => address; set
            {
                address = value;
                OnPropertyChanged(nameof(Address));
            }
        }


        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}