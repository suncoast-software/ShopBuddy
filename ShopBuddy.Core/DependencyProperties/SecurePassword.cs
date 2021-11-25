namespace ShopBuddy.Core.DependencyProperties;
public static class SecurePassword
{
    private static readonly DependencyProperty PasswordInitializedProperty = 
        DependencyProperty.RegisterAttached("PasswordInitialized", typeof(bool), typeof(SecurePassword), new PropertyMetadata(false));

    private static readonly DependencyProperty SettingPasswordProperty =
        DependencyProperty.RegisterAttached("SettingPassword", typeof(bool), typeof(SecurePassword),new PropertyMetadata(false));

    public static string GetPassword(DependencyObject obj)
    {
         return (string)obj.GetValue(PasswordProperty);
    }

    public static void SetPassword(DependencyObject obj, string value)
    {
        obj.SetValue(PasswordProperty, value);
    }

    public static readonly DependencyProperty PasswordProperty =
        DependencyProperty.RegisterAttached("Password", typeof(string), typeof(SecurePassword), 
            new FrameworkPropertyMetadata(Guid.NewGuid().ToString(), HandleBoundPasswordChanged)
        {
            BindsTwoWayByDefault = true,
            DefaultUpdateSourceTrigger = UpdateSourceTrigger.LostFocus
        });

    private static void HandleBoundPasswordChanged(DependencyObject dp, DependencyPropertyChangedEventArgs e)
    {
        var passwordBox = dp as PasswordBox;
        if (passwordBox == null)
            return;

        if ((bool)passwordBox.GetValue(SettingPasswordProperty))
            return;

        if (!(bool)passwordBox.GetValue(PasswordInitializedProperty))
        {
            passwordBox.SetValue(PasswordInitializedProperty, true);
            passwordBox.PasswordChanged += HandlePasswordChanged;

        }
        passwordBox.Password = e.NewValue as string;
    }

    private static void HandlePasswordChanged(object sender, RoutedEventArgs e)
    {
        var passwordBox = (PasswordBox)sender;
        passwordBox.SetValue(SettingPasswordProperty, true);
        SetPassword(passwordBox, passwordBox.Password);
        passwordBox.SetValue(SettingPasswordProperty, false);
    }

}

