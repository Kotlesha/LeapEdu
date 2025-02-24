using LeapEdu.Views;

namespace LeapEdu;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute("register", typeof(RegisterPage));
        Routing.RegisterRoute("repairPassword", typeof(RepairPasswordPage));
        Routing.RegisterRoute("loginVerification", typeof(LoginVerificationPage));
    }
}
