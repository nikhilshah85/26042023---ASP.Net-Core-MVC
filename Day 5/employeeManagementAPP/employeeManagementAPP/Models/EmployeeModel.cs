namespace employeeManagementAPP.Models
{
    public class EmployeeModel
    {
        public int empNo { get; set; }
        public string empName { get; set; }
        public string empDesignation { get; set; }
        public double empSalary { get; set; }
        public bool empIsPermenant { get; set; }

        private static List<EmployeeModel> eList = new List<EmployeeModel>()
        {
            new EmployeeModel(){ empNo=101, empName="Nikhil", empSalary=12000, empDesignation="Consultant", empIsPermenant=true  },
            new EmployeeModel(){ empNo=102, empName="Sameer", empSalary=23000, empDesignation="HR", empIsPermenant=true  },
            new EmployeeModel(){ empNo=103, empName="Pratik", empSalary=21000, empDesignation="Consultant", empIsPermenant=false  },
            new EmployeeModel(){ empNo=104, empName="Keshav", empSalary=42000, empDesignation="Consultant", empIsPermenant=true  },
            new EmployeeModel(){ empNo=105, empName="Mohit", empSalary=8000, empDesignation="Sales", empIsPermenant=false  },
        };

        public List<EmployeeModel> GetAllEmployees()
        {
            return eList;
        }

        public EmployeeModel GetEmployeeById(int eid)
        {
            var emp = eList.Find(e => e.empNo == eid);

            if (emp != null)
            {
                return emp;
            }
            throw new Exception("Employee  not  found in system");
        }
    }
}
