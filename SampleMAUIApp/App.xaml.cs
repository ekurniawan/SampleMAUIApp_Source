using SampleMAUIApp.Bab5;
using SampleMAUIApp.Bab6;

namespace SampleMAUIApp
{
    public partial class App : Application
    {

        private static DataAccess dbUtils = null!;
        public static DataAccess DBUtils
        {
            get
            {
                if (dbUtils == null)
                {
                    dbUtils = new DataAccess();
                }
                return dbUtils;
            }
        }

        private static IRestServices empServices;
        public static IRestServices EmpServices
        {
            get
            {
                if (empServices == null)
                {
                    empServices = new RestServices();
                }
                return empServices;
            }
        }



        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}